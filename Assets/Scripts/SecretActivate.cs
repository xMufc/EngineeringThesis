using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class SecretActivate : MonoBehaviour
{
    [SerializeField] private GameObject map; // Deklaracja prywatnego pola o typie GameObject

    /// <summary>
    /// Metoda wywo³ywana automatycznie w momecie wyst¹penia kolizji
    /// </summary>
    /// <param name="collision">Odwo³anie do obiektu wywo³ywuj¹cego kolizjê</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ukrycie wygl¹du mapy bez sekretnego pomieszczenia
        map.GetComponent<TilemapCollider2D>().enabled = false;
        map.GetComponent<TilemapRenderer>().enabled = false;
        // Zniszczenie obiektu mapy bez sekretnego pomieszczenia
        Destroy(transform.gameObject);

    }
}
