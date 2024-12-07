using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentaculo : MonoBehaviour
{
    [SerializeField] private float da�oEnemigo;
    private FP player;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<FP>().RecibirDa�o(da�oEnemigo);
        }
    }
}
