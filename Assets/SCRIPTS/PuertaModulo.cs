using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaModulo : MonoBehaviour
{
    private Animator anim;
    private MeshRenderer obj;
    private void Start()
    {
        anim = GetComponent<Animator>();
        obj = GetComponent<MeshRenderer>();
    }
    public void Cerrar()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Cerrar();
    }
}
