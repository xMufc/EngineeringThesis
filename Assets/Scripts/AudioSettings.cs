using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private GameObject music; // Deklaracja i pobranie wartoœci do prywatnego pola typu GameObject
    [SerializeField] private Slider musicSlider; // Deklaracja i pobranie wartoœci do prywatnego pola typu Slider
    public static float musicValue = 5; // // Deklaracja i inicjalizacja wartoœci do publicznego pola muzyki

    private PlayerData data; // Deklaracja publicznego pola typu PlayerData

    /// <summary>
    /// Metoda uruchamiana automatycznie w momencie uruchomienia obiektu
    /// </summary>
    void Start()
    {
        // Pobranie aktualnego stanu rozgrywki
        data = SaveSystem.LoadPlayer();
        // Przypisanie poziomu g³oœnoœci do pola
        musicValue = data.musicValue;
        // Ustawienie poziomu g³oœnoœci w komponencie muzyki, ówczeœnie wybranego przez gracza 
        music.GetComponent<AudioSource>().volume = musicValue;
        // Ustawienie poziomu g³oœnoœci na sliderze ówczeœnie wybranego przez gracza 
        musicSlider.value = musicValue;
    }

    /// <summary>
    /// Metoda wywo³ywana podczas zmiany g³oœnoœci
    /// </summary>
    public void SetVolume()
    {
        // Zapisanie zmienionej wartoœci poziomu g³oœnoœci
        SaveSystem.SavePlayer(data.strawberries, data.level, AudioSettings.musicValue);
        // Ustawienie nowego poziomu g³oœnoœci na sliderze 
        musicValue = musicSlider.value;
        // Ustawienie nowego poziomu g³oœnoœci w komponencie muzyki
        music.GetComponent<AudioSource>().volume = musicValue;
    }
    
}
