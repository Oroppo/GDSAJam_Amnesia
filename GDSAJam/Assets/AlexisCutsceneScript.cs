using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AlexisCutsceneScript : MonoBehaviour
{
    public float CutsceneRuntimeTotal = 60;
    private void Awake()
    {
        Invoke(nameof(LoadNewScene), CutsceneRuntimeTotal);
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene("VolcanoScene", LoadSceneMode.Single);
    }

}
