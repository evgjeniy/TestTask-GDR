using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [System.Serializable]
    public class ScoreView
    {
        [field: SerializeField] public Text CoinsAmountText { get; set; }

        public void Initialize(Text text) => CoinsAmountText = text;

        public void SetCoinsText(int amount) => CoinsAmountText.text = $"Coins: {amount}";
    }
}
