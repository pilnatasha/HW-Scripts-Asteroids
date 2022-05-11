using UnityEngine;
namespace Asteroids

{
    internal sealed class Health
    {
        private readonly GameObject _player;
        private int _health;
        public Health(GameObject player, int health)
        {
            _player = player;
            _health = health;
        }
        public void onCollision()
        {
            if (_health <= 0)
            {
                Object.Destroy(_player, 0);
            }
            else
            {
                _health--;
            }
        }
    }
}