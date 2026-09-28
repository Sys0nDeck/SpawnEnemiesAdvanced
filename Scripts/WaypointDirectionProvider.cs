using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    [RequireComponent(typeof(RotationController))]
    [RequireComponent(typeof(WaypointFollower))]
    public class WaypointDirectionProvider : MonoBehaviour
    {
        private RotationController _rotationController;
        private WaypointFollower _waypointFollower;

        private void Awake()
        {
            _rotationController = GetComponent<RotationController>();
            _waypointFollower = GetComponent<WaypointFollower>();
        }

        private void OnEnable()
        {
            _waypointFollower.WaypointChanged += TrackNewWaypoint;
        }

        private void OnDisable()
        {
            _waypointFollower.WaypointChanged -= TrackNewWaypoint;
        }

        private void TrackNewWaypoint(Waypoint waypoint)
        {
            _rotationController.SetTarget(waypoint.transform);
        }
    }
}

