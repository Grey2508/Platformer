using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTakeDamage : MonoBehaviour
{
    [SerializeField] PitchAndPlay TakeDamageSound;
    [SerializeField] PitchAndPlay AddHealthSound;

    [SerializeField] UnityEvent EventOnTakeDamage;

    private bool _invulnerable = false; //неу€звимость

    public void TakeDamage(int damageValue)
    {
        if (!_invulnerable)
        {
            PlayerHealthCounter.Instance.SubstituteHealth(damageValue);

            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), 1);

            EventOnTakeDamage.Invoke();
        }
    }

    public void AddHealth(int healthValue)
    {
        PlayerHealthCounter.Instance.AddHealth(healthValue);
        AddHealthSound.Play();
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }
}
