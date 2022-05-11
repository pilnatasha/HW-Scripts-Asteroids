using UnityEngine;

namespace Asteroids
{
    internal sealed class Meteor : MonoBehaviour
    {
        public float _moveForce;
        private Rigidbody2D _rigidbody;
        private float destroyPoint = -5f;
        private float _createX;
        private float _createY;
        public float _health;
        private void Start()
        {
            _createX = Random.Range(-4.15f, 4.15f);
            _createY = 5.5f;
            transform.position = new Vector2(_createX, _createY);
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.AddForce(_moveDirection(transform.position) * _moveForce);
        }

        private Vector2 _moveDirection(Vector2 transformPosition)
        {
            Vector2 dir = new Vector2(transformPosition.x / 4.15f, -1);
            return dir;
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