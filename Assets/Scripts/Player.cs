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
            Debug.Log("� ������ ������ - " + _health + " ��");
        }
        else
        {
            Debug.Log("����� �����");
        }
    }

    public void Heal()
    {
        if(_health < 100)
        {
            _health += _amountDifference;
            Debug.Log("� ������ ������ - " + _health + " ��");
        }
        else
        {
            Debug.Log("�������� ������ �� ����");
        }
    }
}
