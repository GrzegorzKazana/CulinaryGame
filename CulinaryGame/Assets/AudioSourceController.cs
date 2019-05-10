using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceController : MonoBehaviour
{
    public static AudioMixer AudioMixer;
    public static string MusicVolumeSliderKey = "MusicVolumeSlider";
    // Start is called before the first frame update
    void Start()
    {
        AudioMixer = GameObject.FindGameObjectWithTag("GameAudioSource").GetComponent<AudioSource>().
            outputAudioMixerGroup.audioMixer;
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeSliderKey);
        AudioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
