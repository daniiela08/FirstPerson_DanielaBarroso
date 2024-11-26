using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Arma")]
public class ArmaSO : ScriptableObject
{
    public int MunicionMax;
    public int MunicionRecamara;
    public float DistanciaAtaque;
    public float DañoAtaque;
}
