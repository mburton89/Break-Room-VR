using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour
{
    public TextMeshProUGUI tm;
    float time;

    void Update()
    {
        time += Time.deltaTime;
        //float f = Mathf.Round(time * 100.0f) * 0.01f;
        //tm.text = f.ToString();//Mathf.RoundToInt(time).ToString();
        tm.text = Mathf.RoundToInt(time).ToString();
    }
}
