using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agente;
    private FP jugador;
    private Animator anim;

    private bool canDamage;

    Rigidbody[] huesos;

    [SerializeField] private float vidasEnemigo;

    public float VidasEnemigo { get => vidasEnemigo; set => vidasEnemigo = value; }

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        jugador = GameObject.FindObjectOfType<FP>();
        anim = GetComponent<Animator>();
        huesos = GetComponentsInChildren<Rigidbody>();

        ChangeJointsState(true);
    }
    void Update()
    {
        if (agente.enabled)
        {
            Seguir();
        }
    }
    private void Seguir()
    {
        agente.SetDestination(jugador.transform.position);
        if (!agente.pathPending && agente.remainingDistance <= agente.stoppingDistance)
        {
            agente.isStopped = true;
            anim.SetBool("isAttacking", true);
        }
    }
    private void ChangeJointsState(bool State)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = State;
        }
    }
    public void Dead()
    {
        ChangeJointsState(false);
        anim.enabled = false;
        agente.enabled = false;
        Destroy(gameObject, 15);
    }
}
