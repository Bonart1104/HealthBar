using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _healthPoints;

    public event UnityAction <float> HealthChanged;
   
    private float _minHealt = 0;
    private float _currentHealth;

    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealt;
    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth);
    }

    public void Heal()
    { 
        _currentHealth += _healthPoints;

        if(_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        
        HealthChanged?.Invoke(_currentHealth);
    }


    public void TakeDamage()
    {
        _currentHealth -= _damage;

        if(_currentHealth < _minHealt)
            _currentHealth = _minHealt;

        HealthChanged?.Invoke(_currentHealth);
    }

}
