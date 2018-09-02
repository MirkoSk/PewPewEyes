using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
/// 
[CreateAssetMenu(menuName = "Scriptable Objects/SceneLoader")]
public class SceneLoader : ScriptableObject 
{

    public void ChangeToGame()
    {
        SceneManager.LoadScene(Constants.SCENE_LOGIC, LoadSceneMode.Additive);
        SceneManager.LoadScene(Constants.SCENE_GUI, LoadSceneMode.Additive);
        SceneManager.LoadScene(Constants.SCENE_ENVIRONMENT, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(Constants.SCENE_MENU);
    }

    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene(Constants.SCENE_MENU, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(Constants.SCENE_LOGIC);
        SceneManager.UnloadSceneAsync(Constants.SCENE_GUI);
        SceneManager.UnloadSceneAsync(Constants.SCENE_ENVIRONMENT);
    }
}