using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agente;
    private FP jugador;
    private Animator anim;
    private Spawner miSpawner;

    private bool OpenWindow;
    [SerializeField] private Transform puntoAtaque;
    [SerializeField] private float radioDet;
    [SerializeField] private LayerMask queesdañable;
    [SerializeField] private float dañoEnemigo;
    private bool canDamage, isDead;

    Rigidbody[] huesos;

    [SerializeField] private float vidasEnemigo;

    public float VidasEnemigo { get => vidasEnemigo; set => vidasEnemigo = value; }
    public Spawner MiSpawner { get => miSpawner; set => miSpawner = value; }

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
        if (OpenWindow && canDamage)
        {
            DetectImpact();
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
            huesos[i].useGravity = State;
        }
    }
    public void Dead()
    {
        if(!isDead)
        {
            ChangeJointsState(false);
            anim.enabled = false;
            agente.enabled = false;
            miSpawner.EnemigosPorMatar--;
            isDead = true;
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
    private void FinAtaque()
    {
        agente.isStopped = false;
        anim.SetBool("isAttacking", false);
        canDamage = true;
    }
    private void abrirVentana()
    {
        OpenWindow = true;
    }
    private void cerrarVentana()
    {
        OpenWindow = false;
    }
}
