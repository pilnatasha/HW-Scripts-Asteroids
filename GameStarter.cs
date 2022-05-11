using UnityEngine;
using Asteroids.Object_Pool;


namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] public bool _usePhysics;
        private GameObject _player;

        private float _asteroidDelay;
        private float _asteroidSpeed;

        private float _meteorSpeed;
        private float _meteorDelay;

        private float _spaceshipSpeed;
        private float _spaceshipDelay;

        private float _spaceshiphardSpeed;
        private float _spaceshiphardDelay;

        private float _enemyTime;
        private int _enemyType;
        private int _enemyCount;
        private int _enemyWaves;


        private void Awake()
        {
            _enemyCount = 0;
            _enemyTime = Time.time;
            _enemyType = 1;
            _enemyWaves = 1;

            _asteroidDelay = 3f;
            _asteroidSpeed = 1f;

            _meteorSpeed = 2f;
            _meteorDelay = 2f;

            _spaceshipSpeed = 3f;
            _spaceshipDelay = 3f;

            _spaceshiphardSpeed = 4f;
            _spaceshiphardDelay = 3f;

            CreatePlayer();

        }
        private void Start()
        {
            EnemyPool enemyPool = new EnemyPool(5);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (_player == null)
            {
                CreatePlayer();
            }

            if (_enemyType == 1)
            {
                CreateAsteroid(3);
            }
            else if (_enemyType == 2)
            {
                CreateMeteor(3);
            }
            else if (_enemyType == 3)
            {
                CreateSpaceship(3);
            }
            else if (_enemyType == 4)
            {
                CreateSpaceshipHard(3);
            }


        }
        private void CreatePlayer()
        {
            _player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
            Player _playerScript = _player.GetComponent<Player>();
            _playerScript.usePhysics = _usePhysics;
        }

        private void CreateAsteroid(int waves)
        {
            Debug.Log(_enemyCount);
            if (_enemyWaves <= waves)
            {
                if (Time.time > _enemyTime + _asteroidDelay)
                {
                    Enemy.CreateAsteroidEnemy(Random.Range(1, 4), _asteroidSpeed);
                    _enemyTime = Time.time;
                    _enemyCount++;
                }
                if (_enemyCount % 10 == 0 && _enemyCount != 0)
                {
                    _asteroidSpeed += 1f;
                    _enemyCount = 0;
                    _enemyWaves++;
                }
            }
            else
            {
                _enemyType++;
                _enemyWaves = 1;
            }

        }
        private void CreateMeteor(int waves)
        {
            Debug.Log(_enemyCount);
            if (_enemyWaves <= waves)
            {
                if (Time.time > _enemyTime + _meteorDelay)
                {
                    Enemy.CreateMeteorEnemy(Random.Range(1, 4), _meteorSpeed);
                    _enemyTime = Time.time;
                    _enemyCount++;
                }
                if (_enemyCount % 10 == 0 && _enemyCount != 0)
                {
                    _meteorSpeed += 1f;
                    _enemyCount = 0;
                    _enemyWaves++;
                }
            }
            else
            {
                _enemyType++;
                _enemyWaves = 1;
            }
        }
        private void CreateSpaceship(int waves)
        {
            Debug.Log(_enemyCount);
            if (_enemyWaves <= waves)
            {
                if (Time.time > _enemyTime + _spaceshipDelay)
                {
                    Enemy.CreateSpaceshipEnemy(4, _spaceshipSpeed);
                    _enemyTime = Time.time;
                    _enemyCount++;
                }
                if (_enemyCount % 10 == 0 && _enemyCount != 0)
                {
                    _spaceshipSpeed += 1f;
                    _enemyCount = 0;
                    _enemyWaves++;
                }
            }
            else
            {
                _enemyType++;
                _enemyWaves = 1;
            }
        }
        private void CreateSpaceshipHard(int waves)
        {


            SpaceshipHard _spaceshiphard


            _spaceshiphard = Instantiate(Resources.Load<GameObject>("Prefabs/SpaceshipHard"));
            SpaceshipHard _spaceshiphardScript = _spaceshiphard.GetComponent<SpaceshipHard>();
        }
            //Debug.Log(_enemyCount);
            //if (_enemyWaves <= waves)
        
            //{
            //    if (Time.time > _enemyTime + _spaceshiphardDelay)
            //    {
            //        Enemy.CreateSpaceshipEnemy(4, _spaceshipSpeed);
            //        _enemyTime = Time.time;
            //        _enemyCount++;
            //    }
            //    if (_enemyCount % 6 == 0 && _enemyCount != 0)
            //    {
            //        _spaceshipSpeed += 1f;
            //        _enemyCount = 0;
            //        _enemyWaves++;
            //    }
            //}
            //else
            //{
            //    _enemyType++;
            //    _enemyWaves = 1;
            //}
        
    }
}