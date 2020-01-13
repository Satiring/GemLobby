public class ConfigDefaultService : IConfigService
{
    public void Setup()
    {
        Core.Data.Set("Horizontal");
    }

    public void Start()
    {
        throw new System.NotImplementedException();
    }

    public void RestartConfig()
    {
        throw new System.NotImplementedException();
    }
}