using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GameManager : MonoBehaviour
{

    #region Variable Declarations
    public static GameManager Instance;

    // Serialized Fields
    [SerializeField] GameEvent pauseEvent;

    // Private
    private bool gameIsPaused;
    private float oldTimeScale;

    // Public
    [HideInInspector] public GameObject Player;
    [HideInInspector] public ShieldController ShieldController;
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Awake () 
	{
        // Singleton
        {
            //Check if instance already exists
            if (Instance == null)

                //if not, set instance to this
                Instance = this;

            //If instance already exists and it's not this:
            else if (Instance != this)
            {

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);
            }
        }

        Player = GameObject.FindGameObjectWithTag(Constants.TAG_PLAYER);
        ShieldController = GameObject.FindObjectOfType<ShieldController>();
	}

    private void Update()
    {
        if (!gameIsPaused)
        {
            if (Input.GetButtonDown(Constants.INPUT_ESCAPE))
                pauseEvent.Raise();
        }
    }
    #endregion



    #region Public Functions
    public void PauseGame(bool state)
    {
        if (state)
            oldTimeScale = Time.timeScale;
        Time.timeScale = state == true ? 0 : oldTimeScale;
    }
    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}