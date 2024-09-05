using UnityEngine;
using UnityEngine.UI;

public class ColorBackground : MonoBehaviour
{
    [SerializeField] private Color _backgroundColorBegin;
    [SerializeField] private Color _backgroundColorEnd;

    [SerializeField] private Image _fill;

    [SerializeField] private Slider _slider;

    private void Awake()
    {
        ColorChanged();
    }

    private void Update()
    {
        ColorChanged();
    }

    private void ColorChanged()
    {
        _fill.color = Color.Lerp(_backgroundColorBegin, _backgroundColorEnd, _slider.value);
    }
}
