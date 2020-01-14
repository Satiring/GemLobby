public class UIServiceUnity : IUIService
{
    private UITurretIcon _iconController;
    private UIData _data;
    
    
    public void Setup()
    {
        _data = Core.Data.Get<GameData>("gameData").UIData;
    }

    public void Start()
    {
        
    }

    public void SetTurretIcon(UITurretIcon IconController)
    {
        _iconController = IconController;
    }

    public void IsTurretAvailable()
    {
        if (_iconController == null) return;
        
        _iconController.SetImage(_data.turretAvailable);
        
    }

    public void IsTurretUnavailable()
    {
        if (_iconController == null) return;
        
        _iconController.SetImage(_data.turretUnavailable);
        
    }
}