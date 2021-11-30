using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EorzeaTime : MonoBehaviour
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
        DateTime eorzeaTime = EorzeaDateTimeExtention.ToEorzeaTime(utcTime);
        _clockText.text = eorzeaTime.Hour.ToString("00") + ":" + eorzeaTime.Minute.ToString("00") + " ET";
    }

  
}

public static class EorzeaDateTimeExtention
{
    public static DateTime ToEorzeaTime(this DateTime date)
    {
        const double EORZEA_MULTIPLIER = 3600D / 175D;

        // Calculate how many ticks have elapsed since 1/1/1970
        long epochTicks = date.ToUniversalTime().Ticks - (new DateTime(1970, 1, 1).Ticks);

        // Multiply those ticks by the Eorzea multipler (approx 20.5x)
        long eorzeaTicks = (long)Math.Round(epochTicks * EORZEA_MULTIPLIER);

        return new DateTime(eorzeaTicks);
    }
}
