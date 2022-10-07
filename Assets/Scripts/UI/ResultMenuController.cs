using ObjectPool;
using UnityEngine;

namespace UI
{
    public class ResultMenuController : MonoBehaviour
    {
        [SerializeField] private ResultMenuView _view;
        
        [Space(10)]
        [SerializeField] private Player _player;
        [SerializeField] private Pool _pool;
        [SerializeField] private ScoreViewController _scoreViewController;

        private void Start()
        {
            _view.RestartButton.onClick.AddListener(OnRestartButtonClick);
            _view.ExitButton.onClick.AddListener(OnExitButtonClick);
        
            _view.Background.SetActive(false);
        }

        public void OnMenuEnable(bool isWin)
        {
            _view.Background.SetActive(true);
            _view.SetHeaderText(isWin ? "You Win!" : "Game Over");
        }

        private void OnRestartButtonClick()
        {
            _view.Background.SetActive(false);
            _scoreViewController.ResetCoinsAmount();
            
            _pool.ResetPools();
            _player.SetAnimation(false);
        }

        private void OnExitButtonClick() => Application.Quit();
    }
}
