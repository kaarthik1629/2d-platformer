using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] musicsound;
    public Sfx[] sfxsound;
    public AudioSource musicsource,sfxsource;
    public static AudioManager instance;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    public void PlayMusic(string name)
    {
        Sounds sounds = Array.Find(musicsound, sounds => sounds.musicName == name);

        if (sounds == null) 
        {

            print("sounds not found");
        }
        else
        {
            musicsource.clip = sounds.musicClip;
            musicsource.Play();
        }
    }
    public void PlaySfx (string name) 
    {
        Sfx sfx = Array.Find(sfxsound,sounds => sounds.sfxName == name);

        if (sfx == null) 
        {
            print("sounds not found ");
        }
        else 
        {

            sfxsource.clip = sfx.sfxClip;
            sfxsource.Play();
        }

    }
}
