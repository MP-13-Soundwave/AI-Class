using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseManager : MonoBehaviour
{
    //protected is basically private,
    //but inherited classes also have access to it
    [SerializeField] protected float _health = 100;

    [SerializeField] protected float _maxHealth = 100;

    [SerializeField] protected Text _healthText;

    protected virtual void Start()
    {
        UpdateHealthText();
    }
    public void UpdateHealthText()
    {
        if (_healthText != null)
        {
            _healthText.text = _health.ToString();
        }
    }

    //abstract classes cannot be used, only children of abstract classes
    //abstract functions (inside an abstract class) has to be implemented by a child class

    public abstract void TakeTurn();

    public void Heal(float heal)
    {
        _health = Mathf.Min(_health + heal, _maxHealth);
        UpdateHealthText();
    }

    public void DealDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;    
            Debug.Log("I Died");
        }

        UpdateHealthText();
    }
}
