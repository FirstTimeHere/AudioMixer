using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    [SerializeField] private Button _musicButton;
    [SerializeField] private AudioSource _audio;

    protected void OnEnable()
    {
        _musicButton.onClick.AddListener(ClickButton);
    }

    protected void OnDisable()
    {
        _musicButton.onClick.RemoveListener(ClickButton);
    }

    private void ClickButton()
    {
        _audio.Play();
    }
}

