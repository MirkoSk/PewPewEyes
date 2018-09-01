using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    public string menuScene;

    public void BackButton()
    {
        SceneManager.LoadScene(menuScene);
    }
}
