public class ConfigDefaultService : IConfigService
{
    public void Setup()
    {
        Log.Debug("Inicio la configuracion basica");
        
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