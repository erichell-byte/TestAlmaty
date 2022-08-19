using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int _countOfCoinAndSpike;
    [SerializeField] private float _minPos;
    [SerializeField] private float _maxPos;
    [SerializeField] private GameObject spike;
    [SerializeField] private GameObject coin;

    public int CountCoinAndSpike => _countOfCoinAndSpike;
    
    private void Start()
    {
        SpawnObject(_countOfCoinAndSpike, spike);
        SpawnObject(_countOfCoinAndSpike, coin);
    }


    private void SpawnObject(int countObject, GameObject spawnObject)
    {
        for (int i = 0; i < countObject; i++)
        {
            Instantiate(spawnObject, GetRandomPosition(_minPos, _maxPos), spawnObject.transform.rotation);
        }
    }

    private Vector3 GetRandomPosition(float minCoord, float maxCoord)
    {
        Vector3 pos = new Vector3(Random.Range(minCoord, maxCoord), -0.5f, Random.Range(minCoord, maxCoord));
        return pos;
    }
}
