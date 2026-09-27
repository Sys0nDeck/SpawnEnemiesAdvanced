using System;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class Enemy : MonoBehaviour
    {
        public event Action<Enemy> OnDead;

        public void Die()
        {
            OnDead?.Invoke(this);
        }
    }
}

