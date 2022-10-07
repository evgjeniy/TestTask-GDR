using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [System.Serializable]
    public class ResultMenuView
    {
        [field: SerializeField] public GameObject Background { get; set; } 
        [field: SerializeField] public Text HeaderText { get; set; }
        [field: SerializeField] public Button RestartButton { get; set; }
        [field: SerializeField] public Button ExitButton { get; set; }

        public void SetHeaderText(string text) => HeaderText.text = text;
    }
}
