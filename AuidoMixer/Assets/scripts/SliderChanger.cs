using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderChanger : MonoBehaviour
{
    [SerializeField] private Sprite _spriteMinValue;
    [SerializeField] private Sprite _spriteDefaultValue;
    [SerializeField] private Sprite _spriteMaxValue;

    private Slider _slider;

    private float _minChangeValue = 0.3f;
    private float _maxChangeValue = 0.6f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        if (_slider.value <= _minChangeValue)
            _slider.image.sprite = _spriteMinValue;
        else if (_slider.value >= _minChangeValue && _slider.value <= _maxChangeValue)
            _slider.image.sprite = _spriteDefaultValue;
        else if (_slider.value >= _maxChangeValue)
            _slider.image.sprite = _spriteMaxValue;
    }
}
