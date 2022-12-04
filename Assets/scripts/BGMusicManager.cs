using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicManager : MonoBehaviour
{
    public static bool bgMusicPlaying;
    public void Awake()
    {
        if (!bgMusicPlaying)
        {
            bgMusicPlaying = true;
            gameObject.GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
