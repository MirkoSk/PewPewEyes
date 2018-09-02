using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TrailRenderer))]
public class Laser : MonoBehaviour 
{

    #region Variable Declarations

    // Serialized Fields
    public LaserType type;

    [Header("References")]
    [SerializeField] LayerMask shieldLayer;
    [SerializeField] GameObject aimingLinePrefab;
    [SerializeField] Gradient shotGoodGradient;


    // Private
    bool isGood;
    int currentReflections = 0;
    Rigidbody rb;
    LineRenderer aimingLine;
    TrailRenderer trail;

    public Enemy Owner { get; set; }
    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        currentReflections += 1;
        if (collision.collider.CompareTag(Constants.TAG_ENEMY) && isGood)
        {
            Enemy enemy = collision.collider.attachedRigidbody.GetComponent<Enemy>();
            if (enemy == Owner)
            {

            }
            else
            {
                enemy.TakeDamage(type.damage);
            }
        }
        else if (collision.collider.CompareTag(Constants.TAG_SHIELD))
        {
            collision.collider.GetComponent<AudioSource>().Play();
            trail.colorGradient = shotGoodGradient;
            isGood = true;
        }
        else if (collision.collider.CompareTag(Constants.TAG_PLAYER) && !isGood)
        {
            collision.collider.GetComponent<Player>().DealDamage(type.damage);
        }
        if (currentReflections > type.maxReflections)
        {
            Destroy(gameObject);
        }
    }
    #endregion



    #region Public Functions
    public void UpdateAimAssist(float lineLength, float lineDuration)
    {
        if (!GameManager.Instance.ShieldController.ShieldUp) return;

        Ray ray = new Ray(transform.position, rb.velocity.normalized);
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo, 20f, shieldLayer);

        if (hitInfo.point != Vector3.zero) Debug.DrawLine(ray.origin, hitInfo.point, Color.green, lineLength);
        else Debug.DrawRay(ray.origin, ray.direction, Color.red, 3f);

        // Update LineRenderer if we hit the players shield
        if (hitInfo.point != Vector3.zero)
        {
            Vector3 reflection = Vector3.Reflect(ray.direction, hitInfo.normal);

            // Spawn LineRenderer if called for the first time
            if (aimingLine == null)
            {
                aimingLine = GameObject.Instantiate(aimingLinePrefab, hitInfo.point, Quaternion.identity, transform).GetComponent<LineRenderer>();
                aimingLine.GetComponent<AimingLine>().LifeTime = lineDuration;
                aimingLine.positionCount = 3;
            }

            aimingLine.SetPosition(0, transform.position);
            aimingLine.SetPosition(1, hitInfo.point);
            aimingLine.SetPosition(2, hitInfo.point + reflection * lineLength);
        }
        else if (hitInfo.point == Vector3.zero && aimingLine != null)
        {
            Destroy(aimingLine.gameObject);
        }
    }
    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}