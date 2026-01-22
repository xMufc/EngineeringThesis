using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu; // Deklaracja prywatnego pola o typie GameObject

    /// <summary>
    /// Metoda wywo³ywana automatycznie podczas tworzenia obiektu
    /// </summary>
    void Start()
    {
        // Wywo³anie metody ustawwiaj¹cej aktualny stan menu ustawieñ
        settingsMenu.SetActive(false);
    }

    /// <summary>
    /// Metoda w³¹czaj¹ca menu ustawieñ
    /// </summary>

    public void MenuActive()
    {
        // Wywo³anie metody ustawwiaj¹cej aktualny stan menu ustawieñ
        settingsMenu.SetActive(true);
        // Zatrzymanie rozgrywki
        Time.timeScale = 0;
    }

    /// <summary>
    /// Metoda wy³¹czaj¹ca menu ustawieñ
    /// </summary>

    public void MenuDeactive()
    {
        // Wywo³anie metody ustawwiaj¹cej aktualny stan menu ustawieñ
        settingsMenu.SetActive(false);
        // Wystartowanie rozgrywki
        Time.timeScale = 1;
    }
}
