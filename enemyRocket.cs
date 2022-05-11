using UnityEngine;

namespace Asteroids
{
    internal sealed class enemyRocket : MonoBehaviour
    {
        [SerializeField] private float _delay;
        private float _time;
        private void Start()
        {
            _time = Time.time;
        }
        private void Update()
        {
            if (Time.time > _time + _delay)
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
    }
}