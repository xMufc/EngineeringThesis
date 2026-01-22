using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullJump : MonoBehaviour
{

    private Rigidbody2D body; // Deklaracja prywatnego pola o typie Rigidbody2D 
    private BoxCollider2D coll; // Deklaracja prywatnego pola o typie BoxCollider2D

    [SerializeField] private float moveSpeed = 2f; // Deklaracja i inicjalizacja prywatnego pola zawier¹cego prêdkoœæ poruszania
    [SerializeField] private float jumpForce = 2f; // Deklaracja i inicjalizacja prywatnego pola zawieraj¹ca si³e skoku
    [SerializeField] private LayerMask jumpableGround; // Deklaracja i inicjalizacja prywatnego pola o typie LayerMask
    bool move = false; // Pole przechowuj¹ce informacje o aktualnych kierunku patrzenia czaszki

    /// <summary>
    /// Metoda wywo³ywana automatycznie podczas tworzenia obiektu
    /// </summary>
    private void Start()
    {
        // Pobranie aktualnych wartoœci czaszki z komponentu RigidBody2D
        body = GetComponent<Rigidbody2D>();
        // Pobranie aktualnych wartoœci czaszki z komponentu BoxCollider2D
        coll = GetComponent<BoxCollider2D>();
    }

    /// <summary>
    /// Metoda wywo³ywana podczas skoku czaszki
    /// </summary>

    void jump()
    {
        // Deklaracja i inicjalizacja pola temp
        float temp = 0;
        // Nadanie wartoœci skoku dla obiektu czaszki
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        // Sprawdzenie w którym kierunku aktualne skacze czaszka
        if (move)
        {
            // Nadanie kierunku skoku dla obiektu czaszki
            body.velocity = new Vector2(-1 * moveSpeed, body.velocity.y);
        }
        else
        {
            // Nadanie kierunku skoku dla obiektu czaszki
            body.velocity = new Vector2(1 * moveSpeed, body.velocity.y);
        }
        // Pêtla wywo³ywana do momentu opadniêcia czaszki
        while (true)
        {
            // Zwiêkszenie pola temp o wartoœæ, która up³ynê³a od ostatniego cyklu
            temp += Time.deltaTime;
            // Sprawdzenie czy czaszka znajduje siê na ziemi
            if((IsGrounded(coll.bounds.center, coll.bounds.size, jumpableGround.value) == true) || temp > 3)
            {           
                // Obrócenie obiektu czaszki
                transform.Rotate(0f, 180f, 0f);
                // Zmienienie kierunku skoku czaszki
                move = !move;
                // Przerwanie pêtli
                break;         
            }
        }
    }

    /// <summary>
    ///  Metoda sprawdzaj¹ca czy obiektu znajduje siê na ziemi
    /// </summary>
    /// <param name="origin">Pocz¹tkowa pozycja</param>
    /// <param name="size">Rozmiar obszaru</param>
    /// <param name="ground">Warstwa kolizji</param>
    /// <returns>Zwrócenie wartoœci bool aktualnej pozycji czaszki</returns>
    /// 
    public bool IsGrounded(Vector3 origin, Vector3 size, int ground)
    {
        // Zwrócenie wartoœci bool aktualnej pozycji czaszki
        return Physics2D.BoxCast(origin, size, 0f, Vector2.down, .1f, ground);
    }
}
