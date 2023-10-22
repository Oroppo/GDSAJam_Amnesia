using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTImer : MonoBehaviour
{
    public static EndTImer instance;
    public float Time;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!instance) instance = this;
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
