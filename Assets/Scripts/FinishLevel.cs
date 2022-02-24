using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public int NextLevelIndex;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.LoadScene(NextLevelIndex);
    }
}
