using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn;  // Deklaracja i pobranie odwo³ania do prywatnego pola o typie Transform
    [SerializeField] private GameObject bulletImage; // Deklaracja i pobranie odwo³ania do prywatnego pola o typie GameObject
    [SerializeField] private int speed = 10; // Deklaracja, inicjalizacja i pobranie wartoœci do prywatnego pola prêdkoœci pocisków

    /// <summary>
    /// Metoda wywo³ywana podczas wystrzeliwania pocisku
    /// </summary>
    private void shoot()
    {
        // Utworzenie obiektu pocisku
        var bullet = Instantiate(bulletImage, bulletSpawn.position, bulletSpawn.rotation);
        // Nadaniae pociskowi prêdkoœci
        bullet.GetComponent<Rigidbody2D>().velocity = ((-1) * bulletSpawn.right) * speed;
    }
}
