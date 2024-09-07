using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicMixer : MonoBehaviour
{
    [Header("Миксер")]
    [SerializeField] private AudioMixerGroup _audioMixer;

    [Header("Кнопка вкл/выкл музыку")]
    [SerializeField] private Button _buttonOnOff;

    [Header("Изменение громкости")]
    [SerializeField] private Slider _sliderAllMusic;

    private bool _isPlaying;

    private float _minValueMixerDB = -80;

    protected void OnEnable()
    {
        _buttonOnOff.onClick.AddListener(ClickButtonOnOff);
    }

    protected void OnDisable()
    {
        _buttonOnOff.onClick.RemoveListener(ClickButtonOnOff);
    }

    private void ClickButtonOnOff()
    {
        _isPlaying = !_isPlaying;

        if (_isPlaying)
            _audioMixer.audioMixer.SetFloat(ParametrMixerNames.MasterVolume.ToString(), _minValueMixerDB);
        else
            _audioMixer.audioMixer.SetFloat(ParametrMixerNames.MasterVolume.ToString(), _sliderAllMusic.value);
    }
}
