using System;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class ArrivalNotifier : MonoBehaviour
    {
        private GameObject _target;
        private float _minDistanceToTarget = 0.2f;

        public event Action OnTargetApproached;

        private void Update()
        {
            if (_target == null)
                return;

            if (IsReached(_target.transform.position))
                NotifyArrival();
        }

        public void SetNewTarget(GameObject target)
        {
            _target = target;
        }

        private bool IsReached(Vector3 target)
        {
            var distance = Vector3.Distance(transform.position, target);
            return distance <= _minDistanceToTarget;
        }

        private void NotifyArrival()
            => OnTargetApproached?.Invoke();
    }
}

