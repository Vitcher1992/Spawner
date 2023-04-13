using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPoint;
    
    private Transform[] _points;

    private void Start()
    {
        CreatePoints();
        
        var spawner = CreateEnemy();
        StartCoroutine(spawner);
    }

    private void CreatePoints()
    {
        _points = new Transform[_spawnPoint.childCount];

        for (int i = 0; i < _spawnPoint.childCount; i++)
        {
            _points[i] = _spawnPoint.GetChild(i);
        }
    }

    private IEnumerator CreateEnemy()
    {
        int count = 10;
        float waitingTime = 2f;
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            Instantiate(_enemy, _points[random.Next(_points.Length)].position, Quaternion.identity);
            
            yield return new WaitForSeconds(waitingTime);
        }
    }
}