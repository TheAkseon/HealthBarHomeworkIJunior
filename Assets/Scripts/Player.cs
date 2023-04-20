using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<int> HealthChanged;

    public int Health { get; private set; } = 100;
    public int MaxHealth { get; private set; } = 100;
    public int MinHealth { get; private set; } = 0;

    public void TakeDamage(int amountDifference)
    {
        Health -= amountDifference;

        if (Health < MinHealth)
        {
            Health = MinHealth;
            Debug.Log("Игрок мертв");
        }

        Debug.Log("У игрока теперь - " + Health + " хп");

        HealthChanged?.Invoke(Health);
    }

    public void Heal(int amountDifference)
    {
        Health += amountDifference;

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
            Debug.Log("Здоровья больше не нужно");
        }

        Debug.Log("У игрока теперь - " + Health + " хп");

        HealthChanged?.Invoke(Health);
    }
}
