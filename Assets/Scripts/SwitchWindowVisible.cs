using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWindowVisible : MonoBehaviour
{
    public void SwitchWindow()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
