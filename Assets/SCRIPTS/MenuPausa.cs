using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] Canvas menuPausa;
    bool pausa;
    void Start()
    {
        menuPausa.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pausar();
        }
    }
    private void Pausar()
    {
        pausa = !pausa;
        Cursor.lockState = CursorLockMode.None;
        menuPausa.gameObject.SetActive(pausa);

        if (pausa)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void Seguir()
    {
        menuPausa.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
