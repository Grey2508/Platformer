using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EvilForce : MonoBehaviour
{
    public Vector3 Power;
    public Transform ContactPoint;
    public UnityEvent ContactEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.body.CompareTag("Player"))
            return;

        collision.rigidbody?.AddForce(Power, ForceMode.VelocityChange);

        ContactPoint.position = collision.contacts[0].point;
        ContactEvent.Invoke();
    }
}
