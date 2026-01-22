using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    /// <summary>
    /// Metoda zapisuj¹ca stan rozgrywki
    /// </summary>
    /// <param name="item">Iloœæ truskawek</param>
    /// <param name="lvl">Aktualny poziom</param>
    /// <param name="value">Gloœnoœæ muzyki</param>
    public static void SavePlayer (int item, int lvl, float value)
    {
        // Inicjalizacja obiektu BinaryFormatter
        BinaryFormatter formatter = new();
        // Ustawienie œcie¿ki do zapisu danych
        string path = Application.persistentDataPath + "/player.data";
        // Utworzenie strumienia do zapisu danych w danej œcie¿ce w trybie tworzenia nowego pliku, b¹dŸ nadpisywania ju¿ istniej¹cego
        FileStream stream = new(path, FileMode.Create);
        // Utworzenie nowego obiektu i zainicjalizowanie go za pomoc¹ konstruktora
        PlayerData data = new(item, lvl, value);
        // Serializacja danych
        formatter.Serialize(stream, data);
        // Zamkniêcie strumienia do zapisywania danych
        stream.Close();
    }

    /// <summary>
    /// Pobranie danych o aktualnym stanie rozgrywki
    /// </summary>
    /// <returns>Zbiór danych w przypadku istniej¹cego pliku, b¹dŸ null w przypadku jego braku</returns>
    public static PlayerData LoadPlayer()
    {
        // Ustawienie œcie¿ki do zapisu danych
        string path = Application.persistentDataPath + "/player.data";
        // Sprawdzenie czy plik istneje
        if (File.Exists(path))
        {
            // Inicjalizacja obiektu BinaryFormatter
            BinaryFormatter formatter = new();
            // Utworzenie strumienia do odczytu danych w danej œcie¿ce w trybie czytania
            FileStream stream = new(path, FileMode.Open);
            // Deserializacja danych
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            // Zamkniêcie strumienia do odczytywania danych
            stream.Close();
            //Zwrócenie zbioru danych
            return data;
        }
        // Gdy nie istnieje
        else
        {
            // Wyrzucenie w konsoli b³êdu
            Debug.Log("File not found");
            // Zwrócenie null
            return null;
        }
    }
}
