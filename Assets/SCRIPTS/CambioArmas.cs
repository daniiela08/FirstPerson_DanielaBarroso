using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioArmas : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;
    //recoge indice arma actual.
    private int armaActual;
    void Start()
    {

    }
    void Update()
    {
        CambioArmasTeclado();
        CambioArmasRaton();

    }

    private void CambioArmasRaton()
    {
        float ruedaRaton = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;

        if (ruedaRaton > 0)
        {
            CambiarArma(armaActual + 1);
        }
        else if (ruedaRaton < 0)
        {
            CambiarArma(armaActual - 1);
        }
    }

    private void CambioArmasTeclado()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambiarArma(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            CambiarArma(1);
        }
    }

    private void CambiarArma(int nuevaArma)
    {
        //desactivar arma actual.
        armas[armaActual].SetActive(false);

        //si el indice es negativo.
        if (nuevaArma < 0)
        {
            //indice es el ultimo de la lista
            nuevaArma = armas.Length - 1;
        }
        else if (nuevaArma > armas.Length)
        {
            nuevaArma = 0;
        }

        //activar nueva arma.
        armas[nuevaArma].SetActive(true);

        armaActual = nuevaArma;
    }
}
