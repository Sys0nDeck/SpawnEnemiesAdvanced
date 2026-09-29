using System;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class ArrivalNotifier : MonoBehaviour
    {
        private float _minDistanceToTarget = 0.2f;

        public event Action TargetApproached;

        public Transform Target { get; set; }

        private void Update()
        {
            if (Target == null)
                return;

            if (IsReached(Target.position))
                Notify();
        }

        private bool IsReached(Vector3 target)
        {
            var offset = target - transform.position;
            float sqrLength = offset.sqrMagnitude;
            return sqrLength <= Mathf.Pow(_minDistanceToTarget, 2);
        }

        private void Notify()
            => TargetApproached?.Invoke();
    }
}

