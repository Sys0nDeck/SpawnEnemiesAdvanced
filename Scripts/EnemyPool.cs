using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class EnemyPool : MonoBehaviour
    {
        private List<Enemy> _enemies;
        private int _maxSize = 15;

        private void Awake()
        {
            _enemies = new List<Enemy>();
        }

        public Enemy Get(Enemy enemyPrefab)
        {
            return FindAvaiableEnemy(enemyPrefab);
        }

        public void Repease(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
        }

        private Enemy Create(Enemy enemy)
        {
            if (_enemies.Count == _maxSize)
                return null;

            var newEnemy = Instantiate(enemy);
            newEnemy.gameObject.SetActive(false);
            _enemies.Add(newEnemy);

            return newEnemy;
        }

        private Enemy FindAvaiableEnemy(Enemy enemyPrefab)
        {
            var findedEnemies = _enemies.FindAll(enemy => enemy.Id == enemyPrefab.Id);

            foreach (var enemy in findedEnemies)
            {
                if (enemy.gameObject.activeSelf == false)
                    return enemy;
            }

            return Create(enemyPrefab);
        }   
    }
}


