using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace SpawnEnemiesAdvanced
{
    [RequireComponent(typeof(EnemyInitializator))]
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private TimeLooper _timeLooper;
        [SerializeField] private int _poolCapacity = 5;
        [SerializeField] private int _poolMaxSize = 15;

        private ObjectPool<Enemy> _enemyPool;
        private Coroutine _coroutine;
        private EnemyInitializator _enemyInitializator;

        private void Awake()
        {
            _enemyPool = new ObjectPool<Enemy>(
                createFunc: () => CreateEnemy(),
                actionOnGet: (enemy) => GetEnemy(enemy),
                actionOnRelease: (enemy) => ReleaseEnemy(enemy),
                actionOnDestroy: (enemy) => Destroy(enemy),
                collectionCheck: true,
                defaultCapacity: _poolCapacity,
                maxSize: _poolMaxSize
                );
            _enemyInitializator = GetComponent<EnemyInitializator>();
        }

        private void OnEnable()
        {
            _timeLooper.TimeTicked += Spawn;
        }

        private void OnDisable()
        {
            _timeLooper.TimeTicked -= Spawn;
        }

        private void Start()
        {
            _timeLooper.Run();
        }

        private void Spawn()
        {
            _enemyPool.Get();
        }

        private Enemy CreateEnemy()
        {
            var newEnemy = Instantiate(_prefab);
            newEnemy.gameObject.SetActive(false);
            return newEnemy;
        }

        private void GetEnemy(Enemy enemy)
        {
            _enemyInitializator.Initialize(enemy);
            enemy.gameObject.SetActive(true);
            enemy.EnemyDead += ReturnEnemyInPool;
        }

        private void ReleaseEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            enemy.EnemyDead -= ReturnEnemyInPool;
        }

        private void ReturnEnemyInPool(Enemy enemy)
            => _enemyPool.Release(enemy);
    }
}

