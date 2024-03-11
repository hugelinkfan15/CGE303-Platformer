using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    //set this refrence to the inspector
    public TMP_Text output;

    public string textToDisplay;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            output.text = textToDisplay;
        }
    }
}
