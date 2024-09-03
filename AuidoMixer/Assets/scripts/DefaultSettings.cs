using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultSettings : MonoBehaviour
{
    [SerializeField] private Slider[] _sliders;
    [SerializeField] private AudioSource[] _music;

    private float _defaultValue = 0.5f;

    private void Awake()
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].value = _defaultValue;
        }

        for (int i = 0; i < _music.Length; i++)
        {
            _music[i].volume = _defaultValue;
        }
    }
}
