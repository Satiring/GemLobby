using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ObjetiveTextController : MonoBehaviour
{

    public Color finishColor;
    public float timeToDissapear = 10f;
    private TextMeshProUGUI _textMeshPro;
    private float timeLeft;
     
    // Start is called before the first frame update
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        timeLeft = timeToDissapear;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            _textMeshPro.DOColor(finishColor, 2f);
            Destroy(this.gameObject,2f);
        }
        
        
    }
}
