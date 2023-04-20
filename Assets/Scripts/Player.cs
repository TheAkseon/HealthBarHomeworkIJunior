using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 100;
    private int _amountDifference = 10;

    public int Health 
    {
        get => _health;
        private set => _health = value;
    }

    public void TakeDamage()
    {
        if(_health > 0)
        {
            _health -= _amountDifference;
            Debug.Log("У игрока теперь - " + _health + " хп");
        }
        else
        {
            Debug.Log("Игрок мертв");
        }
    }

    public void Heal()
    {
        if(_health < 100)
        {
            _health += _amountDifference;
            Debug.Log("У игрока теперь - " + _health + " хп");
        }
        else
        {
            Debug.Log("Здоровья больше не надо");
        }
    }
}
