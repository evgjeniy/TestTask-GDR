using TriggerItems;
using UnityEngine;

namespace ObjectPool
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private ObjectsPool<Coin> _coinsPool;
        [SerializeField] private ObjectsPool<Spike> _spikesPool;

        [field: Space(10)]
        [field: SerializeField] public Player Player { get; set; }
        [field: SerializeField] public int ObjectsAmount { get; set; }
        
        public Vector2[] WorldCameraRectangle { get; private set; }

        private void Awake()
        {
            WorldCameraRectangle = GetWorldCameraRectangle();
            _coinsPool.Initialize(this);
            _spikesPool.Initialize(this);
        }

        public void ResetPools()
        {
            _coinsPool.Reset();
            _spikesPool.Reset();
        }

        public void CoinClaimed(Coin coin) => _coinsPool.RemoveFromScene(coin);

        public void SpikeTouched(Spike spike) => _spikesPool.RemoveFromScene(spike);

        private Vector2[] GetWorldCameraRectangle()
        {
            return new Vector2[]
            {
                Camera.main.ViewportToWorldPoint(new Vector2(0, 0)) + new Vector3(0.5f, 0.5f, 0),
                Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) - new Vector3(0.5f, 0.5f, 0)
            };
        }
    }
}
