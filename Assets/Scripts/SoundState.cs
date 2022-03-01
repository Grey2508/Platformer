using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundState : MonoBehaviour
{
    public static SoundState Instance;

    [SerializeField] Sprite[] SoundIcons;

    public bool IsSoundOn
    {
        get;
        private set;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void SwitchSoundState()
    {
        IsSoundOn = !IsSoundOn;
    }

    public Sprite GetCurrentIcon()
    {
        return IsSoundOn ? SoundIcons[0] : SoundIcons[1];
    }
}
