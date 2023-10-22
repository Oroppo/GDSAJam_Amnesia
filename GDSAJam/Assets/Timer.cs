using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
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

        if (RunTime <= 0.0f)
        {
           
            SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
        }
    }
    public void Die()
    {
        EndTImer.instance.Time = RunTime;
    }
}
