using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    /// <summary>
    /// Metoda wywo³ywana podczas naciœniêcie przycisku wy³¹czeia gry
    /// </summary>
    public void Quit()
    {
        // Wy³¹czenie aplikacji
        Application.Quit();
    }
}
