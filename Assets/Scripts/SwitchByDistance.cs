using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class SwitchByDistance : MonoBehaviour
{
    public bool Active = true;
    public float ActiveDistance = 20;

    public MonoBehaviour[] Scripts;

    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, _playerTransform.position);

        if (Mathf.Abs(distance) < ActiveDistance - 2 && !Active)
        {
            Active = true;
            SetActive();
        }

        if (Mathf.Abs(distance) > ActiveDistance && Active)
        {
            Active = false;
            SetActive();
        }
    }

    private void SetActive()
    {
        foreach (MonoBehaviour script in Scripts)
            script.enabled = Active;

        if (!Active)
        {
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            if (rigidbody)
                rigidbody.velocity = Vector3.zero;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.DrawWireDisc(transform.position, Vector3.forward, ActiveDistance);
    }
#endif
}
