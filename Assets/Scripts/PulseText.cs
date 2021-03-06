using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PulseText : MonoBehaviour
{
    public Text Text;
    public int MaxSize = 300;
    public int MinSize = 40;
    public int Speed = 100;
    public float TimeAnimation = 1;
    public bool Infinitely = false;
    public bool PlayOnAwake = false;

    private float _timer;
    private bool _bigger = true;

    private void Start()
    {
        if (PlayOnAwake)
            StartEffect();
    }

    public void StartEffect()
    {
        gameObject.SetActive(true);

        StartCoroutine(ShowEffect());
    }

    private IEnumerator ShowEffect()
    {

        for (float t = 0; t < TimeAnimation; t += Time.deltaTime)
        {
            _timer += Time.deltaTime;

            int size = Mathf.FloorToInt(_bigger ? MinSize + _timer * Speed : MaxSize - _timer * Speed);
            Text.fontSize = size;

            if (size > MaxSize || size < MinSize)
            {
                _bigger = !_bigger;

                _timer = 0;
            }

            yield return null;
        }

        if (!Infinitely)
            gameObject.SetActive(false);
    }
}
