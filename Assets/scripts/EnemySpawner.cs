using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI EnemyPrefab;
    public PlayerController player;
    public List<Transform> patrolPoints; 
    public lvlPlayer lvlPlayer;


    public int EnemysMax = 5;
    public float delay = 5;
    
    private EnemyAI _enemiesAI;
    private float _timeLastSpawned;

    private List<Transform> _spawnerPoints;

    private List<EnemyAI> _enemies;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemies = new List<EnemyAI>();
    }

    private void Update()
    {
        for(var i = 0; i <_enemies.Count; i++)
        {
            if (_enemies[i].IsAlive()) continue;
            _enemies.RemoveAt(i);
            i--;
        }
        if (_enemies.Count >= EnemysMax) return;

        if (Time.time - _timeLastSpawned < delay) return;

        CreateEnemy();
    } 

    private void CreateEnemy()
    {
        var enemy = Instantiate(EnemyPrefab);
        enemy.transform.position = _spawnerPoints[Random.Range(0,_spawnerPoints.Count)].position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        _enemies.Add(enemy);
        _timeLastSpawned = Time.time;
        enemy.lvlPlayer = lvlPlayer;
    }
}
