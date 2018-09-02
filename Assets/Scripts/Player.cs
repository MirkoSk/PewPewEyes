using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Player : MonoBehaviour
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] IntValue health;
    [SerializeField] FloatValue slowMo;
    [SerializeField] float slowingDownTime = 1f;
    [SerializeField] float slowMoTimeScale = 0.25f;
    [SerializeField] AudioSource deathSoundSource;
    // Private
    float realTimer;
    bool slowMoOnCoolDown = false;
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
        health.value = health.maxValue;
        slowMo.value = slowMo.maxValue;
	}

    private void Update()
    {
        float timeDifference = TimeDifference(Time.realtimeSinceStartup);
        if (Input.GetButton(Constants.INPUT_SLOWMO) && !slowMoOnCoolDown)
        {
            Time.timeScale -= slowingDownTime * timeDifference;
            if(Time.timeScale < slowMoTimeScale)
            {
                Time.timeScale = slowMoTimeScale;
            }
            slowMo.changeValue(-timeDifference);
        }
        if(Time.timeScale != 0 && (!Input.GetButton(Constants.INPUT_SLOWMO) || slowMoOnCoolDown))
        {
            slowMoOnCoolDown = true;
            slowMo.changeValue(timeDifference);
            if (Time.timeScale != 1)
            {
                Time.timeScale += slowingDownTime * timeDifference;
                if (Time.timeScale > 1)
                {
                    Time.timeScale = 1;
                }
            }
        }
        if(slowMo.value == 0)
        {
            slowMoOnCoolDown = true;
        }
        if(slowMo.value >= slowMo.maxValue && Time.timeScale == 1)
        {
            slowMoOnCoolDown = false;
            slowMo.value = slowMo.maxValue;
        }
        realTimer = Time.realtimeSinceStartup;
    }
    #endregion



    #region Public Functions

    public void DealDamage(int amount)
    {
        health.changeValue(-amount);
    }

    public void DIE()
    {
        deathSoundSource.Play();
    }
	#endregion
	
	
	
	#region Private Functions
    private float TimeDifference(float currentTime)
    {
        return currentTime - realTimer;
    }
	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}