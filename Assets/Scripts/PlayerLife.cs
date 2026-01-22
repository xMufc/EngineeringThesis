using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim; // Delaracja prywatnego pola typu Animator
    private Rigidbody2D body; // Delaracja prywatnego pola typu RigidBody2D

    [SerializeField] private AudioSource deathEffect; // Deklaracja i pobranie wartoœci dla prywatnego pola typu AudoSource

    /// <summary>
    /// Metoda wywo³ywana automaczynie podczas tworzenia obiektu
    /// </summary>
    private void Start()
    {
        anim = GetComponent<Animator>(); // Pobranie aktualnej wartoœci komponentu Animator
        body = GetComponent<Rigidbody2D>(); // Pobranie aktualnej wartoœci komponentu Rigidbody2D
    }

    /// <summary>
    /// Metoda wywo³ywana automatycznie w momencie wykrynia kolizji
    /// </summary>
    /// <param name="collision">Obiekt wywo³uj¹cy kolizjê</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Je¿eli obiekt wywo³uj¹cy kolizjê to obiekty œmiertelne
        if (collision.gameObject.CompareTag("Trap"))
        {
            // W³¹czenie efektu dŸwiêkowego uœmiercenie obiektu gracza
            deathEffect.Play();
            // Wywo³anie metody uœmiercaj¹cej obiekt gracza
            Die();
        }
        // Je¿eli obiekt wywo³uj¹cy kolizjê to flaga
        if (collision.gameObject.CompareTag("Flag"))
        {
            // Zmienienie typu fizyki obiektu gracza
            body.bodyType = RigidbodyType2D.Static;
        }
    }
    
    /// <summary>
    /// Metoda uœmiercaj¹ca bohatera
    /// </summary>
    private void Die()
    {
        // W³¹czenie animacji œmierci
        anim.SetTrigger("death");
        // Zmienienie typu fizyki dla obiektu gracza
        body.bodyType = RigidbodyType2D.Static;
    }
    
    /// <summary>
    /// Metoda restartuj¹ca poziom
    /// </summary>
    private void restartLevel()
    {
        // Za³adowanie od nowa aktualnego poziomu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
