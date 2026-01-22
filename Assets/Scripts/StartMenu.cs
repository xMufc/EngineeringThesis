using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    /// <summary>
    /// Metoda wywo³ywana podczas naciœniêcia przycisku wystartowania rozgrywki od nowa
    /// </summary>
    public void StartGame()
    {
        // Wywo³anie metody i ustawienie pocz¹tkowych wartoœci stanu rozgrywki
        SaveSystem.SavePlayer(0, 1, 0.03f);
        // Za³adowanie pierwszego poziomu 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Metoda wywo³ywana podczas naciœniêcia przycisku wystartowania rozgrywki od ostatniego zapisu
    /// </summary>
    /// 
    public void ContinueGame()
    {
        // Za³adowanie poziomu z ostatniego zapisu
        SceneManager.LoadScene(SaveSystem.LoadPlayer().level);
    }
}
