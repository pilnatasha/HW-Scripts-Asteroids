using UnityEngine;
namespace Asteroids

{
    internal sealed class Weapon
    {
        private readonly GameObject _rocket;
        private GameObject _shot;
        private Transform _barrel;
        private readonly float _force;
        public Weapon(GameObject rocket, Transform barrel, float force)
        {
            _rocket = rocket;
            _force = force;
            _barrel = barrel;

        }
        public void Shot()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _shot = Object.Instantiate(_rocket, _barrel.position, _barrel.rotation);
                Rigidbody2D _shotRB = _shot.GetComponent<Rigidbody2D>();
                _shotRB.AddForce(_barrel.up * _force);
            }
        }
        public void SpaceshipShot()
        {
            _shot = Object.Instantiate(_rocket, _barrel.position, _barrel.rotation);
            Rigidbody2D _shotRB = _shot.GetComponent<Rigidbody2D>();
            _shotRB.AddForce(_barrel.up * _force);

        }
    }
}
