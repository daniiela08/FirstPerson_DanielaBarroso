using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musica;
    [SerializeField] AudioSource sfx;

    public static AudioManager audioManager;

    //single-ton
    private void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;
            DontDestroyOnLoad(audioManager);
        }
        else
        {
            Destroy(audioManager);
        }

    }

    void Start()
    {

    }
    void Update()
    {

    }
    public void ReproducirSFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
}
