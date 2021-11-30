using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ServerTime : MonoBehaviour
{
    private TextMeshProUGUI _clockText;
    // Start is called before the first frame update
    void Start()
    {
        _clockText = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        DateTime utcTime = DateTime.UtcNow;
        _clockText.text = utcTime.Hour.ToString("00")+":"+utcTime.Minute.ToString("00")+" ST";
    }
}
