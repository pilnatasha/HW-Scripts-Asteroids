using UnityEngine;
namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _healthPoints;
        [SerializeField] private float _rocketForce;
        [SerializeField] private float _moveForce;
        [SerializeField] private GameObject _rocket;
        [SerializeField] private Transform _barrel;
        public bool usePhysics;
        private Vector2 _startPoint;
        private Health _health;
        private Move _move;
        private Weapon _weapon;

        private void Start()
        {
            _startPoint = new Vector2(0.0f, -4f);

            transform.position = _startPoint;

            _health = new Health(this.gameObject, _healthPoints);

            _move = new Move(this.gameObject, _speed, _moveForce);

            _weapon = new Weapon(_rocket, _barrel, _rocketForce);
        }
        private void Update()
        {
            _move.Go(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime, usePhysics);

            _weapon.Shot();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _health.onCollision();
        }
    }
}
