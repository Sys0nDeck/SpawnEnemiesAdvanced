using System;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class ArrivalNotifier : MonoBehaviour
    {
        private Transform _target;
        private float _minDistanceToTarget = 0.2f;

        public event Action TargetApproached;

        private void Update()
        {
            if (_target == null)
                return;

            if (IsReached(_target.transform.position))
                NotifyArrival();
        }

        public void SetNewTarget(Transform target)
        {
            _target = target;
        }

        private bool IsReached(Vector3 target)
        {
            var offset = target - transform.position;
            float sqrLength = offset.sqrMagnitude;
            return sqrLength <= Mathf.Pow(_minDistanceToTarget, 2);
        }

        private void NotifyArrival()
            => TargetApproached?.Invoke();
    }
}

