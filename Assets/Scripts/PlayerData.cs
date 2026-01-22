using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int strawberries; // Deklaracja publicznego pola zawieraj¹cego iloœæ truskawek
    public int level; // Deklaracja publicznego pola zawieraj¹cego aktualny poziom
    public float musicValue; // Deklaracja publicznego pola zawieraj¹cego aktualny poziom g³oœnoœci muzyki

    /// <summary>
    /// Konstruktor klasy PlayerData
    /// </summary>
    /// <param name="items">Iloœæ truskawek</param>
    /// <param name="lvl">Aktualny poziom</param>
    /// <param name="value">Aktualny poziom g³oœnoœci muzyki</param>
    public PlayerData(int items, int lvl, float value)
    {
        // Przypisanie iloœci truskawek
        strawberries = items;
        // Przypisanie aktualnego poziomu
        level = lvl;
        // Przypisanie aktualnego poziomu g³oœcnoœci muzyki
        musicValue = value;
    }
}
