using TMPro;

public class ResourceTextRegular : ResourceText
{
    private TMP_Text _text;
    public ResourceTextRegular(IResource.ResourceType type, TMP_Text text)
    {
        Type = type;
        _text = text;
    }
    public override void UpdateText(int count)
    {
        _text.text = count.ToString();
    }
}
