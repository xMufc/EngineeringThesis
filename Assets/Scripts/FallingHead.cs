using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingHead : MonoBehaviour
{
    [SerializeField] private GameObject[] heads; // Deklaruje i pobiera obiekty g³ów

    /// <summary>
    /// Funkcja wywo³ywana podczas wejœcia obiektu w kolizjê z obiektem posiadaj¹cym wyznaczon¹ kolizjê  
    /// </summary>
    /// <param name="collision">Obiekt z którym wyst¹pi³a kolizja</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pêtla po wszystkich obiektach g³ów
        foreach(GameObject head in heads)
        {
            // Zmienienie dla ka¿dej g³owy body type na dynamic, aby dzia³a³a na nie grawitacja
            head.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
