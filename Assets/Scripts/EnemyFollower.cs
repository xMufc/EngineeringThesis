using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] points; // Pobranie odwo³ania do tablicy obiektów punktów, pomiêdzy którymi przemieszczaæ ma siê obiekt
    private int actualPoint = 0; // Deklaracja i inicjalizacja pola aktualnego punktu

    [SerializeField] private float speed = 2f; // Deklaruje, inicjalizuje i pobiera wartoœæ prêdkoœci poruszania siê 

    /// <summary>
    /// Metoda uruchamiana automatycznie co klatkê
    /// </summary>
    private void Update()
    {
        // Sprawdzenie czy gracz znajdujê siê w pozycji aktualnego punktu
        if (DistanceToPoint(points[actualPoint].transform.position, transform.position) < 0.1f)
        {
            // Powiêkszenie wartoœci aktualnego punktu
            actualPoint++;
            // Je¿eli aktualna wartoœæ jest równ¹ iloœci punktów
            if (actualPoint == points.Length)
            {
                // Powrót do pierwszego punktu
                actualPoint = 0;
            }
            // Obrócenie obiektu o 180 stopni
            transform.Rotate(0f, 180f, 0f);
        }
        // Poruszenie siê obiektu w kierunku aktualnego punktu
        transform.position = Vector2.MoveTowards(transform.position, points[actualPoint].transform.position, SpeedInTime(speed, Time.deltaTime));
    }

    /// <summary>
    /// Metoda obliczaj¹ca prêdkoœæ poruszania siê obiektu
    /// </summary>
    /// <param name="speed">Wartoœæ prêdkoœci</param>
    /// <param name="time">Wartoœæ czasu, który up³yn¹³ od ostatniego cyklu</param>
    /// <returns>Zwrócenie prêdkoœci</returns>
    public float SpeedInTime(float speed, float time)
    {
        // Zwrócenie prêdkoœci
        return speed * time;
    }

    /// <summary>
    /// Metoda zwracaj¹ca dystans miedzy punktami
    /// </summary>
    /// <param name="destination">Wspo³rzêdne punktu przeznaczenia</param>
    /// <param name="actual">Wspo³rzêdne aktualne</param>
    /// <returns>Dystans miêdzy punktami</returns>
    public float DistanceToPoint(Vector2 destination, Vector2 actual)
    {
        return Vector2.Distance(destination, actual);
    }
}
