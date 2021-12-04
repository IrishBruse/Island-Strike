using UnityEngine;
using UnityEngine.Audio;

public class SettingsPage : MonoBehaviour
{
    public AudioMixerGroup music;

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void ChangeMusic(float val)
    {
        music.audioMixer.SetFloat("Music", (1f - val) * -40);
        // music.SetFloat
    }

    public void ChangeSfx(float val)
    {
        music.audioMixer.SetFloat("Sfx", (1f - val) * -40);
        // music.SetFloat
    }
}
