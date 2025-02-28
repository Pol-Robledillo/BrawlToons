using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignVolume : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
}
