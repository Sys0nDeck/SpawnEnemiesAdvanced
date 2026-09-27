using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private float _gizmosSphereRadius = 2f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _gizmosSphereRadius);
        }
    }
}


