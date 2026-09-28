using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class EnemyInitializator : MonoBehaviour
    {
        [SerializeField] private Target _target;

        public void Initialize(Enemy enemy)
        {
            enemy.transform.position = transform.position;

            if ( _target == null )
            {
                Debug.Log($"{name}'s target is null");
                SetTargetToEnemy(enemy, transform);
            }
            else
            {
                SetTargetToEnemy(enemy, _target.transform);
            }
        }

        private void SetTargetToEnemy(Enemy enemy, Transform targetPosition)
        {
            if (enemy.TryGetComponent<RotationController>(out var rotationController))
                rotationController.SetTarget(targetPosition);
            else
                Debug.Log($"{enemy.name} have't component {nameof(RotationController)} for functional");
        }
    }
}

