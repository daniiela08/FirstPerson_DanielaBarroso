
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP : MonoBehaviour
{
    [SerializeField] private float velocidadMov;
    private CharacterController controlador;
    
    void Start()
    {
        controlador = GetComponent<CharacterController>();
    }

    void Update()
    {
        
    }

}
