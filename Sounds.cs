﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//..In order to show in the inspector
[System.Serializable]
public class Sounds
{
    public AudioClip clip;
    //..Creating a slider..
    [Range(0f, 0.1f)]

    //..Volume, esto puedo cambiarlo aquí para que se escuche mas duro.. 
    public float volume;
    [Range(.1f, 3.0f)]

    public float pitch;

    public string name;
    
    public bool loop;

    //..Hiding in Inspector
    [HideInInspector]
    public AudioSource source;

}