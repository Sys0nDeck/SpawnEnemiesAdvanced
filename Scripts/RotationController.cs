using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class RotationController : MonoBehaviour
    {
        private Transform _targetPosition;

        private void Update()
        {
            Rotate();
        }

        public void SetTarget(Transform targetPosition)
        {
            _targetPosition = targetPosition;
        }

        private void Rotate()
        {
            transform.LookAt(_targetPosition);
        }
    }
}

