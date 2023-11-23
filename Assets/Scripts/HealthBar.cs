using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _player;
    [SerializeField] private TMP_Text _healthDisplay;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _healthSliderSmooth;
    [SerializeField] private float _duration;

    private float _step = 100;

    private void Awake()
    {
        _healthSlider.value = _player.MaxHealth;
        _healthSliderSmooth.value = _player.MaxHealth;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealtChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealtChanged;
    }

    private void OnHealtChanged(float health)
    {
        _healthDisplay.text = health.ToString() + "/" + _player.MaxHealth;

        _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, health, _step);

        StartCoroutine(ChangeHealthSmooth());
    }

    private IEnumerator ChangeHealthSmooth()
    { 
        while (_healthSliderSmooth.value != _player.CurrentHealth)
        {
            _healthSliderSmooth.value = Mathf.MoveTowards(_healthSliderSmooth.value, _player.CurrentHealth, _duration * Time.deltaTime);

            yield return null;
        }

    }
}

