using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] points; // Deklaracja i pobranie prywatnej tablicy punktów
    private int actualPoint = 0; // Deklaracja i inicjalizacja prywatnego pola aktualnego punktu

    [SerializeField] private float speed = 2f; // Deklaracja, inicjalizacja i pobranie prywatnego pola prêdkoœci


    /// <summary>
    /// Metoda wywo³ywana automatycznie co klatkê
    /// </summary>
    private void Update()
    {
        // Je¿eli obiekt znajduje siê w punkcie docelowym
        if(DistanceToPoint(points[actualPoint].transform.position, transform.position) < 0.1f)
        {
            // Powiêkszenie aktualnego punktu
            actualPoint++;
            // Je¿eli aktualny punkt jest równy iloœci wszystkich punktu
            if(actualPoint == points.Length)
            {
                // Wyzerowanie aktualnego punktu
                actualPoint = 0;
            }
        }
        // Poruszenie siê obiektu w kierunku aktualnego punktu
        transform.position = Vector2.MoveTowards(transform.position, points[actualPoint].transform.position, Time.deltaTime * speed);
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
