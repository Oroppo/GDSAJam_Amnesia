using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPrompt : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(DisableThis),1.0f);
    }
    private void DisableThis()
    {
        gameObject.SetActive(false);
    }
}

