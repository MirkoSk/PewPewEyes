using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class BossController : Enemy
{

    #region Variable Declarations
    // Serialized Fields
    [Space]
    [SerializeField] float activationDelay = 0.18f;
    [SerializeField] float flightHeight = 10f;
    [SerializeField] float smoothTime = 0.1f;
    [SerializeField] float dissolveTime = 5f;
    [SerializeField] IntValue bossHealthVisualization;
    
    // Private
    Vector3 currentVelocity;
    Vector3 targetPosition;
    bool active;
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
        targetPosition = transform.position + Vector3.up * flightHeight;
        bossHealthVisualization.value = enemyType.hp;
        bossHealthVisualization.maxValue = enemyType.hp;
    }

    private void Update()
    {
        if (active)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
        }
        /*else
        {
            if (Input.GetKeyDown(KeyCode.Return))
                Activate();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }*/
    }
    #endregion



    #region Public Functions
    public new void TakeDamage(int amount)
    {
        bossHealthVisualization.value -= amount;
        if (!CheckDeath())
        {
            if (playSoundOnHit)
            {
                hitSoundSource.Play();
            }
        }
    }

    public void Hit()
    {
        animator.SetTrigger("hit");
    }

    public void Activate()
    {
        animator.SetTrigger("hit");
        Invoke("ActivateDelayed", activationDelay);
    }
    #endregion



    #region Private Functions
    void ActivateDelayed()
    {
        animator.SetTrigger("activate");
        active = true;
        stateMachine.ChangeState("Move");
    }

    private bool CheckDeath()
    {
        if (bossHealthVisualization.value <= 0)
        {
            animator.SetBool("death", true);
            //transform.Find("States").GetComponent<StateMachine>().ChangeState(deathState);
            score.IncreaseScore(enemyType.scoreOnDeath);
            Invoke("KillObj", animator.GetComponent<EnemyAnimatorEventFunctions>().DissolveTime);
            return true;
        }
        return false;
        //Material mat = GetComponent<Renderer>().material;
        //LeanTween.value(0f, 1f, dissolveTime).setEaseInOutQuad().setOnUpdate((float value) =>
        //{
        //    mat.SetFloat("_Dissolve", value);
        //});
    }

    private void KillObj()
    {
        Destroy(gameObject);
    }
    #endregion



    #region Coroutines

    #endregion
}