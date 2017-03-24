using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;


namespace Assets.Scripts
{
  public class SpiderSpawner : MonoBehaviour
  {
    private int _spidersToSpawn;
    private int _spidersSpawned;
    private bool _spawning;
    private float _lastSpawned;

    public GameObject Prefab;

    private readonly string[] TARGETS = new string[] { "Bed", "wardrobe", "door", "bedside drawers"};
    private readonly Vector3[] SPAWN_POSITIONS = new Vector3[]
    {
      new Vector3(-17.88f, -0.45f, -6.65f), // under bed
      new Vector3(-5.96f, -0.45f, -8.78f), // under barrel
      new Vector3(16.05f, -0.45f, 11.34f), // under door
      new Vector3(4.53f, -0.45f, 7.25f), // under table
    };

    void Start()
    {
      StartSpawning();
    }

    void StartSpawning()
    {
      _spidersToSpawn = Random.Range(2, 5);
      _spawning = true;
    }

    void Update()
    {
      if (_spidersSpawned < _spidersToSpawn)
      {
        if (_lastSpawned + 0.5 < Time.time)
        {
          SpawnSpider();
          _spidersSpawned++;
        }
      }
      else
      {
        _spawning = false;
      }
    }

    void SpawnSpider()
    {
      Vector3 spawnPosition = SPAWN_POSITIONS[Random.Range(0, SPAWN_POSITIONS.Length - 1)];

      GameObject spider = Instantiate(Prefab, spawnPosition, new Quaternion());
      spider.GetComponent<MoveToTargetController>().setTarget(
        GameObject.Find(
          TARGETS[Random.Range(0, TARGETS.Length - 1)]
        )
      );

      _lastSpawned = Time.time;
    }
  }
}