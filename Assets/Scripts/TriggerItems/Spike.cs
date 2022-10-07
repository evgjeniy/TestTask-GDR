using ObjectPool;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace TriggerItems
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class Spike : MonoBehaviour
    {
        private readonly UnityEvent<bool> _onSpikeTouchEvent = new ();
        private readonly UnityEvent<Spike> _onSpikePoolEvent = new ();
    
        private void Start()
        {
            GetComponent<PolygonCollider2D>().isTrigger = true;
            ResultMenuController resultMenu = FindObjectOfType<ResultMenuController>();
            Pool objectPool = FindObjectOfType<Pool>();
        
            if (resultMenu != null) _onSpikeTouchEvent.AddListener(resultMenu.OnMenuEnable);
            if (objectPool != null) _onSpikePoolEvent.AddListener(objectPool.SpikeTouched);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out Player player))
            {
                _onSpikePoolEvent?.Invoke(this);
                _onSpikeTouchEvent?.Invoke(false);

                player.RemoveMovePoints();
                player.SetAnimation(true);
            }
        }
    }
}
