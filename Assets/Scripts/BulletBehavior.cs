using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float life = 3; // Deklaracja prywatnego pola i pobranie wartoœci d³ugoœci ¿ycia pocisku

    /// <summary>
    /// Metoda wywo³ywana automatycznie po utworzeniu b¹dŸ aktywowaniu obiektu
    /// </summary>
    private void Awake()
    {
        // Znisczenie pocisku po up³yniêciu czasu ¿ycia
        Destroy(gameObject, life);
    }
    /// <summary>
    /// Metoda wywo³ywana podczas napotkania kolizji
    /// </summary>
    /// <param name="collision">Odwo³anie do obiektu napotkanej kolizji</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Zniszczenie pocisku
        Destroy(gameObject);
    }
}
