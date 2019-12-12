using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Image))]
public class ScrollImage : MonoBehaviour
{
    public int scrollSpeed;
    private Image _ImageComponent; 
    // Start is called before the first frame update
    void Start()
    {
        _ImageComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    
}
