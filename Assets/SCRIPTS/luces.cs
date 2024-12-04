using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luces : MonoBehaviour
{
    private Light lucecilla;
    void Start()
    {
        lucecilla = GetComponent<Light>();
        StartCoroutine(Parpadeo());
    }

  
    void Update()
    {
        
    }
    public IEnumerator Parpadeo()
    {
        while (true)
        {
            lucecilla.enabled = true;
            yield return new WaitForSeconds(0.2f);
            lucecilla.enabled = false;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
