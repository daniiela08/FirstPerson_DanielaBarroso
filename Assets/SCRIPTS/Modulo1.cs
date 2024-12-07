using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modulo1 : MonoBehaviour
{
    private AudioSource musica;
    void Start()
    {
        musica = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            musica.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            musica.enabled = false;
        }
    }
}
