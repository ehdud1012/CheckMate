using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;

    [Header("Audio Clip")]//음향추가
    public AudioClip Background;

    private void Start()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }
}
