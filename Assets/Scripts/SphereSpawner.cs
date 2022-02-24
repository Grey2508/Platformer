using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] GameObject AttackSpherePrefab;
    [SerializeField, Min(0)] float ShotDelay = 2;
    [SerializeField] float SphereSpeed = 5;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > ShotDelay)
        {
            var newSphere = Instantiate(AttackSpherePrefab, transform.position, transform.rotation);
            newSphere.GetComponent<Rigidbody>().velocity = transform.forward * SphereSpeed;

            _timer = 0;
        }
    }
}
