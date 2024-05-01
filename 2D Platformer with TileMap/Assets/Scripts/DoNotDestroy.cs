using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Lets an object persist inbetween scenes with being destroyed(This one only works on objects with the "Game Music" tag)
/// </summary>
public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Game Music");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
