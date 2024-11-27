using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private ArmaSO myData;
    private Camera cam;
    [SerializeField] private ParticleSystem particulas;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            particulas.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, myData.DistanciaAtaque))
            {
                if (hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    hitInfo.transform.GetComponent<ParteEnemigo>().ReceiveDamageEnemy(myData.DañoAtaque);
                }
            }
        }
    }
}
