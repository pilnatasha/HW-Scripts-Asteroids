using UnityEngine;

namespace Asteroids
{



    internal sealed class Spaceship : MonoBehaviour
    {
        [SerializeField] private float _rocketForce;
        [SerializeField] private GameObject _rocket;
        [SerializeField] private Transform _barrel;
        public float _moveForce;
        private Vector2 _moveDirection;
        private Rigidbody2D _rigidbody;
        private float destroyPoint = -5f;
        private float _createX;
        private float _createY;
        public float _health;
        private float _shotDelay;
        private float _shotTime;
        private Weapon _weapon;

        private void Start()
        {
            _createX = Random.Range(-8.3f, 8.3f);
            _createY = 5.5f;

            _shotTime = Time.time;
            transform.position = new Vector2(_createX, _createY);
            _moveDirection = new Vector2(0, -1);
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.AddForce(_moveDirection * _moveForce);
            _weapon = new Weapon(_rocket, _barrel, _rocketForce);
        }
        private void Update()
        {
            _shotDelay = Random.Range(2f, 5f);

            if (Time.time > _shotTime + _shotDelay)
            {
                _weapon.SpaceshipShot();
                _shotTime = Time.time;
            }

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