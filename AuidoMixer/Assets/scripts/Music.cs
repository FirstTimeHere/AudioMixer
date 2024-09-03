using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _firstMusic;
    [SerializeField] private AudioSource _secondMusic;
    [SerializeField] private AudioSource _thirdMusic;

    [SerializeField] private Slider _sliderAllMusic;
    [SerializeField] private Slider _sliderButtonsMusic;
    [SerializeField] private Slider _sliderBackgroundMusic;

    private List<AudioSource> _allMusic = new List<AudioSource>();

    private bool _isPlaying;

    private void Awake()
    {
        _allMusic.Add(_backgroundMusic);
        _allMusic.Add(_firstMusic);
        _allMusic.Add(_secondMusic);
        _allMusic.Add(_thirdMusic);
    }

    public void MuteMusic()
    {
        _isPlaying = !_isPlaying;

        for (int i = 0; i < _allMusic.Count; i++)
        {
            _allMusic[i].mute = _isPlaying;
        }
    }

    public void ChangeVolumeMusic()
    {
        for (int i = 0; i < _allMusic.Count; i++)
        {
            _allMusic[i].volume = _sliderAllMusic.value;
        }
    }

    public void ChangeVolumeButtonsMusic()
    {
        for (int i = 1; i < _allMusic.Count; i++)
        {
            _allMusic[i].volume = _sliderButtonsMusic.value;
        }
    }

    public void ChangeVolumeBackgroundMusic()
    {
        _backgroundMusic.volume = _sliderBackgroundMusic.value;
    }
}
