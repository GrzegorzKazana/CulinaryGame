using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SetVolume : MonoBehaviour
{
    public AudioMixer _audioMixer;

    public void SetLevel(float sliderValue)
    {
        Console.WriteLine("asd");
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue)*20);
    }
}
