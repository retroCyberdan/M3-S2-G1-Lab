using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    int playerCounter = 0;
    int playerQuantity;

    public void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        playerQuantity = players.Length;
    }

    //Uso la classe "OnTriggerEnter2D" passandogli come parametro un "Collider2D"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //controllo se il collider è il Player, per evitare che se un nemico triggeri finisca il gioco.
        //Uso la Funzione "CompareTag" alla quale passo la stringa del tag assegnato al Player
        //(RICORDARSI DI ASSEGNARNE UNO AL PLAYER E DI FORNIRE QUEL TAG COME VALORE ALLA FUNZIONE!)
        if(collision.CompareTag($"Player"))
        {
            //Debug.Log($"Livello completato!");
            playerCounter++;
            PlayerCounter();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag($"Player"))
        {
            //Debug.Log($"Livello completato!");
            playerCounter--;
        }
    }

    private void PlayerCounter()
    {
        if (playerCounter == playerQuantity)
        {
            Debug.Log($"Livello completato!");
        }
        else
        {
            Debug.Log($"Non siete tutti! Manca ancora qualcuno!");
        }
    }
    
}
