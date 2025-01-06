using UnityEngine;
using UnityEngine.UI;

public class SwitchPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Sprite _openSprite, _closeSprite;
    public void Switch()
    {
        _panel.SetActive(!_panel.activeSelf);
        _buttonImage.sprite = _panel.activeSelf ? _closeSprite : _openSprite;
    }
}
