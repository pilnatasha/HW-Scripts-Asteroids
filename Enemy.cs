using UnityEngine;
namespace Asteroids
{
    internal abstract class Enemy : MonoBehaviour
    {

        public static Asteroid CreateAsteroidEnemy(float health, float speed)
        {
            var _asteroid = Instantiate(Resources.Load<Asteroid>("Prefabs/Asteroid"));
            Asteroid _asteroidScript = _asteroid.GetComponent<Asteroid>();
            _asteroidScript._health = health;
            _asteroidScript._moveForce = speed;
            return _asteroid;
        }

        public static Meteor CreateMeteorEnemy(float health, float speed)
        {
            var _meteor = Instantiate(Resources.Load<Meteor>("Prefabs/Meteor"));
            Meteor _meteorScript = _meteor.GetComponent<Meteor>();
            _meteorScript._health = health;
            _meteorScript._moveForce = speed;
            return _meteor;
        }
        public static Spaceship CreateSpaceshipEnemy(float health, float speed)
        {
            var _spaceship = Instantiate(Resources.Load<Spaceship>("Prefabs/Spaceship"));
            Spaceship _spaceshipScript = _spaceship.GetComponent<Spaceship>();
            _spaceshipScript._health = health;
            _spaceshipScript._moveForce = speed;
            return _spaceship;
        }
    }
}
