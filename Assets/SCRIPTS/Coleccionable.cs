using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    private FP player;
    [SerializeField] private int numeroObjetos;
    private void Start()
    {
        player = GameObject.FindObjectOfType<FP>();
    }
    public void Destruir()
    {
        player.GetComponent<FP>().ReceivePoints(numeroObjetos);
        Destroy(gameObject);
    }
}
