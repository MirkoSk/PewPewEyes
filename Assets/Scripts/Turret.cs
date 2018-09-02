using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Turret : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] Animator ani;
    [SerializeField] LaserType laser;
    [SerializeField] Transform laserSpawnPoint;
    [SerializeField] float detectionRange = 20f;
    [SerializeField] float fireCoolDown = 3f;
    [SerializeField] LayerMask playerLayerMask;
    // Private
    float timer = 0f;
    Transform currentTarget;
    Transform player;
    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    

    private void FixedUpdate()
    {
        Collider collider = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange, playerLayerMask);
        if(colliders.Length != 0)
             collider = colliders[0];
        if (collider != null)
            currentTarget = collider.transform;
        if (player == null)
            player = currentTarget;
        if(currentTarget != null && timer <= 0f)
        {
            ani.SetTrigger("shoot");
        }
    }
    #endregion



    #region Public Functions
    public void Shoot()
    {
        GameObject lazor = Instantiate(laser.laserPrefab, laserSpawnPoint.position, Quaternion.identity);
        lazor.GetComponent<Rigidbody>().velocity = (player.position - laserSpawnPoint.position).normalized * laser.laserSpeed;
    }
    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}