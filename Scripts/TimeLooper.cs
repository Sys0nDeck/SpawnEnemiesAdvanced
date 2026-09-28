using System;
using System.Collections;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class TimeLooper : MonoBehaviour
    {
        [SerializeField] private float _loopDelay;

        private Coroutine _coroutine;

        public event Action TimeTicked;

        public void Run()
        {
            _coroutine = StartCoroutine(ToLoopTime(_loopDelay));
        }

        public void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private IEnumerator ToLoopTime(float delay)
        {
            var time = new WaitForSeconds(delay);

            while (true)
            {
                yield return time;
                TimeTicked?.Invoke();
            }
        }
    }
}


