using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsOnTriggerWithPlayer : MonoBehaviour
{
    public UnityEvent EventOnTrigger;
    public UnityEvent EventOnTriggerExit;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.attachedRigidbody.CompareTag("Player"))
            return;

        EventOnTrigger.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.attachedRigidbody.CompareTag("Player"))
            return;

        EventOnTriggerExit.Invoke();

    }
}
