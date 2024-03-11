using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    bool active = true;

    [SerializeField] private AudioClip thisTriggered;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            active = false;
            ScoreManager.score++;
            SoundFXManager.instance.PlaySoundFXCLip(thisTriggered, transform, 1f);
            gameObject.SetActive(false);
        }
    }
}
