using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject closeQuestionPanel;
    public string gameScene;

    public void CreditsButton()
    {
      //  SceneManager.LoadScene(Credits);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
	
}
