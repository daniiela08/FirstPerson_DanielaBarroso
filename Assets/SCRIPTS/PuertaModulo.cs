using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaModulo : MonoBehaviour
{
    private Animator anim;
    private MeshRenderer meshRenderer;
    private BoxCollider coll;

    private bool contando = false;
    [SerializeField] private Spawner spawner;
    private void Start()
    {
        anim = GetComponent<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();
        coll = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if(contando)
        {
            if(spawner.EnemigosPorMatar == 0)
            {
                Debug.Log("nohay");
                Abrir();
                
            }
        }
    }

    public void Cerrar()
    {
        meshRenderer.enabled = true;
        coll.isTrigger = false;
        spawner.gameObject.SetActive(true);
        //StartCoroutine(Parpadeo());
    }

    private void Abrir()
    {
        meshRenderer.enabled = false;
        coll.isTrigger = true;
        spawner.gameObject.SetActive(true);
        contando = false;
    }

    private void ActivarBool()
    {
        contando = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Cerrar();
            contando = true;
        }
    }
}
