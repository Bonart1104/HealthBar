using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _healthPoints;

    public event UnityAction <float> HealthChanged;
   
    private float _minHealt = 0;
    private float _health;

    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealt;
    public float CurrentHealth => _health;

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }

    public void Heal()
    { 
        _health += _healthPoints;

        if(_health > _maxHealth)
            _health = _maxHealth;
        
        HealthChanged?.Invoke(_health);
    }


    public void TakeDamage()
    {
        _health -= _damage;

        if(_health < _minHealt)
            _health = _minHealt;

        HealthChanged?.Invoke(_health);
    }

}
