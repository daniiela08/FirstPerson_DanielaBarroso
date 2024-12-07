using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garra : MonoBehaviour
{
    [SerializeField] private Transform puntoAtaque;
    [SerializeField] private float radioDet;
    [SerializeField] private LayerMask queesdañable;
    [SerializeField] private float dañoEnemigo;
    private bool canDamage;
    void Start()
    {
        
    }
    void Update()
    {
        if (canDamage == true) 
        {
            DetectImpact();
        }
    }
    private void DetectImpact()
    {
        Collider[] collsdetectadas = Physics.OverlapSphere(puntoAtaque.position, radioDet, queesdañable);
        if (collsdetectadas.Length > 0)
        {
            for (int i = 0; i < collsdetectadas.Length; i++)
            {
                collsdetectadas[i].GetComponent<FP>().RecibirDaño(dañoEnemigo);
            }
            canDamage = false;
        }
    }
}
