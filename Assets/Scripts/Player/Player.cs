using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    [SerializeField] private int _minHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _getDamageValue;
    [SerializeField] private int _getHealthValue;

    public event UnityAction<int, int> HealthChanged;

    public void GetDamage()
    {
        ChangeHealth(_getDamageValue);
    }

    public void GetHealth()
    {
        ChangeHealth(_getHealthValue);
    }

    private void ChangeHealth(int healthValue)
    {
        _health += healthValue;

        if (_health <= _minHealth)
            _health = _minHealth;

        if (_health >= _maxHealth)
            _health = _maxHealth;

        HealthChanged?.Invoke(_health, _maxHealth);
    }
}