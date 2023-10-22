using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreen : MonoBehaviour
{
    public GameObject TitleScreenBackground;
    public GameObject TitleScreenForeground;

    public GameObject OptionsScreenForeground;
    public GameObject OptionsScreenBackground; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("VolcanoScene", LoadSceneMode.Single);
    }
    public void LoadControls()
    {
        //disable title screen elements & enable option screen elements
        TitleScreenForeground.SetActive(false);
        OptionsScreenForeground.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
