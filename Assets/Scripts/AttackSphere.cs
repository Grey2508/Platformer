using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSphere : MonoBehaviour
{
    [SerializeField] float LifeTime = 5;
    [SerializeField] GameObject EffectPrefab;
    void Start()
    {

        Destroy(gameObject, LifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        //Instantiate(EffectPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
