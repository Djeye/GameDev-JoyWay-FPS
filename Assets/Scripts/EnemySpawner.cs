using System;
using joyway.Enemy;
using joyway.Player;
using UnityEngine;

namespace joyway
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Scarecrow enemy;
        [SerializeField] private InputManager inputManager;

        private void Start()
        {
            inputManager.RespawnEvent += SpawnNewEnemy;
        }

        private void SpawnNewEnemy()
        {
            enemy.ResetEnemy();
        }

        private void OnDisable()
        {
            inputManager.RespawnEvent -= SpawnNewEnemy;
        }
    }
}