using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChenged;
        _slider.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChenged;
    }

    public void OnValueChenged(int currentHealth, int maxHealth)
    {
        StartCoroutine(ChangeBar(currentHealth, maxHealth));
    }

    private IEnumerator ChangeBar(int currentHealth, int maxHealth)
    {
        do
        {
            _slider.value = Mathf.MoveTowards(_slider.value, (float)currentHealth / maxHealth, Time.deltaTime);
            yield return null;
        } while (_slider.value != (float)currentHealth / maxHealth);
    }
}