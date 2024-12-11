using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton : MonoBehaviour
{
    private Animator anim;
    [SerializeField] PuertaModuloInicio scriptP;
    [SerializeField] Spawner spawner;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void PulsarBoton()
    {
        anim.SetTrigger("pulsar");
        scriptP.AbrirPuerta();
        spawner.gameObject.SetActive(true);
    }
}
