using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persist : MonoBehaviour
{
    [SerializeField]
    AudioSource audioData;
    public static Persist Instance{ get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(transform);

        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }
}
