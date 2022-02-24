using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float EffectSpeed = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.attachedRigidbody.CompareTag("Player"))
            return;

        ScoreCounter.AddScore(10);

        StartCoroutine(CoinEffect());
    }

    private IEnumerator CoinEffect()
    {
        int sign = 1;

        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            float x = transform.position.x;
            float y = transform.position.y + sign * EffectSpeed * Time.deltaTime;
            float z = transform.position.z;

            transform.position = new Vector3(x, y, z);

            if (t > 0.5f)
            {
                sign = -1;

                transform.localScale -= Vector3.one * Time.deltaTime;
            }
            yield return null;
        }

        Destroy(gameObject);
    }
}
