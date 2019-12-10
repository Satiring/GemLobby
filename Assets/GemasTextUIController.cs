using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class GemasTextUIController : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    public string message;
    private PlayerMovement _playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerMovement)
        {
            if (_textMeshPro)
            {
                _textMeshPro.text = message + " " + _playerMovement.GetTotalGems();    
            }

        }else{
            _playerMovement = Core.Data.Get<PlayerMovement>("player");
        }
    }
}
