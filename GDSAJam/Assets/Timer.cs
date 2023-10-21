using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI text;
    public float RunTime = 180;
    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        RunTime -= Time.deltaTime;
        int mins = (int)RunTime / 60;
        text.text = mins + ":" + (RunTime % 60).ToString("00.0");
    }
}
