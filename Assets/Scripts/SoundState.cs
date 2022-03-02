using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        IsSoundOn = Saver.Instance.GetSoundSetting();
        
        SetSoundState();
    }

    public void SwitchSoundState()
    {
        IsSoundOn = !IsSoundOn;

        SetSoundState();
    }

    public Sprite GetCurrentIcon()
    {
        return IsSoundOn ? SoundIcons[0] : SoundIcons[1];
    }

    private void OnApplicationQuit()
    {
        Saver.Instance.SetSoundSetting();
    }

    private void SetSoundState()
    {
        if (IsSoundOn)
            AudioSettings.Mobile.StartAudioOutput();
        else
            AudioSettings.Mobile.StopAudioOutput();
    }
}
