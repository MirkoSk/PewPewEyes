using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.eulerAngles = Vector3.Reflect(collision.transform.position, collision.contacts[0].normal);
    }
}
