using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaModulo : MonoBehaviour
{
    private Animator anim;
    private MeshRenderer meshRenderer;
    private BoxCollider coll;

    [SerializeField] private Spawner spawner;
    private void Start()
    {
        anim = GetComponent<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();
        coll = GetComponent<BoxCollider>();
    }
    public void Cerrar()
    {
        meshRenderer.enabled = true;
        coll.isTrigger = false;
        spawner.gameObject.SetActive(true);
        //StartCoroutine(Parpadeo());
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Cerrar();
        }
    }
}
