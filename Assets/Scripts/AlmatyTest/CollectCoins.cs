using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private GameObject victoryScreen;
    private int _score;
    

    private void Start()
    {
        _score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            _score++;
            _scoreText.text = _score.ToString();
            Destroy(other.gameObject);
            if (_score == spawnManager.CountCoinAndSpike)
                victoryScreen.SetActive(true);

        }
    }
}
