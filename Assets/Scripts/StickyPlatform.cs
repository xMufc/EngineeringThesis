using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    /// <summary>
    /// Metoda wywo³ywania automatycznie podczas wykrycia kolizji
    /// </summary>
    /// <param name="collision">Odwo³anie do obiektu wywo³uj¹cego kolizjê</param>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Je¿eli obiekt wywo³uj¹cy kolizjê to gracz
        if (collision.gameObject.name == "Player")
        {
            // Ustawienie rodzica kolizji na obiekt gracza
            collision.gameObject.transform.SetParent(transform);
        }
    }

    /// <summary>
    /// Metoda wywo³ywania automatycznie podczas wyjœcia innego obiektu z obszaru kolizji
    /// </summary>
    /// <param name="collision">Odwo³anie do obiektu opuszczaj¹cego kolizjê</param>

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Je¿eli obiekt opuszczaj¹cy kolizjê to gracz
        if (collision.gameObject.name == "Player")
        {
            // Usuniêcie rodzica kolizji na obiekt gracza
            collision.gameObject.transform.SetParent(null);
        }
    }
}
