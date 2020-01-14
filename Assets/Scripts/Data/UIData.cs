using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


[CreateAssetMenu(menuName = "Config/UI")]
public class UIData : ScriptableObject
{
    [Required]
    public Sprite turretAvailable;
    [Required]
    public Sprite turretUnavailable;

}