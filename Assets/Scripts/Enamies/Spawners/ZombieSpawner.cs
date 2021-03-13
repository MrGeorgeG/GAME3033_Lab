using System.Collections;
using System.Collections.Generic;
using Enemies.Spawners;
using UnityEngine;

namespace Enemies.Spawners
{
    public class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private int NumberOfZombiesToSpawn;

        [SerializeField] private GameObject[] ZombiePrefabs;

        [SerializeField] private SpawnerVolunes[] SpawnerVolunes;

        private GameObject FollowGameObject;
        // Start is called before the first frame update
        void Start()
        {
            FollowGameObject = GameObject.FindGameObjectWithTag("Player");
            for (int zombieCount = 0; zombieCount < NumberOfZombiesToSpawn; zombieCount++)
            {
                SpawnerZombie();
            }
        }

        private void SpawnerZombie()
        {
            GameObject zombieToSpawn = ZombiePrefabs[Random.Range(0, ZombiePrefabs.Length)];
            SpawnerVolunes spawnerVolunes = SpawnerVolunes[Random.Range(0, SpawnerVolunes.Length)];

            GameObject zombie = Instantiate(zombieToSpawn, spawnerVolunes.GetPositionInBounds(), spawnerVolunes.transform.rotation);

            zombie.GetComponent<ZombieComponent>().Initialize(FollowGameObject);
        }

    }
}

