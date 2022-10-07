using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    [System.Serializable]
    public class ObjectsPool<T> where T : Component
    {
        [SerializeField] private T _prefab;

        private Pool _basePool;
        private List<T> _pool;

        public void Initialize(Pool basePool)
        {
            _basePool = basePool;
            FillPool();
            Reset();
        }

        public void Reset()
        {
            foreach (T childs in _basePool.transform.GetComponentsInChildren<T>())
                RemoveFromScene(childs);
            
            for (int i = 0; i < _basePool.ObjectsAmount; i++)
                if (_pool.Count != 0)
                    AddToScene(_pool[0], GetRandomPosition());
        }

        private void FillPool()
        {
            _pool = new List<T>();
            for (int i = 0; i < _basePool.ObjectsAmount; i++)
                _pool.Add(Object.Instantiate(_prefab, _basePool.transform));
        }

        private Vector2 GetRandomPosition()
        {
            Vector2[] possiblePosition = _basePool.WorldCameraRectangle;
            Vector3 playerPosition = _basePool.Player.gameObject.transform.position;
            float x, y;

            do
            {
                x = Random.Range(possiblePosition[0].x, possiblePosition[1].x);
                y = Random.Range(possiblePosition[0].y, possiblePosition[1].y);
            } while (x > playerPosition.x - 1.0f && x < playerPosition.x + 1.0f &&
                     y > playerPosition.y - 1.0f && y < playerPosition.y + 1.0f);
            
            return new Vector2(x, y);
        } 

        private void AddToScene(T newObject, Vector2 position)
        {
            newObject.transform.position = position;
            newObject.gameObject.SetActive(true);
            _pool.Remove(newObject);
        }

        public void RemoveFromScene(T gameObject)
        {
            gameObject.gameObject.SetActive(false);
            _pool.Add(gameObject);
        }
    }
}
