using System;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class Enemy : MonoBehaviour
    {
        public event Action<Enemy> EnemyDead;

        public void Die()
        {
            EnemyDead?.Invoke(this);
        }
    }
}

