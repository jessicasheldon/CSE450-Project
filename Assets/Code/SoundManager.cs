using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code{

}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource audioSource;
    public AudioClip winSound;

    void Awake()
    {
        instance = this;
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWinSound(){
        audioSource.PlayOneShot(winSound);
    }

}
