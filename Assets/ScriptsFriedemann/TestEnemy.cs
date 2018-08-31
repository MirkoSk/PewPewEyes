using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour {

    public Transform player;
    public GameObject 

    private void FixedUpdate()
    {
        transform.LookAt(player);
    }

    private void Shoot()
    {

    }
}
