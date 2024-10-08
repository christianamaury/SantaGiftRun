﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System; 

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; set;}

    //An array of Sounds
    public Sounds[] sounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //If not, we're already have one destroy it..
        else
        {
            Destroy(gameObject); return;
        }

        //When Loading into a new Scene don't destroy this game object
        DontDestroyOnLoad(gameObject);


        //..For each sounds in the array.. add a component
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Play theme music.., Call method down here..
        Play("ThemeChristmas");
    }

    public void Play (string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("There's no song under this name..");
        }
        else
        {
            //Play the Song..
            s.source.Play();
        }

    }

    //Function to stop playing audio;
    public void Stop(string name) {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            //..No audio under that nama;
            return;
        }

        //Stop the audio if it's actually playing;
        if (s.source.isPlaying)
        {
            s.source.Stop();
        }
    }

    //Function to check if Audio is already Playing;
    public bool isPlaying (string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            //..No audio under that nama;
            return false;
        }

        //Return Value;
        return s.source.isPlaying;
    }
}
