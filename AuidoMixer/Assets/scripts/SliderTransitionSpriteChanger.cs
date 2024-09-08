using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderTransitionSpriteChanger : MonoBehaviour
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
        _slider.image.sprite = _spriteMaxValue;
    }

    protected void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeSprite);
    }

    protected void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeSprite);
    }

    private void ChangeSprite(float value)
    {
        if (value <= _minChangeValue)
            _slider.image.sprite = _spriteMinValue;
        else if (value >= _minChangeValue && value <= _maxChangeValue)
            _slider.image.sprite = _spriteDefaultValue;
        else if (value >= _maxChangeValue)
            _slider.image.sprite = _spriteMaxValue;
    }
}
