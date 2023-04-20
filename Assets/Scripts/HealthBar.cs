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
    private float _speedChangeValue = 0.2f;
    private float _timeChangeValue = 1.0f;
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

        _changeHealth = StartCoroutine(ChangeHealth());
    }

    private void Heal(int healAmount)
    {
        _currentHealth += healAmount;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        
        _changeHealth = StartCoroutine(ChangeHealth());
    }

    private IEnumerator ChangeHealth()
    {
        float currentTime = 0.0f;

        while(currentTime < _timeChangeValue)
        {
            currentTime += Time.deltaTime;
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _currentHealth, _speedChangeValue);
            yield return null;
        }
    }
}
