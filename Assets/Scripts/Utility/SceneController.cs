using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class SceneController : MonoBehaviour
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] List<string> scenesToLoad;
	// Private
	
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
        scenesToLoad.ForEach((string scene) =>
        {
            LoadScene(scene);
        });
	}


    #endregion



    #region Public Functions
    public void UnloadScene(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
    #endregion



    #region Private Functions
    private void LoadScene(string scene)
    {
        if (!SceneManager.GetSceneByName(scene).IsValid())
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }

    }
    #endregion



    #region Coroutines

    #endregion
}