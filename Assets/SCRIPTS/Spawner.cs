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

    private int enemigosASpawnear;
    private int enemigosPorMatar;

    public int EnemigosPorMatar { get => enemigosPorMatar; set => enemigosPorMatar = value; }

    private void Awake()
    {
        enemigosASpawnear = spawnxRonda * rondas; //10
        enemigosPorMatar = enemigosASpawnear; //10
        
    }
    void Start()
    {
        Debug.Log("Empiezo a spawnear");
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
                    GameObject copiaEnemigo = Instantiate(prefabEnemigo[Random.Range(0, prefabEnemigo.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                    copiaEnemigo.GetComponent<Enemigo>().MiSpawner = this;
                    yield return new WaitForSeconds(esperaSpawns);
                }
                //actualizar texto ronda
                yield return new WaitForSeconds(esperaRondas);
            }
    }
}
