using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UFO : MonoBehaviour
{
    [SerializeField] private FP mainScript;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Ganar()
    {
        if (mainScript.Puntos == 4)
        {
            SceneManager.LoadScene(2);
        }
    }
}