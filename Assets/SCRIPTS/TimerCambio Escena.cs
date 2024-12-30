using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerCambioEscena : MonoBehaviour
{
    private float timer = 0f;
    void Start()
    {
        
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 4.5f)
        {
            SceneManager.LoadScene(4);
        }
    }
}
