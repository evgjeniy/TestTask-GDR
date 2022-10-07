using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class ScoreViewController : MonoBehaviour
    {
        [SerializeField] private ScoreView _view;

        private int _score;

        public int Score => _score;

        private void Start() => _view.Initialize(GetComponent<Text>());

        public void IncreaseCoinsAmount()
        {
            _score++;
            _view.SetCoinsText(_score);
        }

        public void ResetCoinsAmount()
        {
            _score = 0;
            _view.SetCoinsText(_score);
        }
    }
}
