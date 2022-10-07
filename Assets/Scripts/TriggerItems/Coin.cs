using ObjectPool;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace TriggerItems
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Coin : MonoBehaviour
    {
        private readonly UnityEvent<bool> _resultMenuEvent = new();

        private ScoreViewController _scoreViewController;
        private Pool _pool;

        private void Start()
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
            _scoreViewController = FindObjectOfType<ScoreViewController>();
            _pool = FindObjectOfType<Pool>();
            ResultMenuController menu = FindObjectOfType<ResultMenuController>();

            if (menu != null) _resultMenuEvent.AddListener(menu.OnMenuEnable);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out Player player))
            {
                _pool.CoinClaimed(this);
                _scoreViewController.IncreaseCoinsAmount();

                if (_scoreViewController.Score == _pool.ObjectsAmount)
                {
                    _resultMenuEvent?.Invoke(true);
                    player.RemoveMovePoints();
                }
            }
        }
    }
}
