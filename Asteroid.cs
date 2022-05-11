using UnityEngine;

namespace Asteroids
{
    internal sealed class Asteroid : MonoBehaviour
    {
        public float _moveForce;
        private Vector2 _moveDirection;
        private Rigidbody2D _rigidbody;
        private float destroyPoint = -5f;
        private float _createX;
        private float _createY;
        public float _health;
        private void Start()
        {
            _createX = Random.Range(-8.3f, 8.3f);
            _createY = 5.5f;
            transform.position = new Vector2(_createX, _createY);
            _moveDirection = new Vector2(0, -1);
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.AddForce(_moveDirection * _moveForce);
        }
        private void Update()
        {
            if (transform.position.y < destroyPoint)
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_health == 1)
            {
                Destroy(gameObject);
            }
            else
            {
                _health--;
            }
        }
    }
}