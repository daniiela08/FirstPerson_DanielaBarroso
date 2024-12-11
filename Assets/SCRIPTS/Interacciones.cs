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
            if (hit.transform.TryGetComponent(out Caja scriptCaja))
            {
                interaccionActual = scriptCaja.transform;
                interaccionActual.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    scriptCaja.Abrir();
                }
            }
            if (hit.transform.TryGetComponent(out Coleccionable scriptColec))
            {
                interaccionActual = scriptColec.transform;
                interaccionActual.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    scriptColec.Destruir();
                }
            }
            if (hit.transform.TryGetComponent(out UFO scriptUfo))
            {
                interaccionActual = scriptUfo.transform;
                interaccionActual.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    scriptUfo.Ganar();
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
