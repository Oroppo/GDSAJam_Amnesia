using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScreenTIme : MonoBehaviour
{
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        float Time = EndTImer.instance.Time;
        int mins = (int)Time / 60;
        text.text = mins + ":" + (Time % 60).ToString("00.0")+ " Left";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
