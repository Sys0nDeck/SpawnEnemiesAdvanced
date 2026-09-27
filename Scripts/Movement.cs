using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private void Update()
        {
            MoveForward(); 
        }

        private void MoveForward()
            => transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}

