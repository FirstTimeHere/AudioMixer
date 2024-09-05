using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;

    private const string _masterVolume = "MasterVolume";
    private const string _backgroundVolume = "BackgroundVolume";
    private const string _buttonsVolume = "ButtonsVolume";

    private bool _isPlaying = true;

    private float _minValueMixerDB = -80;
    private float _maxValueMixerDB = 0;
    private float _multiplier = 20;

    public void ClickButtonOnOff()
    {
        _isPlaying = !_isPlaying;

        if (_isPlaying)
            _audioMixer.audioMixer.SetFloat(_masterVolume, _maxValueMixerDB);
        else
            _audioMixer.audioMixer.SetFloat(_masterVolume, _minValueMixerDB);
    }

    public void ChangeVolumeAllMusic(Slider slider)
    {
        _audioMixer.audioMixer.SetFloat(_masterVolume, Mathf.Log10(slider.value) * _multiplier);
    }
    public void ChangeVolumeBackgroundMusic(Slider slider)
    {
        _audioMixer.audioMixer.SetFloat(_backgroundVolume, Mathf.Log10(slider.value) * _multiplier);
    }
    public void ChangeVolumeButtonsMusic(Slider slider)
    {
        _audioMixer.audioMixer.SetFloat(_buttonsVolume, Mathf.Log10(slider.value) * _multiplier);
    }

    public void PlayAudioButton(AudioSource audioSource)
    {
        audioSource.Play();
    }
}
