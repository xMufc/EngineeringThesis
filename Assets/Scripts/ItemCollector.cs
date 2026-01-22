using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text strawberriesText; // Deklaracja i pobranie wartoœci dla prywatnego pola typu Text
    [SerializeField] private AudioSource collectEffect; // Deklaracja i pobranie wartoœci dla prywatnego pola typu AudioSource

    public static int strawberries = 0; // Deklaracja i inicjalizacja publicznego pola stanu truskawek
    private PlayerData data; // Deklaracja prywatnego pola typu PlayerData

    /// <summary>
    /// Metoda wywo³ywana automatycznie podczas tworzenia obiektu
    /// </summary>
    public void Start()
    {
        data = SaveSystem.LoadPlayer(); // Pobranie aktualnego stanu rozgrywki
        strawberries = data.strawberries; // Ustawienie aktualnego stanu truskawek
    }
    
    /// <summary>
    /// Metoda wywo³ywana automatycznie podczas wykrycia kolizji
    /// </summary>
    /// <param name="collision">Odwo³anie do obiektu wywo³uj¹cego kolizjê</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Je¿eli obiekt wywo³uj¹cy to truskawki
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            // W³¹czenie efektu dŸwiêkowego podniesienia truskawki
            collectEffect.Play();
            // Zniszczenie obiektu truskawki
            Destroy(collision.gameObject);
            // Powiêkszenie aktualnego stanu truskawej
            strawberries++;
            // Zaaktualizowanie napisu informuj¹cego o aktualnym stanie truskawek
            strawberriesText.text = "Truskawki: " + strawberries;
        }
        // Je¿eli obiekt wywo³uj¹cy to wiœnia
        if (collision.gameObject.CompareTag("Cherries"))
        {
            // Zniszczenie obiektu wiœni
            Destroy(collision.gameObject);
            // Pobranie aktualnego stanu rozgrywki
            data = SaveSystem.LoadPlayer();
            // Pobranie aktualnego stanu truskawek
            strawberries = data.strawberries;
            // Zaaktualizowanie napisu informuj¹cego o aktualnym stanie truskawek
            strawberriesText.text = "Truskawki: " + strawberries;
        }
    }
}

