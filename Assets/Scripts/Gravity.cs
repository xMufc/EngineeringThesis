using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody2D rb; // Deklaracja prywatnego pola typu RigidBody2D
    private bool top; // Deklaracja prywatnego pola bool

    /// <summary>
    /// Metoda automatycznie wywo³ywana podczas tworzenia obiektu
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Pobranie aktualnej wartoœci komponentu RigidBody2D
    }


    /// <summary>
    /// Metoda wywo³ywana podczas wykrywcia kolizji
    /// </summary>
    /// <param name="collision">Obiekt wywo³ywuj¹cy kolizjê</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gravity"))
        {
            collision.gameObject.tag = "Untagged";
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            rb.gravityScale = ChangeGravity(rb.gravityScale);
            Rotation();
        }
    }

    /// <summary>
    /// Metoda obracaj¹ca obiekt wzglêdem osi
    /// </summary>

    void Rotation()
    {
        // Utworzenie wektora z czteroma wspó³rzêdnymi
        Quaternion qua = new(transform.rotation.x, transform.rotation.y, RotationAngles(top), transform.rotation.w);
        // Obrócenie obiektu o wyliczon¹ wartoœæ
        transform.rotation = qua;
        // Zmienienie aktualnej pozycji gracza
        top = !top;
    }

    /// <summary>
    /// Metoda wyznaczaj¹ca wartoœæ obrotu
    /// </summary>
    /// <param name="top">Aktualna pozycja gracza</param>
    /// <returns>Wartoœæ obrotu</returns>
    public float RotationAngles(bool top)
    {
        // Je¿eli gracz znajduje siê na ziemii
        if(!top)
        {
            // Obrócenie o 180 stopni
            return 180f;
        }
        // Jezeli nie to powrót do normalnej wartoœci
        return 0f;
    }

    /// <summary>
    /// Metoda zmieniaj¹ca grawitacjê
    /// </summary>
    /// <param name="gravity">Aktualna grawitacja</param>
    /// <returns>Nowa wartoœæ grawitacji</returns>
    public float ChangeGravity(float gravity)
    {
        // Zwrócenie nowej wartoœci grawitacji
        return gravity * (-1);
    }
}
