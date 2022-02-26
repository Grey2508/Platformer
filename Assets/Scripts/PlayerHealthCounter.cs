using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthCounter : MonoBehaviour
{
    [SerializeField] int Health = 5;
    [SerializeField] int MaxHealth = 8;

    [SerializeField] HealthUI HealthUI;

    [SerializeField] DamageScreen DamageScreen;


    public static PlayerHealthCounter Instance;

    private int _defaultHealth;

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
        _defaultHealth = Health;
        Inicialize();
    }

    public void Inicialize()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }

    public void SubstituteHealth(int damageValue, PlayerTakeDamage sender)
    {
        Health -= damageValue;

        HealthUI.DisplayHealth(Health);

        DamageScreen.StartEffect();

        if (Health <= 0)
        {
            Health = 0;
            sender.Die();
        }
    }

    public void AddHealth(int healthValue)
    {
        Health += healthValue;

        HealthUI.DisplayHealth(Health);

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void Reset()
    {
        Health = _defaultHealth;
        Inicialize();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
