using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float jumpForce = 2f; // Deklaracja, inicjalizacja i pobranie wartoœci prywatnego pola si³y odrzutu
    [SerializeField] private GameObject TrampolineImage = null; // Deklaracja, inicjalizacja i pobranie wartoœci prywatnego pola o typie GameObject
    private Animator anim; // Deklaracja prywatnego pola o typie Animator

    /// <summary>
    /// Metoda wywo³uj¹ca automatycznie po utowrzeniu obiektu
    /// </summary>
    void Start()
    {
        // Pobranie wartoœci z komponentu Animatora
        anim = TrampolineImage.GetComponent<Animator>();
    }

    /// <summary>
    /// Metoda wywo³ywana po wykryciu kolizji
    /// </summary>
    /// <param name="collision">Odwo³anie do obiektu wywo³uj¹cego kolizjê</param>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Je¿eli obiekt wywo³uj¹cy to gracz
        if (collision.gameObject.name == "Player")
        {
            // Rozpoczênie animacji skoku
            anim.SetTrigger("jump");
            // Nadanie si³y odrzutu trampoliny dla obiektu gracza
            collision.attachedRigidbody.velocity = new Vector2(collision.attachedRigidbody.velocity.x, jumpForce);
            // Zakoñczenie animacji skoku
            anim.SetTrigger("jump");
        }

    }
}
