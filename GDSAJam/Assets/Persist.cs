using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persist : MonoBehaviour
{
    [SerializeField]
    AudioSource audioData;

    void Awake()
    {
        DontDestroyOnLoad(transform);

        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }
}
