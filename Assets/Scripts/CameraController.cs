using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; // Deklaracja i pobranie odwo³ania do prywatnego obiektu Transform gracza

    /// <summary>
    /// Metoda uruchamiana automatycznie co klatkê 
    /// </summary>
    private void Update()
    {
        // Utworzenie wektora zawieraj¹cego aktualn¹ pozycjê
        Vector3 vec = new(player.position.x, transform.position.y, transform.position.z);
        // Zmiana pozycji kamery o liczbê odpowiadaj¹c¹ ruchowi gracza
        transform.position = CameraPosition(vec);
    }

    /// <summary>
    /// Metoda zwracaj¹ca zmienion¹ pozycjê kamery
    /// </summary>
    /// <param name="vec">Aktualna pozycja kamery</param>
    /// <returns>Nowa pozycja kamery</returns>

    public Vector3 CameraPosition(Vector3 vec)
    {
        // Zmienienie wspó³rzêdnej x kamery
        vec.x += 4f;
        // Zwrócenie nowej pozycji kamery
        return vec;
    }
}
