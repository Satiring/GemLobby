    using Com.LuisPedroFonseca.ProCamera2D;
    using Ju;
    using UnityEngine;

    public interface ICameraService : IService
    {
        
        void Shake(string shakePreset);
        void Shake(ShakePreset preset);
        void AddTarget(Transform newTarget);
    }