using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    /// <summary>
    /// Play a specifc audio clip
    /// </summary>
    /// <param name="audioClip"></param>
    /// <param name="spawnTransform"></param>
    /// <param name="volume"></param>
    public void PlaySoundFXCLip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign the audioClip
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get lenth of sound FX clip
        float clipLength = audioSource.clip.length; 

        //destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }
    /// <summary>
    /// Cycles through a given array of AudioClips to randomly play
    /// </summary>
    /// <param name="audioClip"></param>
    /// <param name="spawnTransform"></param>
    /// <param name="volume"></param>
    public void PlayRandSoundFXCLip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        //assign a random index
        int rand = Random.Range(0, audioClip.Length);
        //spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign the audioClip
        audioSource.clip = audioClip[rand];

        //assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get lenth of sound FX clip
        float clipLength = audioSource.clip.length;

        //destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }
}
