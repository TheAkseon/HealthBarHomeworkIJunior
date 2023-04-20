using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _healthBar;

    private float _speedChangeValue = 0.5f;
    private Coroutine _changeHealth;

    private void Start()
    {
        _healthBar.maxValue = _player.MaxHealth;
        _healthBar.value = _player.Health;
        _healthBar.minValue = _player.MinHealth;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }


    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        if(_changeHealth != null)
        {
            StopCoroutine(_changeHealth);
        }

        _changeHealth = StartCoroutine(ChangeHealth(health));
    }

    private IEnumerator ChangeHealth(float target)
    {
        while(_healthBar.value != target)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, target, _speedChangeValue);
            yield return null;
        }
    }
}
