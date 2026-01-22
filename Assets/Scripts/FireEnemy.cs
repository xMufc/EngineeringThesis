using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour
{
    [SerializeField] private GameObject FireOffImage; // Deklaracja i pobranie odwo³ania do obiektu pojemnika bez ognia
    [SerializeField] private GameObject FireOnImage; // Deklaracja i pobranie odwo³ania do obiektu podpalonego pojemnika

    /// <summary>
    /// Metoda gasz¹ca p³omieæ
    /// </summary>
    private void FireOff()
    {
        FireOffImage.GetComponent<BoxCollider2D>().enabled = true; // W³¹czenie kolizja dla pojemnika bez ognia
        FireOnImage.GetComponent<BoxCollider2D>().enabled = false; // Wy³¹czenie kolizja dla pojemnika z ogniem
    }
    
    /// <summary>
    /// Metoda zapalaj¹ca p³omieñ 
    /// </summary>
    private void FireOn()
    {
        FireOffImage.GetComponent<BoxCollider2D>().enabled = false; // Wy³¹czenie kolizja dla pojemnika bez ogniem
        FireOnImage.GetComponent<BoxCollider2D>().enabled = true; // W³¹czenie kolizja dla pojemnika z ogniem
    }

}
