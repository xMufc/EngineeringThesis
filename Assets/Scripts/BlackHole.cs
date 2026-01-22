using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float gravitationalConstant = 5f; // Sta³a grawitacyjna - dostosuj wed³ug potrzeb
    public float attractionRangePercentage = 0.1f; // Procent szerokoœci okna gry, na jak¹ ma dzia³aæ przyci¹ganie
    public bool stopGravity = false; // Zmienna boolowska wyznaczaj¹ca rodzaj czarnej dziury
    private bool exit = false; // Zmienna boolowska wy³¹czaj¹ca dzia³anie czarnej dziury
    Rigidbody2D playerBody; // Komponent Rigidbody2D dla obiektu gracza
    public Transform player; // Komponent Rigidbody2D dla obiektu gracza


    /// <summary>
    /// Metoda Start() startuj¹ca podczas wystartowania programu
    /// </summary>
    private void Start()
    {
        playerBody = player.GetComponent<Rigidbody2D>(); // Pobranie wartoœci aktualnego komponentu RigidBody2D obiektu gracza
    }

    /// <summary>
    /// Metoda FixedUpdate() wywo³ywana w interwa³ach czasowych niezale¿nie od liczby FPSów
    /// </summary>

    void FixedUpdate()
    {
        // ZnajdŸ wszystkie obiekty w zasiêgu przyci¹gania
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, Camera.main.pixelWidth * attractionRangePercentage);

        // Przejdz po ka¿dym odnalezionym obiekcie
        foreach (Collider2D obj in objectsInRange)
        {
            // Pobranie w³aœciwoœci komponentu RigidBody2D dla aktualnie sprawdzanego obiektu
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>(); 
            
            // Sprawdzenie czy aktualnie sprawdzany obiekt jest obiektem gracza
            if (rb == playerBody && !exit)
            {
                // Obliczenie kierunku przyci¹gania
                Vector2 direction = Direction((Vector2)transform.position, rb.position);
                // Pobranie odleg³oœci
                float distance = direction.magnitude;
                // Deklaracja zmiennej si³y przyci¹gania
                float forceMagnitude;
                // Podniesienie odleg³oœci do kwadratu
                float distancePow = Mathf.Pow(distance, 1f);
                // Sprawdzenie czy odleg³oœæ jest wiêksza od 1f
                if (distance > 1f)
                {
                    // Obliczanie si³y przyci¹gania
                    forceMagnitude = Force(gravitationalConstant, rb.mass, distancePow);
                }
                else
                {
                    // Przypisanie si³y przyci¹gania bliskiej zeru
                    forceMagnitude = 0.1f;
                    // Wy³¹czenie przyci¹gania czarnej dziury
                    if (stopGravity == true)
                    {
                        exit = true;
                    }

                }
                // Normalizacja kieruneku przyci¹gania
                Vector2 force = ForceNormalized(direction, forceMagnitude);
                // Zastosuj si³ê do obiektu
                rb.AddForce(force);
            }
        }
    }
    /// <summary>
    /// Metoda obliczaj¹ca si³ê przyci¹gania
    /// </summary>
    /// <param name="gravitationalConstant">Sta³a grawitacyjna</param>
    /// <param name="mass">Masa obiektu gracza</param>
    /// <param name="distance">Dystans miêdzy obiektami</param>
    /// <returns>Si³a przyci¹gania</returns>
    public float Force(float gravitationalConstant, float mass, float distance)
    {
        return (gravitationalConstant * mass * 1 / distance);
    }

    /// <summary>
    /// Metoda normalizuj¹ca si³ê przyci¹gania
    /// </summary>
    /// <param name="direction">Kierunek przyci¹gania</param>
    /// <param name="force">Si³a przyci¹gania</param>
    /// <returns>Znormalizowana si³a przyci¹gania</returns>
    public Vector2 ForceNormalized(Vector2 direction, float force)
    {
        return direction.normalized * force;
    }


    /// <summary>
    /// Obliczenie kierunku przyci¹gania
    /// </summary>
    /// <param name="positionBlackHole">Wspó³rzêdne czarnej dziruy</param>
    /// <param name="positionPlayer">Obliczenie gracza</param>
    /// <returns>Obliczony kierunek przyci¹gania</returns>
    public Vector2 Direction(Vector2 positionBlackHole, Vector2 positionPlayer)
    {
        return positionBlackHole - positionPlayer;
    }
}