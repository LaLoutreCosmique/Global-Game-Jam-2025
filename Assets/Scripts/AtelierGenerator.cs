using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AtelierGenerator : MonoBehaviour
{
    private int _random;
    private int _atelierCount = 0;
    private Vector2 _positionToSpawn;
    [SerializeField] private List<GameObject> ateliers;
    [SerializeField] private List<GameObject> atelierAlreadySpawn;
    private float timer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AtelierSpawn();
        AtelierSpawn();
        AtelierSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 4f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            AtelierSpawn();
            if (_atelierCount == 6)
            {
                timer = 0f;
                Destroy(atelierAlreadySpawn[0]);
                for (int i = 0; i < _atelierCount-1; i++)
                {
                    atelierAlreadySpawn[i] = atelierAlreadySpawn[i + 1];
                }
                _atelierCount--;
            }
        }
        
        
        
    }

    private void AtelierSpawn()
    {
        _random = Random.Range(0, ateliers.Count);
        GameObject atelier = Instantiate(ateliers[_random], _positionToSpawn, Quaternion.identity);
        _positionToSpawn.y = _positionToSpawn.y + 2f;
        atelierAlreadySpawn.Add(atelier);
        _atelierCount++;
        
    }
}
