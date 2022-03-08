using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    public GameObject [] Prefabs;
    public Transform Spawn;

    public void Create()
    {
        foreach (GameObject prefab in Prefabs)
            Instantiate(prefab, Spawn.position, Spawn.rotation);
    }
}
