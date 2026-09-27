using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class EnemyInitializator : MonoBehaviour
    {
        [SerializeField] private Target _target;

        public void Initialize(Enemy enemy)
        {
            enemy.gameObject.transform.position = transform.position;

            if ( _target == null )
            {
                Debug.Log($"{name}'s target is null");
                enemy.GetComponent<RotationController>().SetTarget(transform);
            }
            else
            {
                enemy.GetComponent<RotationController>().SetTarget(_target.transform);
            }
        }
    }
}

