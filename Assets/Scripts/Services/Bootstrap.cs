using UnityEngine;
using Ju;

public static class Bootstrap
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        Services.RegisterService<ILogUnityService, LogUnityService>();
        Services.RegisterService<IEventBusService, EventBusService>();
        Services.RegisterService<IDataService, DataService>();
        Services.RegisterService<IUnityService, UnityService>();
        
        // Game Service 
        
        Services.RegisterService<IGameService,GameService>();
        
            // Music & FX
            Services.RegisterService<ISFXService,SFXService>();
            Services.RegisterService<IMusicGameService,MusicGameService>();
        
        // Personals
        Services.RegisterService<IInputService,UnityInputService>();
        Services.RegisterService<ICameraService,UnityCameraService>();
        Services.RegisterService<ISceneService,SceneUnityService>();
        
        
        // TODO Services
        // Implement PoolInfoData
        //Services.RegisterService<IObjectPoolService,ObjectPoolService>();
        
        
        // Lazys 
    }
}

public static class Core
{
    public static T Get<T>() => Services.Get<T>();
    public static T Get<T>(string id) => Services.Get<T>(id);
    public static void Fire<T>(T msg) => Services.Get<IEventBusService>().Fire(msg);
    public static ILogService Log => Services.Get<ILogService>();
    public static IEventBusService Event => Services.Get<IEventBusService>();
    public static IDataService Data => Services.Get<IDataService>();
    public static IUnityService Unity => Services.Get<IUnityService>();
    public static IInputService InputService => Services.Get<IInputService>();
    public static IObjectPoolService Pool => Services.Get<IObjectPoolService>();
    public static IGameService Game => Services.Get<IGameService>();
    public static IMusicGameService Music => Services.Get<IMusicGameService>();
    public static ISFXService Fx => Services.Get<ISFXService>();

    public static ISceneService SceneService => Services.Get<ISceneService>();


    // MARGINATED
    //public static ICameraService Camera => Services.Get<ICameraService>();
}

public static class Log
{
    public static void Debug(string msg, params object[] args) => Core.Log.Debug(msg, args);
    public static void Info(string msg, params object[] args) => Core.Log.Info(msg, args);
    public static void Notice(string msg, params object[] args) => Core.Log.Notice(msg, args);
    public static void Warning(string msg, params object[] args) => Core.Log.Warning(msg, args);
    public static void Error(string msg, params object[] args) => Core.Log.Error(msg, args);
}
