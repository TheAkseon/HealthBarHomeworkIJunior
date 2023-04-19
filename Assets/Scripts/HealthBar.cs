using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _healthBar;

    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _amountDifference = 10;
    private int _currentHealth;
    private float _speedChangeValue = 0.3f;
    private Coroutine _changeHealth;

    public void OnDamageButtonClicked()
    {
        TakeDamage(_amountDifference);
        _player.TakeDamage();
    }

    public void OnHealButtonClicked()
    {
        Heal(_amountDifference);
        _player.Heal();
    }

    private void Start()
    {
        _healthBar.maxValue = _maxHealth;
        _currentHealth = _player.Health;
        _healthBar.value = _player.Health;
    }

    private void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);

        if (_changeHealth != null)
        {
            _changeHealth = StartCoroutine(WaitForCoroutine(ChangeHealth()));
        }
        else
        {
            _changeHealth = StartCoroutine(ChangeHealth());
        }
    }

    private void Heal(int healAmount)
    {
        _currentHealth += healAmount;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);

        if (_changeHealth != null)
        {
            _changeHealth = StartCoroutine(WaitForCoroutine(ChangeHealth()));
        }
        else
        {
            _changeHealth = StartCoroutine(ChangeHealth());
        }
    }

    private IEnumerator ChangeHealth()
    {
        float startTime = Time.time;
        float startValue = _healthBar.value;

        while (Time.time < startTime + _speedChangeValue)
        {
            float elapsedTime = Time.time - startTime;
            float progress = Mathf.Clamp01(elapsedTime / _speedChangeValue);
            float currentValue = Mathf.Lerp(startValue, _currentHealth, progress);
            _healthBar.value = currentValue;
            yield return null;
        }
    }

    private IEnumerator WaitForCoroutine(IEnumerator coroutine)
    {
        yield return StartCoroutine(coroutine);
    }
}
