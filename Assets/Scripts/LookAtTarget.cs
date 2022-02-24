using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform TargetTransform;

    void Update()
    {
        transform.LookAt(TargetTransform, Vector3.up);
    }
}
