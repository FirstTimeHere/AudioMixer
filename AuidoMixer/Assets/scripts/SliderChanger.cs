using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderChanger : MonoBehaviour
{
    [SerializeField] private Sprite _spriteMinValue;
    [SerializeField] private Sprite _spriteDefaultValue;
    [SerializeField] private Sprite _spriteMaxValue;

    [SerializeField] private Image _background;

    private Slider _slider;

    private float _minValue = 0f;
    private float _minChangeValue = 0.3f;
    private float _maxChangeValue = 0.6f;
    private float _maxValue = 1f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        ChangeSprite();
        ChangeColor();
    }

    private void ChangeSprite()
    {
        if (_slider.value == _minValue || _slider.value <= _minChangeValue)
            _slider.image.sprite = _spriteMinValue;
        else if (_slider.value >= _minChangeValue && _slider.value <= _maxChangeValue)
            _slider.image.sprite = _spriteDefaultValue;
        else if (_slider.value >= _maxChangeValue || _slider.value == _maxValue)
            _slider.image.sprite = _spriteMaxValue;
    }

    private void ChangeColor()
    {
        _background.color = Color.Lerp(Color.white, Color.green, _slider.value);
    }
}
