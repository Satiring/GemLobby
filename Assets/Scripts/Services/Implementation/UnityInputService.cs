using UnityEngine;

public class UnityInputService : IInputService
{

    public void Setup()
    {
    }

    public void Start()
    {
    }

    public float GetXAxisValue()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public float GetYAxisValue()
    {
        return Input.GetAxisRaw("Vertical");
    }

    
    // TODO 
    // HAY QUE REFACTORIZAR ESTO 100%
    public bool IsShootPress()
    {
        return Input.GetKeyDown(KeyCode.Mouse0);
    }

    public bool IsDeployedPress()
    {
        return Input.GetKeyDown(KeyCode.Mouse1);
    }

    public bool isGrabPress()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}