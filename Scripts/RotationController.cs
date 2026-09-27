using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class RotationController : MonoBehaviour
    {
        private Transform _targetTransform;

        private void Update()
        {
            Rotate();
        }

        public void SetTarget(Transform targetTransform)
        {
            _targetTransform = targetTransform;
        }

        private void Rotate()
        {
            transform.LookAt(_targetTransform);
        }
    }
}

