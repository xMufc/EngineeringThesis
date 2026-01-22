using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 1f;  // Deklaracja, inicjalizacja i pobranie prywatnego pola prêdkoœci

    /// <summary>
    /// Metoda wywo³ywana automatycznie co klatkê
    /// </summary>
    void Update()
    {
        // Zmienienie w³asnoœci rotacji obiektu o dan¹ iloœæ stopni
        transform.Rotate(0, 0, RotateAngle(speed, Time.deltaTime));
    }

    /// <summary>
    /// Metoda obliczaj¹ca iloœæ stopni obrotu 
    /// </summary>
    /// <param name="speed">Prêdkoœæ obrotu</param>
    /// <param name="time">Wartoœæ czasu, który up³yn¹³ od ostatniego cyklu</param>
    /// <returns>Stopnie obrotu</returns>
    public float RotateAngle(float speed, float time)
    {
        // Zwrócenie wartoœci stopni, o które ma obróciæ siê obiekt
        return -360 * speed * time;
    }
}
