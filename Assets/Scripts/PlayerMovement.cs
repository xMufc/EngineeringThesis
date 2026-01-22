using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioSource jumpEffect; // Deklaracja i pobranie odwo³ania do dŸwiêków

    private float dirX = 0f; // Deklaracja i inicjalizacja prywatnego pola 
    private bool moveRight = false; // Deklaracja i inicjalizacja prywatnego pola poruszania w prawo
    private bool moveLeft = false; // Deklaracja i inicjalizacja prywatnego pola poruszania w lewo
    private bool jump = false; // Deklaracja i inicjalizacja prywatnego pola skoku
    [SerializeField] private float moveSpeed = 7f; // Deklaruje i pobranie odwo³ania do dŸwiêków

    [SerializeField] private float jumpForce = 14f; // Deklaracja, inicjalizacja i pobranie si³y skoku
    [SerializeField] private float climbForce = 3f; // Deklaracja, inicjalizacja i pobranie si³y wchodzenia po drabinie

    private Rigidbody2D body; // Deklaracja prywatnego pola typu RigidBody2D
    private BoxCollider2D coll; // Deklaracja prywatnego pola typu BoxCollider2D
    private Animator anim; // Deklaracja prywatnego pola typu Animator
    private SpriteRenderer sprite; // Deklaracja prywatnego pola typu SpriteRenderer
     
    private bool isWallSliding; // Deklaracja prywatnego pola zeœlizgiwania po œcianie
    private readonly float wallSlidingSpeed = 2f;

    [SerializeField] private LayerMask jumpableGround;

    private bool isLadder = false; // Deklaracja i inicjalizacja prywatnego pola drabiny
    private bool isClimbing = false; // Deklaracja i inicjalizacja prywatnego pola wchodzenia po drabinie

    private GameObject currentTeleporter; // Deklaracja prywatnego pola typu GameObject
    Vector3 destinationPoint; // Deklaracja wektora 3D zawieraj¹cego wspó³rzêdnego teleportera

    private enum MovementState { idle, running, jumping, falling }; // Deklaracja i inizjalizacja prywatnego typu enum zawieraj¹cego stany obiektu

    /// <summary>
    /// Metoda wywo³ywana autmatycznie przy utworzenie obiektu
    /// </summary>
    private void Start()
    {
        body = GetComponent<Rigidbody2D>(); // Pobranie aktualnej wartoœci RigidBody2D
        coll = GetComponent<BoxCollider2D>(); // Pobranie aktualnej wartoœci BoxCollider2D
        anim = GetComponent<Animator>(); // Pobranie aktualnej wartoœci Animator
        sprite = GetComponent<SpriteRenderer>(); // Pobranie aktualnej wartoœci SpriteRenderer
    }

    /// <summary>
    /// Metoda wywo³ywana automatycznie co dany cykl niezale¿nie od liczby FPSów
    /// </summary>
    private void FixedUpdate()
    {
        // Wywo³anie metody poruszenia postaci
        Movement();
        // Pobranie wciskanych przycisków na klawiaturze
        dirX = Input.GetAxis("Horizontal");
        // Sprawdzenie czy postaæ ma wykonaæ skok, nie znajduje siê na drabinie
        if ((Input.GetButtonDown("Jump") || jump) && IsGrounded(coll.bounds.center, coll.bounds.size, body.gravityScale, jumpableGround.value) && !isLadder)
        {
            // W³¹czenie efektu dŸwiêkowego skoku
            jumpEffect.Play();
            // Je¿eli obiekt ma normaln¹ grawitacjê
            if (body.gravityScale > 1)
            {
                // Ustawienie si³y skoku
                body.velocity = new Vector2(body.velocity.x, jumpForce);
            }
            // Je¿eli obiekt ma obrócon¹ grawitacjê
            else
            {
                // Ustawienie si³y skoku
                body.velocity = new Vector2(body.velocity.x, -jumpForce);
            }
            
        }
        // Je¿eli obiekt wchodzi po drabinie
        if (isClimbing)
        {
            // Zmienienie wartoœci grawitacji
            body.gravityScale = 0f;
            // Ustawienie si³y wchodzenia
            body.velocity = new Vector2(body.velocity.x, climbForce);
        }

        // Wykonanie metody aktualizuj¹cej animacje
        UpdateAnimation();
    }

    /// <summary>
    /// Metoda wywo³ywana automatycznie co klatkê
    /// </summary>
    private void Update()
    {
        // Wywo³anie metody poruszenia postaci
        Movement();
        // Sprawdzenie czy postaæ ma wykonaæ skok, nie znajduje siê na drabinie i nie korzysta z teleportu
        if ((Input.GetButtonDown("Jump") || jump) && IsGrounded(coll.bounds.center, coll.bounds.size, body.gravityScale, jumpableGround.value) && !isLadder && currentTeleporter == null)
        {
            // W³¹czenie efektu dŸwiêkowego skoku
            jumpEffect.Play();
            // Je¿eli obiekt ma normaln¹ grawitacjê
            if (body.gravityScale > 1)
            {
                // Ustawienie si³y skoku
                body.velocity = new Vector2(body.velocity.x, jumpForce);
            }
            // Je¿eli obiekt ma obrócon¹ grawitacjê
            else
            {
                // Ustawienie si³y skoku
                body.velocity = new Vector2(body.velocity.x, -jumpForce);
            }
        }
        // Je¿eli postaæ ma wspi¹æ siê po drabinie
        else if ((Input.GetButtonDown("Jump") || jump) && isLadder)
        {
            // Ustawienie wartoœci bool na true dla pola okreœlaj¹cego aktualne wchodzenie po drabinie 
            isClimbing = true;
        }
        // Sprawdzenie czy postaæ ma skoczyæ od œciany i nie znajduje siê na drabinie
        else if ((Input.GetButtonDown("Jump") || jump) && isWallSliding && !isLadder)
        {
            // Ustawienie si³y skoku
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            // Ustawienie wartoœci bool na false dla pola okreœlaj¹cego aktualny œlizg gracza
            isWallSliding = false;
        }
        // Je¿eli postaæ ma przeteleportowaæ siê
        else if ((Input.GetButtonDown("Jump") || jump) && currentTeleporter != null)
        {
            // Pobranie koordynatów teleportu, do którego ma przeteleportowaæ siê obiekt
            destinationPoint = currentTeleporter.GetComponent<Teleport>().GetDestination().position;
            // Rozpoczêcie kurtyne teleportacji
            StartCoroutine(PortalAnim());
        }

        // Wykonanie metody zeœligu po œcianie
        WallSlide();
        // Wykonanie metody aktualizuj¹cej animacje
        UpdateAnimation();
    }

    /// <summary>
    /// Ustawienie pola poruszania siê w prawo na true
    /// </summary>
    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    /// <summary>
    /// Ustawienie pola poruszania siê w lewo na true
    /// </summary>
    public void PointerDownRight()
    {
        moveRight = true;
    }

    /// <summary>
    /// Ustawienie pola skoku na true
    /// </summary>
    public void PointerDownJump()
    {
        jump = true;
    }

    /// <summary>
    /// Ustawienie pola poruszania siê w lewo na false
    /// </summary>
    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    /// <summary>
    /// Ustawienie pola poruszania siê w prawo na false
    /// </summary>
    public void PointerUpRight()
    {
        moveRight = false;
    }

    /// <summary>
    /// Ustawienie pola skoku na false
    /// </summary>
    public void PointerUpJump()
    {
        jump = false;
    }

    /// <summary>
    /// Metoda umo¿liwiaj¹ca poruszanie siê
    /// </summary>
    public void Movement()
    {
        // Je¿eli obiekt ma poruszaæ siê w praw¹ stronê
        if (moveRight)
        {
            // Nadanie odpowiedniej si³y poruszania siê
            body.velocity = new Vector2(1 * moveSpeed, body.velocity.y);
        }
        // Je¿eli obiekt ma poruszaæ siê w lew¹ stronê
        else if (moveLeft)
        {
            // Nadanie odpowiedniej si³y poruszania siê
            body.velocity = new Vector2(-1 * moveSpeed, body.velocity.y);
        }
        // Je¿eli obiekt ma poruszaæ siê w jedna ze stron (sprawdzenie dla przycisków klawiatury AD)
        else
        {
            // Nadanie odpowiedniej si³y poruszania siê
            body.velocity = new Vector2(dirX * moveSpeed, body.velocity.y);
        }
    }

    /// <summary>
    /// Metoda aktualizuj¹ca animacje
    /// </summary>
    private void UpdateAnimation()
    {
        MovementState state; // Deklaracja pola typu enum

        // Je¿eli obiekt ma poruszyæ siê w praw¹ stronê
        if (moveRight || dirX > 0f)
        {
            // Zmienienie aktualnego stanu na bieg
            state = MovementState.running;
            // Sprawdzenie czy obiekt ma normalna grawitacjê i czy znajduje siê na drabinie
            if(body.gravityScale > 1 || isLadder)
            {
                // Wy³¹czenie obrotu obiektu wzglêdem osi X
                sprite.flipX = false;
            }
            else
            {
                // W³¹czenie obrotu obiektu wzglêdem osi X
                sprite.flipX = true;
            }
            
        }
        // Je¿eli obiekt ma poruszyæ siê w lew¹ stronê
        else if (moveLeft || dirX < 0f)
        {
            // Zmienienie aktualnego stanu na bieg
            state = MovementState.running;
            // Sprawdzenie czy obiekt ma normalna grawitacjê i czy znajduje siê na drabinie
            if (body.gravityScale > 1 || isLadder)
            {
                // W³¹czenie obrotu obiektu wzglêdem osi X
                sprite.flipX = true;
            }
            else
            {
                // Wy³¹czenie obrotu obiektu wzglêdem osi X
                sprite.flipX = false;
            }
        }
        // Je¿eli obiektu stoi w miejscu
        else
        {
            // Zmienienie aktualnego stanu na bezruch
            state = MovementState.idle;
        }
        // Je¿eli obiekt ma ustawion¹ dodatni¹ si³ê wzglêdem osi Y i nie jest na drabinie
        if (body.velocity.y > .1f && !isLadder)
        {
            // Zmienienie aktualnego stanu na skok
            state = MovementState.jumping;
        }
        // Je¿eli obiekt ma ustawion¹ ujemn¹ si³ê wzglêdem osi Y i nie jest na drabinie
        else if (body.velocity.y < -.1f && !isLadder)
        {
            // Zmienienie aktualnego stanu na spadanie
            state = MovementState.falling;
        }

        // Wywo³anie stosownej animacji
        anim.SetInteger("state", (int)state);
    }

    /// <summary>
    ///  Metoda sprawdzaj¹ca czy obiektu znajduje siê na ziemi
    /// </summary>
    /// <param name="origin">Pocz¹tkowa pozycja</param>
    /// <param name="size">Rozmiar obszaru</param>
    /// <param name="ground">Warstwa kolizji</param>
    /// <returns>Zwrócenie wartoœci bool aktualnej pozycji gracza</returns>
    /// 
    public bool IsGrounded(Vector3 origin, Vector3 size, float gravity, int ground)
    {
        // Sprawdzenie wartoœci grawitacji obiektu gracza
        if (gravity > 1)
        {
            return Physics2D.BoxCast(origin, size, 0f, Vector2.down, .1f, ground);
        }
        else
        {
            return Physics2D.BoxCast(origin, size, 0f, Vector2.up, .1f, ground);
        }
        
    }
    /// <summary>
    /// Metoda zwracaj¹ca czy gracz aktualnie dotyka œcianê
    /// </summary>
    /// <returns>Wartoœæ bool oznaczaj¹cy czy gracz dotyka jedn¹ ze œcian</returns>
    private bool IsWalled()
    {
        bool left, right;
        // Sprawdzenie czy dotyka lewej œciany
        left = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.left, .1f, jumpableGround);
        // Sprawdzenie czy dotyka prawej œciany
        right =  Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, .1f, jumpableGround);
        // Zwrócenie wyniku
        return left ? left : right;
    }

    /// <summary>
    /// Metoda umo¿liwiaj¹ca zeœlizgiwanie siê gracza po œcianach
    /// </summary>
    private void WallSlide()
    {
        // Sprawdzenie czy dotyka jedn¹ ze œcian
        if (IsWalled() && IsGrounded(coll.bounds.center, coll.bounds.size, body.gravityScale, jumpableGround.value) == false && (dirX != 0f || moveLeft || moveRight))
        {
            // Ustawienie wartoœci bool na true dla pola okreœlaj¹cego aktualny œlizg gracza
            isWallSliding = true;
            // Zmienienie wartoœci prêdkoœci obiektu gracza
            body.velocity = new Vector2(body.velocity.x, WallSlideSpeed(body.velocity.y, -wallSlidingSpeed, float.MaxValue)); ;
        }
        else
        {
            // Ustawienie wartoœci bool na false dla pola okreœlaj¹cego aktualny œlizg gracza
            isWallSliding = false;
        }
    }

    /// <summary>
    /// Obliczenie prêdkoœci zeœlizgiwania siê 
    /// </summary>
    /// <param name="value">Aktualna prêdkoœæ</param>
    /// <param name="min">Minimalnaprêdkoœæ jak¹ mo¿e osi¹gn¹æ</param>
    /// <param name="max">Maksymalna prêdkoœæ jak¹ mo¿e osi¹gn¹æ</param>
    /// <returns>Prêdkoœæ zeœlizgiwania siê</returns>
    public float WallSlideSpeed(float value, float min, float max)
    {
        return Mathf.Clamp(value, min, max);
    }

    /// <summary>
    /// Animacja teleportu
    /// </summary>
    /// <returns></returns>
    IEnumerator PortalAnim()
    {
        // Zmienienie wartoœci symulacji obiektu
        body.simulated = false;
        // Wywo³anie animacji wci¹gniêcia do portalu
        anim.Play("Player_Portal_In");
        // Zatrzymanie na po³ sekundy
        yield return new WaitForSeconds(0.5f);
        // Przeniesienie obiektu do wyznaczonego teleportu
        transform.position = destinationPoint;
        // Wywo³anie animacji wyjœcia z portalu
        anim.Play("Player_Portal_Out");
        // Zatrzymanie na po³ sekundy
        yield return new WaitForSeconds(0.5f);
        // Zmienienie wartoœci symulacji obiektu
        body.simulated = true;
    }

    /// <summary>
    /// Metoda wywo³ywana automatycznie po wykryciu kolizji
    /// </summary>
    /// <param name="collision">Obiekt wywo³uj¹cy kolizjê</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Je¿eli obiektem wywo³uj¹cym jest drabina
        if (collision.CompareTag("Ladder"))
        {
            // Ustawienie wartoœci bool na true dla pola okreœlaj¹cego drabine
            isLadder = true;
        }
        // Je¿eli obiektem wywo³uj¹cym jest teleport
        else if (collision.CompareTag("Teleporter"))
        {
            // Pobranie odwo³ania do aktualnego obiektu teleportu
            currentTeleporter = collision.gameObject;
        }
    }
    /// <summary>
    /// Metoda wywo³ywana automatycznie po wyjœciu z kolizji
    /// </summary>
    /// <param name="collision">Obiekt wychodz¹cy z kolizji</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Je¿eli obiektem wywo³uj¹cym jest drabina
        if (collision.CompareTag("Ladder"))
        {
            // Ustawienie wartoœci bool na false dla pola okreœlaj¹cego drabine
            isLadder = false;
            // Ustawienie wartoœci bool na false dla pola okreœlaj¹cego aktualne wchodzenie po drabinie
            isClimbing = false;
            // Przywrócenie pierwotnego stanu grawitacji
            body.gravityScale = 3f;
        }
        // Je¿eli obiektem wywo³uj¹cym jest teleport
        else if (collision.CompareTag("Teleporter"))
        {
            // Ustawienie aktualnego teleportu na null
            currentTeleporter = null;
        }
    }

}

