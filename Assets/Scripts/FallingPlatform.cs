using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallDelay = 1f; // Deklaracja, inicjalizacja i pobranie prywatnego pola czasu, po którym spada plarforma
    [SerializeField] private float destroyDelay = 1f; // Deklaracja, inicjalizacja i pobranie prywatnego pola czasu, po którym znika platforma

    [SerializeField] private Rigidbody2D body; // Deklaracja i pobranie prywatnego obiektu RigidBody2D

    /// <summary>
    /// Metoda wywo³ywana podczas wykrywcia kolizji
    /// </summary>
    /// <param name="collision">Obiekt wywo³ywuj¹cy kolizjê</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Jezeli kolizjê wywo³a³ gracz
        if (collision.gameObject.CompareTag("Player"))
        {
            // Rozpoczêcie kurtyny spadania platformy
            StartCoroutine(Fall());
        }
    }

    /// <summary>
    /// Metoda powoduj¹ca opadanie i usuniêcie platformy
    /// </summary>
    /// <returns></returns>
    private IEnumerator Fall()
    {
        // Odczekanie czasu podanego, po którym spada platforma
        yield return new WaitForSeconds(fallDelay);
        // Zmienienie fizyki obiektu platformy na dyniamic
        body.bodyType = RigidbodyType2D.Dynamic;
        // Zniszczenie obiektu po up³yniêciu podanego czasu
        Destroy(gameObject, destroyDelay);
    }
}