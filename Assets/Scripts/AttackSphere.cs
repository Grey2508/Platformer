using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSphere : MonoBehaviour
{
    [SerializeField] float LifeTime = 5;
    [SerializeField] GameObject EffectPrefab;
    [SerializeField] int DamageValue = 1;
    
    void Start()
    {

        Destroy(gameObject, LifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyBullet(collision.gameObject.GetComponent<PlayerTakeDamage>());
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyBullet(other.attachedRigidbody.GetComponent<PlayerTakeDamage>());
    }

    private void DestroyBullet(PlayerTakeDamage playerTakeDamage)
    {
        playerTakeDamage?.TakeDamage(DamageValue);

        //Instantiate(EffectPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
