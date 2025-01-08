public class MainNexus : Nexus
{
    private void Start()
    {
        Place();
    }
    public override void Collect()
    {
        StorageController.Instance.AddResource(_resourceType, 1);
    }
}
