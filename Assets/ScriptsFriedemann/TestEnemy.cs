using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestEnemy : MonoBehaviour {

    public Transform player;
    public GameObject bullet;

    private void FixedUpdate()
    {
        transform.LookAt(player);
    }

    public void Shoot()
    {
        Quaternion quaternion = Quaternion.LookRotation(player.position, Vector3.up);
        Instantiate(bullet, transform.position, quaternion);
    }
}
