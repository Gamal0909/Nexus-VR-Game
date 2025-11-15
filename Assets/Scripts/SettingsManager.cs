using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Dropdown qualityDropdown;
    public Toggle bgSoundToggle;
    public Slider volumeSlider;
    public AudioSource bgMusic;
    void Start() {
        qualityDropdown.onValueChanged.AddListener(SetQuality);
        bgSoundToggle.onValueChanged.AddListener(ToggleMusic);
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetQuality(int index) {
        Debug.Log($"Qualitchanged to {qualityDropdown.options[index]}");
        QualitySettings.SetQualityLevel(index);
    }

    void ToggleMusic(bool isOn) {
        Debug.Log($"Music changed to {isOn}");
        bgMusic.mute = !isOn;
    }

    void SetVolume(float value) {
        Debug.Log($"Volume changed to {value}");
        bgMusic.volume = value;
    }
}
