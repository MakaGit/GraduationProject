using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sFXSource;

    [Inject] private SaveSystem saveSystem;

    private UIManager uIManager;

    private bool music;
    private bool sfx;
    private float volume;


    private void OnEnable()
    {
        Prepare();

        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        saveSystem.SaveMusicState(music);
        saveSystem.SaveSFXState(sfx);
        saveSystem.SaveVolume(volume);

        uIManager.SettingsPanel.MusicButtonPressed -= ChangeMusic;
        uIManager.SettingsPanel.SFXButtonPressed -= ChangeSFX;
        uIManager.SettingsPanel.VolumeChanged -= ChangeVolume;

        sFXSource.Stop();

        Prepare();
    }

    private void OnDisable()
    {
        saveSystem.SaveMusicState(music);
        saveSystem.SaveSFXState(sfx);
        saveSystem.SaveVolume(volume);

        uIManager.SettingsPanel.MusicButtonPressed -= ChangeMusic;
        uIManager.SettingsPanel.SFXButtonPressed -= ChangeSFX;
        uIManager.SettingsPanel.VolumeChanged -= ChangeVolume;
    }

    private void Prepare()
    {
        uIManager = FindObjectOfType<UIManager>();

        music = saveSystem.LoadMusicState();
        sfx = saveSystem.LoadSFXState();
        volume = saveSystem.LoadVolume();

        uIManager.SettingsPanel.Prepare(music, sfx, volume);

        uIManager.SettingsPanel.MusicButtonPressed += ChangeMusic;
        uIManager.SettingsPanel.SFXButtonPressed += ChangeSFX;
        uIManager.SettingsPanel.VolumeChanged += ChangeVolume;

        musicSource.volume = volume;
        sFXSource.volume = volume;

        if (!musicSource.isPlaying && music)
            musicSource.Play();

        if (SceneManager.GetActiveScene().buildIndex != 0 && sfx)
            sFXSource.Play();
    }

    private void ChangeMusic()
    {
        music = !music;

        if (music)
            musicSource.Play();
        else
            musicSource.Stop();
    }

    private void ChangeSFX()
    {
        sfx = !sfx;

        if (sfx && SceneManager.GetActiveScene().buildIndex != 0)
            sFXSource.Play();
        else 
            sFXSource.Stop();
    }

    private void ChangeVolume(float volume)
    {
        this.volume = volume;

        musicSource.volume = volume;
        sFXSource.volume = volume;
    }
}
