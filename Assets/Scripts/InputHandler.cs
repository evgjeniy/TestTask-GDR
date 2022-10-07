using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class InputHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Player _player;

    private void Start() => GetComponent<Image>().color = Color.clear;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!IsButtonClick(eventData))
            _player.AddPoint(Camera.main.ScreenToWorldPoint(eventData.pressPosition));
    }
    
    private bool IsButtonClick(PointerEventData eventData)
    {
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (var raycastResult in results)
            if (raycastResult.gameObject.GetComponent<Button>() != null)
                return true;

        return false;
    }
}
