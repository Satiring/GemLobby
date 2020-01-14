using Ju;

public interface IInputService : IService
{
    float GetXAxisValue();
    float GetYAxisValue();

    bool IsShootPress();

    bool IsDeployedPress();

    bool isGrabPress();
}