using System.Runtime.CompilerServices;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Target _target;
        [SerializeField] private float _gizmosSphereRadius = 2f;

        public Enemy GetPrefab => _prefab;
        public Target GetTarget => _target;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _gizmosSphereRadius);
        }
    }
}


