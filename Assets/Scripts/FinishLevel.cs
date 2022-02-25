using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public int NextLevelIndex;

    private void OnTriggerEnter(Collider other)
    {
        SceneSwitcher.Instance.LoadScene(NextLevelIndex);
    }
}
