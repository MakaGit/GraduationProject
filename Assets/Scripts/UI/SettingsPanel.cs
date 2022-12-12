using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SettingsPanel : UIPanel
{
    [SerializeField] private Slider slider;

    [SerializeField] private Button musicOnButton;
    [SerializeField] private Button musicOffButton;

    [SerializeField] private Button sfxOnButton;
    [SerializeField] private Button sfxOffButton;

    public event Action MusicButtonPressed;
    public event Action SFXButtonPressed;
    public event Action<float> VolumeChanged;

    public void Prepare(bool music, bool sfx, float volume)
    {
        musicOnButton.gameObject.SetActive(music);
        musicOffButton.gameObject.SetActive(!music);

        sfxOnButton.gameObject.SetActive(sfx);
        sfxOffButton.gameObject.SetActive(!sfx);

        slider.value = volume;

        musicOnButton.onClick.AddListener(ChangeMusic);
        musicOffButton.onClick.AddListener(ChangeMusic);

        sfxOnButton.onClick.AddListener(ChangeSFX);
        sfxOffButton.onClick.AddListener(ChangeSFX);

        slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnEnable()
    {
        musicOnButton.onClick.RemoveListener(ChangeMusic);
        musicOffButton.onClick.RemoveListener(ChangeMusic);

        sfxOnButton.onClick.RemoveListener(ChangeSFX);
        sfxOffButton.onClick.RemoveListener(ChangeSFX);

        slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeMusic()
    {
        MusicButtonPressed?.Invoke();

        Debug.Log("Music press");
    }

    private void ChangeSFX()
    {
        SFXButtonPressed?.Invoke();

        Debug.Log("SFX press");
    }

    private void ChangeVolume(float volume)
    {
        VolumeChanged?.Invoke(volume);

        Debug.Log("Volume press");
    }
}
