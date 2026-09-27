using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    [RequireComponent(typeof(ArrivalNotifier))]
    public class WaypointFollower : MonoBehaviour
    {
        [SerializeField] private WaypointHandler _waypointHandler;
        private ArrivalNotifier _arrivalNotifier;

        public event Action<Waypoint> OnWaypointChanged;

        private void Awake()
        {
            _arrivalNotifier = GetComponent<ArrivalNotifier>();
        }

        private void Start()
        {
            SendNextWaypoint();
        }

        private void OnEnable()
        {
            _arrivalNotifier.OnTargetApproached += SendNextWaypoint;
        }

        private void OnDisable()
        {
           _arrivalNotifier.OnTargetApproached -= SendNextWaypoint;
        }

        private void SendNextWaypoint()
        {
            var newWaypoint = _waypointHandler.GetWaypoint();
            OnWaypointChanged?.Invoke(newWaypoint);
            _arrivalNotifier.SetNewTarget(newWaypoint.gameObject);
        }
    }
}

