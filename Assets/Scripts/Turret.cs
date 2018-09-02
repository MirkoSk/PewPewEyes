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
    [SerializeField] ParticleSystem chargeLaser;
    [SerializeField] GameObject turretBurst;
    [SerializeField] AudioSource shotSoundSource;
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
        if (currentTarget != null && timer >= fireCoolDown)
        {
            ani.SetTrigger("shoot");
            timer = 0f;
        }

        timer += Time.deltaTime;
    }
    #endregion



    #region Public Functions
    public void Shoot()
    {
        shotSoundSource.Play();
        GameObject lazor = Instantiate(laser.laserPrefab, laserSpawnPoint.position, Quaternion.identity);
        lazor.GetComponent<Rigidbody>().velocity = ((player.transform.position + player.GetComponent<CharacterController>().velocity * Vector3.Distance(laserSpawnPoint.transform.position, player.position) / laser.laserSpeed) - laserSpawnPoint.position).normalized * laser.laserSpeed;
        Instantiate(turretBurst, laserSpawnPoint.position, Quaternion.identity);
        currentTarget = null;
    }

    public void Charge()
    {
        chargeLaser.Play();
    }
    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}