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

        public event Action<Waypoint> WaypointChanged;

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
            _arrivalNotifier.TargetApproached += SendNextWaypoint;
        }

        private void OnDisable()
        {
           _arrivalNotifier.TargetApproached -= SendNextWaypoint;
        }

        private void SendNextWaypoint()
        {
            var newWaypoint = _waypointHandler.GetWaypoint();
            WaypointChanged?.Invoke(newWaypoint);
            _arrivalNotifier.Target = newWaypoint.transform;
        }
    }
}

