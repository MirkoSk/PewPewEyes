using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public Button playButton;
    public Button closeButton;
    public Button creditsButton;
    public Button quitApplicationCloseQuestionButton;
    public Button closeCloseQuestionPanel;

    public GameObject closeQuestionPanel;


    public void PlayButton()
    {
       // SceneManager.LoadScene(SCENENAME);
    }
	
    public void CloseButton()
    {
        closeQuestionPanel.SetActive(true);
    }

    public void CloseQuestionQuit()
    {
        closeQuestionPanel.SetActive(false);
    }

    public void CreditsButton()
    {
      //  SceneManager.LoadScene(SCENENAME);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
	
}
