using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacciones : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distaciaInteract;
    private Transform interaccionActual;
    void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        DeteccionInteract();
    }

    private void DeteccionInteract()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distaciaInteract))
        {
            if (hit.transform.TryGetComponent(out boton scriptBoton))
            {
                interaccionActual = scriptBoton.transform;
                interaccionActual.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    scriptBoton.PulsarBoton();
                }
            }
        }
        else if (interaccionActual != null)
        {
            interaccionActual.GetComponent<Outline>().enabled = false;
            interaccionActual = null;
        }
    }
}