using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace SpawnEnemiesAdvanced
{
    [RequireComponent(typeof(EnemyPool))]
    [RequireComponent(typeof(SpawnPointSelector))]
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private TimeLooper _timeLooper;

        private EnemyPool _enemyPool;
        private SpawnPointSelector _spawnPointSelector;

        private void Awake()
        {
            _spawnPointSelector = GetComponent<SpawnPointSelector>();
            _enemyPool = GetComponent<EnemyPool>();
        }

        private void OnEnable()
        {
            _timeLooper.TimeTicked += SpawnOnPoint;
        }

        private void OnDisable()
        {
            _timeLooper.TimeTicked -= SpawnOnPoint;
        }

        private void Start()
        {
            _timeLooper.Run();
        }

        private void SpawnOnPoint()
        {
            if (_spawnPointSelector.IsEmpty)
            {
                Debug.Log("Spawn point is empty");
                return;
            }

            var spawnPoint = _spawnPointSelector.GetRandomSpawnPoint();
            SpawnOn(spawnPoint);
        }

        private void SpawnOn(SpawnPoint spawnPoint)
        {
            var enemy = _enemyPool.Get(spawnPoint.GetPrefab);

            if (enemy == null)
                return;

            enemy.transform.position = spawnPoint.transform.position;
            enemy.Init(spawnPoint.GetTarget);
            enemy.gameObject.SetActive(true);
            enemy.EnemyDead += ReturnEnemyInPool;
        }

        private void ReleaseEnemy(Enemy enemy)
        {
            _enemyPool.Repease(enemy);
            enemy.EnemyDead -= ReturnEnemyInPool;
        }

        private void ReturnEnemyInPool(Enemy enemy)
        {
            ReleaseEnemy(enemy);
        }
    }
}

