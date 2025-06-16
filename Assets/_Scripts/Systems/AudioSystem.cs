using UnityEngine;
using UnityEngine.Audio;

public class AudioSystem : Singleton<AudioSystem>
{
    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _sfxSource;

    // Audio Mixer
    [SerializeField] AudioMixer _audioMixer;
    public const string MIXER_MASTER_VOLUME_KEY = "Master Volume";
    public const string MIXER_MUSIC_VOLUME_KEY = "Music Volume";
    public const string MIXER_SFX_VOLUME_KEY = "SFX Volume";

    // Initialize Mixer Volumes
    //private void Start() { LoadVolume(); }

    private void PlaySFX(AudioClip clip)
    { 
        if(_sfxSource != null) { _sfxSource.PlayOneShot(clip); }
        else { LogSystem.Instance.Log("No Instance of SFX Source", LogType.Error); }
    }

    private void PlayMusic(AudioClip clip)
    {
        if (_musicSource != null) { _musicSource.PlayOneShot(clip); }
        else { LogSystem.Instance.Log("No Instance of Music Source", LogType.Error); }
    }

    // Load Audio Volume | Audio Saved In VolumeSettings.cs
    //private void LoadVolume()
    //{
    //    float volume;

    //    volume = PlayerPrefs.GetFloat(MIXER_MASTER_VOLUME_KEY, 0.5f);
    //    _audioMixer.SetFloat(VolumeSettings.MIXER_MAIN_VOLUME, Mathf.Log10(volume));

    //    volume = PlayerPrefs.GetFloat(MIXER_MUSIC_VOLUME_KEY, 0.5f);
    //    _audioMixer.SetFloat(VolumeSettings.MIXER_MUSIC_VOLUME, Mathf.Log10(volume));

    //    volume = PlayerPrefs.GetFloat(MIXER_SFX_VOLUME_KEY, 0.5f);
    //    _audioMixer.SetFloat(VolumeSettings.MIXER_SFX_VOLUME, Mathf.Log10(volume));

    //}
}
