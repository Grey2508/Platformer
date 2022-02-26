using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Renderer[] TargetRenderers;

    public void StartEffect()
    {
        StartCoroutine(BlinkEffect());
    }

    private IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            float value = Mathf.Sin(t * 30) * 0.5f + 0.5f;

            SetColor(new Color(value, 0, 0, 0));

            yield return null;
        }

        SetColor(Color.black);
    }

    private void SetColor(Color color)
    {
        foreach (Renderer renderer in TargetRenderers)
        {
            if (!renderer.gameObject.activeInHierarchy)
            {
                StopAllCoroutines();
                break;
            }

            foreach (Material material in renderer.materials)
                material.SetColor("_EmissionColor", color);
        }
    }
}
