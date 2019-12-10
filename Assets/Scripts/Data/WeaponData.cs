    using Com.LuisPedroFonseca.ProCamera2D;
    using UnityEngine;
    using UnityEngine.Serialization;

    [CreateAssetMenu(menuName = ("Data/Weapon"))]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        public Sprite weaponSprite;
        public GameObject bulletPrefab;
        public ShakePreset preset;

    }