using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicMixer : MonoBehaviour
{
    private const string _masterVolume = "MasterVolume";
    private const string _backgroundVolume = "BackgroundVolume";
    private const string _buttonsVolume = "ButtonsVolume";
    private const string _musicVolume = "MusicVolume";

    [Header("Миксер")]
    [SerializeField] private AudioMixerGroup _audioMixer;

    [Header("Кнопки, воиспрозводяющие музыку")]
    [SerializeField] private Button _buttonOnOff;
    [SerializeField] private Button _buttonFirst;
    [SerializeField] private Button _buttonSecond;
    [SerializeField] private Button _buttonThird;

    [Header("Изменение громкости")]
    [SerializeField] private Slider _sliderAllMusic;
    [SerializeField] private Slider _sliderButtonsMusic;
    [SerializeField] private Slider _sliderBackgroundMusic;

    [Header("Музыка кнопок")]
    [SerializeField] private AudioSource _firstButtonAudio;
    [SerializeField] private AudioSource _secondButtonAudio;
    [SerializeField] private AudioSource _thirdButtonAudio;

    private bool _isPlaying;

    private float _minValueMixerDB = -80;
    private float _multiplier = 20;


    protected void OnEnable()
    {
        _buttonOnOff.onClick.AddListener(ClickButtonOnOff);
        _buttonFirst.onClick.AddListener(PlayAudioButtonFirst);
        _buttonSecond.onClick.AddListener(PlayAudioButtonSecond);
        _buttonThird.onClick.AddListener(PlayAudioButtonThird);

        _sliderAllMusic.onValueChanged.AddListener(ChangeVolumeAllMusic);
        _sliderButtonsMusic.onValueChanged.AddListener(ChangeVolumeButtonsMusic);
        _sliderBackgroundMusic.onValueChanged.AddListener(ChangeVolumeBackgroundMusic);
    }

    protected void OnDisable()
    {
        _buttonOnOff.onClick.RemoveListener(ClickButtonOnOff);
        _buttonFirst.onClick.RemoveListener(PlayAudioButtonFirst);
        _buttonSecond.onClick.RemoveListener(PlayAudioButtonSecond);
        _buttonThird.onClick.RemoveListener(PlayAudioButtonThird);

        _sliderAllMusic.onValueChanged.RemoveListener(ChangeVolumeAllMusic);
        _sliderButtonsMusic.onValueChanged.RemoveListener(ChangeVolumeButtonsMusic);
        _sliderBackgroundMusic.onValueChanged.RemoveListener(ChangeVolumeBackgroundMusic);
    }

    private void ClickButtonOnOff()
    {
        _isPlaying = !_isPlaying;

        if (_isPlaying)
            _audioMixer.audioMixer.SetFloat(_masterVolume, _minValueMixerDB);
        else
            _audioMixer.audioMixer.SetFloat(_masterVolume, _sliderAllMusic.value);
    }

    private void ChangeVolumeAllMusic(float volumeValue)
    {
        _audioMixer.audioMixer.SetFloat(_musicVolume, Mathf.Log10(volumeValue) * _multiplier);
    }

    private void ChangeVolumeBackgroundMusic(float volumeValue)
    {
        _audioMixer.audioMixer.SetFloat(_backgroundVolume, Mathf.Log10(volumeValue) * _multiplier);
    }

    private void ChangeVolumeButtonsMusic(float volumeValue)
    {
        _audioMixer.audioMixer.SetFloat(_buttonsVolume, Mathf.Log10(volumeValue) * _multiplier);
    }

    private void PlayAudioButtonFirst()
    {
        _firstButtonAudio.Play();
    } 
    
    private void PlayAudioButtonSecond()
    {
        _secondButtonAudio.Play();
    }
    
    private void PlayAudioButtonThird()
    {
        _thirdButtonAudio.Play();
    }
}
