using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject closeQuestionPanel;


    public void PlayButton()
    {
       // SceneManager.LoadScene(SCENENAME);
    }
	
    public void CreditsButton()
    {
      //  SceneManager.LoadScene(Credits);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
	
}
