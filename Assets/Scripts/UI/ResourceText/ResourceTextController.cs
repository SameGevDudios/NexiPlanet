using UnityEngine;
using System.Collections.Generic;

public class ResourceTextController : MonoBehaviour
{
    [System.Serializable]
    private class TextConfig
    {
        public IResource.ResourceType Type;
        public TMPro.TMP_Text Text;
    }

    [SerializeField] private List<TextConfig> _textConfig;
    private List<ResourceText> _resourceText = new();

    private void Start()
    {
        ConfigureText();
    }
    private void ConfigureText()
    {
        foreach(TextConfig config in _textConfig)
            _resourceText.Add(new ResourceTextRegular(config.Type, config.Text));
    }
    public void UpdateResourceText(IResource.ResourceType type, int count)
    {
        FindTextByType(type).UpdateText(count);
    }
    private ResourceText FindTextByType(IResource.ResourceType type)
    {
        foreach (ResourceText text in _resourceText)
            if (text.Type == type)
                return text;
        Debug.LogError($"Text with {type} not found");
        return null;
    }
}
