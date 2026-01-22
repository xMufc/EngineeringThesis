using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;



public class ActivateButton : MonoBehaviour
{
    [SerializeField] private Button cont; // Deklaracja i pobranie wartoœci do prywatnego pola typu Button

    /// <summary>
    /// Metoda uruchamiana automatycznie w momencie uruchomienia obiektu
    /// </summary>
    void Start()
    {
        // Podanie œcie¿ki do pliku zapisu danych
        string path = Application.persistentDataPath + "/player.data";
        // Sprawdzenie czy plik istnieje
        if (File.Exists(path))
        {
            // Je¿eli istnieje, w³¹czenie przycisku "Kontynuuj"
            cont.interactable = true;
        }
    }

}
