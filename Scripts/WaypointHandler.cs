using System.Collections.Generic;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class WaypointHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _waypointsParent;
        [SerializeField] private List<Waypoint> _waypoints;

        private IEnumerator<Waypoint> _waypointEnumerator;
        private int _currentWaypointIndex;
        private bool _isReverse;

        private void Awake()
        {
            _waypointEnumerator = EnumerateWaypoints();
        }

        private void OnDrawGizmos()
        {
            var positions = GetPointPositions();

            if (positions != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLineStrip(positions, false);
            }
        }

        [ContextMenu("Fill Waypoints")]
        public void FillWaypoints()
        {
            if (_waypointsParent == null)
                return;

            var waypoints = _waypointsParent.GetComponentsInChildren<Waypoint>();
            _waypoints.Clear();

            foreach (var waypoint in waypoints)
            {
                _waypoints.Add(waypoint);
            }      
        }

        public Waypoint GetWaypoint()
        {
            if (_waypoints.Count == 0)
            {
                Debug.Log("Waypoints is empty");
                return null;
            }

            if (_waypointEnumerator.Current == null)
                _waypointEnumerator.MoveNext();

            var point = _waypointEnumerator.Current;
            _waypointEnumerator.MoveNext();

            return point;
        }

        private Vector3[] GetPointPositions()
        {
            if (_waypoints == null || _waypoints.Count < 2)
                return null;

            var positions = new Vector3[_waypoints.Count];

            for (int i = 0; i < _waypoints.Count; i++)
            {
                positions[i] = _waypoints[i].transform.position;
            }

            return positions;
        }

        private IEnumerator<Waypoint> EnumerateWaypoints()
        {
            _currentWaypointIndex = 0;
            _isReverse = false;

            while (true)
            {
                yield return _waypoints[_currentWaypointIndex];

                if (_currentWaypointIndex == 0 && _isReverse == true)
                    _isReverse = false;

                if (_currentWaypointIndex == _waypoints.Count - 1 && _isReverse == false)
                    _isReverse = true;

                if (_isReverse == true)
                    _currentWaypointIndex--;
                else
                    _currentWaypointIndex++;
            }
        }
    }
}

