using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField] private Transform EnemySpawn; // Deklaracja i pobranie wartoœci prywantego pola typu Transform
    [SerializeField] private GameObject EnemyImage = null; // Deklaracja, inizjalizacja i pobranie wartoœci prywantego pola typu GameObject


    /// <summary>
    /// Metoda wywo³ywana automatycznie w momencie wyst¹pienia kolizji
    /// </summary>
    /// <param name="collision">Odwo³anie do obiektu wywo³uj¹cego kolizjê</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Je¿eli obiekt wywo³uj¹cy kolizjê to gracz
        if (collision.gameObject.name == "Player")
        {
            // Utworzenie nowego obiektu przeciwnika
            Instantiate(EnemyImage, EnemySpawn.position, EnemySpawn.rotation);
            // Zniszczenie poprzedniego obiektu przeciwnika
            Destroy(transform.parent.gameObject);
        }
    }

}
