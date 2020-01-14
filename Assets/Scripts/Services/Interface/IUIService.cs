using Ju;

public interface IUIService : IService
{
    void SetTurretIcon(UITurretIcon IconController);
    void IsTurretAvailable();
    void IsTurretUnavailable();


}