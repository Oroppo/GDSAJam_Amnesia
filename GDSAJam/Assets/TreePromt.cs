using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePromt : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(DisableThis), 3.0f);
    }
    private void DisableThis()
    {
        gameObject.SetActive(false);
    }
}
