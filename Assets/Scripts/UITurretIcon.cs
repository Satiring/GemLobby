using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class UITurretIcon : MonoBehaviour
{
    private Image _image;


    public void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }
    
    
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        Core.UIService.SetTurretIcon(this);
    }
    
}
