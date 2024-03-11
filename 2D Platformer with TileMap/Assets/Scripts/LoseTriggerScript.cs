using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseTriggerScript : MonoBehaviour
{
    public TMP_Text output;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreManager.gameOver = true;
        };
    }
}
