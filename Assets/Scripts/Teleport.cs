using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField] private Transform destination; // Pobranie pola przeznaczenia, do które ma zostaæ przeteleportowany obiekt gracza
    /// <summary>
    /// Metoda zwracaj¹ odwo³anie do pola przeznaczenia
    /// </summary>
    /// <returns>Obiekt pola przeznacznia</returns>
    public Transform GetDestination()
    {
        // Zwrócenie odwo³ania do obiektu pola przeznaczenia
        return destination;
    }
}
