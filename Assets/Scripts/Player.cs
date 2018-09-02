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
    [SerializeField] int maxHP;
    [SerializeField] GameEvent gameOverEvent;
    // Private
    int currentHP;
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
        currentHP = maxHP;
	}
	#endregion
	
	
	
	#region Public Functions
	
    public void DealDamage(int amount)
    {
        currentHP -= amount;
        CheckDeath();
    }

	#endregion
	
	
	
	#region Private Functions

    private void CheckDeath()
    {
        if(currentHP <= 0)
        {
            gameOverEvent.Raise();
        }
    }

	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}