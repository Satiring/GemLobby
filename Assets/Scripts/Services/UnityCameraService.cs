using Com.LuisPedroFonseca.ProCamera2D;
using Ju;
using UnityEngine;

public class UnityCameraService : ICameraService
{
    private Camera _maincamera;
    private Camera _selectedCamera;
    private bool isProCameraActive = false;
    private ProCamera2D _proCamera2D;
    
    public System.Collections.Generic.List<Camera> _otherscameras;
    
    public void Setup()
    {
        _maincamera = Camera.main;
        _selectedCamera = _maincamera;
    }
    

    public void Start()
    {
        if (_selectedCamera != null)
        {
            _proCamera2D = _selectedCamera.GetComponent<ProCamera2D>();
            if (_proCamera2D)
            {
                Log.Info("ProCamera2D Component Activo in Selected Camera");
                isProCameraActive = true;
            }
        }
        
    }

    public void Shake(string shakePreset)
    {
        ProCamera2DShake.Instance.Shake(shakePreset);
    }
    
    public void Shake(ShakePreset preset)
    {
        ProCamera2DShake.Instance.Shake(preset);
    }
}