using UnityEngine;
using UnityEngine.UI;

public class ColorSliderFill : MonoBehaviour
{
    [SerializeField] private Color _sliderFillBegin;
    [SerializeField] private Color _sliderFillEnd;

    [SerializeField] private Image _fill;

    [SerializeField] private Slider _slider;

    private void Awake()
    {
        ChangeColor(_slider.value);
    }

    protected void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeColor);
    }

    protected void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeColor);
    }

    private void ChangeColor(float sliderValue)
    {
        _fill.color = Color.Lerp(_sliderFillBegin, _sliderFillEnd, sliderValue);
    }
}
