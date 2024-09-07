using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SliderValueChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _slider;

    [Header("")]
    [SerializeField] private ParametrMixerNames _parametrName;

    private float _multiplier = 20f;

    private string _parametr = "";

    private void Awake()
    {
        _parametr = _parametrName.ToString();
    }

    protected void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeSlider);
    }

    protected void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeSlider);
    }

    private void ChangeSlider(float value)
    {
        _mixer.audioMixer.SetFloat(_parametr, Mathf.Log10(value) * _multiplier);
    }
}