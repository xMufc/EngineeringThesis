using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using static ItemCollector;
using static AudioSettings;

public class FinishLevel : MonoBehaviour
{

    private Animator anim; // Deklaracja prywatnego pola obiektu Animator
    public int level; // Deklaracja publciznego pola levela
    public string path; // Deklaracja publciznego pola œcie¿ki 

    /// <summary>
    /// Metoda uruchamiana automatycznie w momencie uruchomienia obiektu
    /// </summary>
    void Start()
    {
        // Pobranie wartoœci obiektu animacji
        anim = GetComponent<Animator>();
        // Ustawienie wartoœci pola œcie¿ki do miejsca zapisywania danych
        path = Application.persistentDataPath + "/player.data";
    }

    /// <summary>
    /// Metoda wywo³ywana podczas wyst¹pienia kolizji
    /// </summary>
    /// <param name="collision">Obiekt wywo³ywuj¹cy kolizjê</param>

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Je¿eli kolizjê wywo³a³ gracz
        if(collision.gameObject.name == "Player")
        {
            // Rozpoczêcie animiacji flagi, koñcz¹cej poziom
            anim.SetTrigger("finish");
        }
    }


    /// <summary>
    /// Metoda zmieniaj¹ca aktualny poziom
    /// </summary>
    private void ChangeLevel()
    {
        // Powiekszênie wartoœci pola aktualnego poziomu o 1
        level = SceneManager.GetActiveScene().buildIndex + 1;
        // Je¿eli podniesiona wartoœæ jest mniejsza od iloœci wszystkich poziomów
        if(level < (SceneManager.sceneCountInBuildSettings - 1))
        {
            // Pobranie i wywo³anie metody zapisuj¹cej stan rozgrywki
            SaveSystem.SavePlayer(ItemCollector.strawberries, level, AudioSettings.musicValue);
        }
        // Je¿eli jest wiêksza/równa iloœci wszystkich poziomów
        else
        {
            // Je¿eli istnieje plik zapisu danych
            if (File.Exists(path))
            {
                // Usuniêcie pliku zapisu
                File.Delete(path);
            }
        }
        // Zmienienie poziomu na kolejny
        SceneManager.LoadScene(level);
    }
}
