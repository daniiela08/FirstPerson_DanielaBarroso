using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private ArmaSO myData;
    private Camera cam;

    private Animator anim;
    private AudioSource espada;
    void Start()
    {
        cam = Camera.main;
        anim = GetComponent<Animator>();
        espada = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            espada.Play();
            anim.SetTrigger("Ataque");
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, myData.DistanciaAtaque))
            {
                if (hitInfo.transform.TryGetComponent(out ParteEnemigo parteEnemigoScript))
                {
                    //quien ha impactado, entrar a su script, hacerle el daño del scriptable.
                    parteEnemigoScript.ReceiveDamageEnemy(myData.DañoAtaque);
                }
            }
        }
    }
}
