using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Config/SFX Game Data")]
public class SFXGameData : ScriptableObject
{
    public AudioClip hitSound;
}