using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabEnemigo;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int rondas;
    [SerializeField] private int spawnxRonda;
    [SerializeField] private float esperaRondas;
    [SerializeField] private float esperaSpawns;
    void Start()
    {
        StartCoroutine(SpawnSystem());
    }
    void Update()
    {

    }
    private IEnumerator SpawnSystem()
    {
            for (int i = 0; i < rondas; i++)
            {
                for (int j = 0; j < spawnxRonda; j++)
                {
                    Instantiate(prefabEnemigo[Random.Range(0, prefabEnemigo.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

                    yield return new WaitForSeconds(esperaSpawns);
                }
                //actualizar texto ronda
                yield return new WaitForSeconds(esperaRondas);
            }
    }
}
