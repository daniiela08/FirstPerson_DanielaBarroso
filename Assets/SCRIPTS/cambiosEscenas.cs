using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiosEscenas : MonoBehaviour
{
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject menuOpciones;
    public void Jugas()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void EscenaMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void MenuOpciones()
    {
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(true);
    }
    public void MenuPrincipal()
    {
        menuPrincipal.SetActive(true);
        menuOpciones.SetActive(false);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
