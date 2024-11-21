using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParteEnemigo : MonoBehaviour
{
    [SerializeField] private Enemigo mainScript;
    [SerializeField] private float multiplicadorDaño;

    public void ReceiveDamageEnemy(float attackReceive)
    {
        mainScript.VidasEnemigo -= attackReceive * multiplicadorDaño;
        if (mainScript.VidasEnemigo <= 0)
        {
            mainScript.Dead();
        }
    }
}
