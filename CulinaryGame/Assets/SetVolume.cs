using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    private string _sliderMusicVolume = "MusicVolume";
    
    void Awake()
    {
        var slider = GameObject.FindGameObjectWithTag(AudioSourceController.MusicVolumeSliderKey).GetComponent<UnityEngine.UI.Slider>();
        slider.value = PlayerPrefs.GetFloat(AudioSourceController.MusicVolumeSliderKey);

        AudioSourceController.AudioMixer.SetFloat(_sliderMusicVolume, Mathf.Log10(slider.value) * 20);
    }

    public void SetLevel(float sliderValue)
    {
        AudioSourceController.AudioMixer.SetFloat(_sliderMusicVolume, Mathf.Log10(sliderValue)*20);
        PlayerPrefs.SetFloat(AudioSourceController.MusicVolumeSliderKey, sliderValue);
    }
}
