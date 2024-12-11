using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaModuloInicio : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void AbrirPuerta()
    {
        anim.SetTrigger("Abrir");
    }
}
