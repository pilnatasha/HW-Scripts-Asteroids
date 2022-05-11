using UnityEngine;
namespace Asteroids
{
    internal sealed class Move
    {
        private readonly GameObject _player;
        private readonly float _moveForce;
        private readonly float _moveSpeed;
        private Vector3 _move;
        public Move(GameObject player, float speed, float force)
        {
            _player = player;
            _moveForce = force;
            _moveSpeed = speed;
        }
        public void Go(float horizontal, float vertical, float deltaTime, bool physics)
        {
            if (_player.transform.position.x > -8.3f && _player.transform.position.x < 8.3f)
            {
                if (physics)
                {
                    Vector2 _moveDirection = new Vector2(horizontal, vertical);
                    Rigidbody2D _playerRB = _player.GetComponent<Rigidbody2D>();
                    _playerRB.AddForce(_moveDirection * _moveForce);
                }
                else
                {
                    Transform _playerTF = _player.GetComponent<Transform>();
                    var speed = deltaTime * _moveSpeed;
                    _move.Set(horizontal * speed, vertical * speed, 0.0f);
                    _playerTF.localPosition += _move;
                }
            }
            else
            {
                if (_player.transform.position.x > 0)
                {
                    _player.transform.position = new Vector2(8.2f, _player.transform.position.y);
                }
                else if (_player.transform.position.x < 0)
                {
                    _player.transform.position = new Vector2(-8.2f, _player.transform.position.y);
                }
            }
        }
    }
}