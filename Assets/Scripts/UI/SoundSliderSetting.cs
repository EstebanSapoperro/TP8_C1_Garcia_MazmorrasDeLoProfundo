using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSliderSetting : MonoBehaviour
{
    [Header("Audio Sliders")]
    [SerializeField] Slider generalAudioSlider;
    [SerializeField] Slider uIAudioSlider;
    [SerializeField] Slider sFXAudioSlider;
    [SerializeField] Slider musicAudioSlider;
    [Header("Sounds and Mixer")]
    [SerializeField] AudioMixer mixerSelected;
    [SerializeField] AudioSource sliderSound;
    [SerializeField] AudioClip soundEffect;


    private void Awake()
    {
        generalAudioSlider.onValueChanged.AddListener(OnGeneralChangeValue);
        uIAudioSlider.onValueChanged.AddListener(OnuIChangeValue);
        sFXAudioSlider.onValueChanged.AddListener(OnsFXChangeValue);
        musicAudioSlider.onValueChanged.AddListener(OnMusicChangeValue);
    }
    private void OnDestroy()
    {
        generalAudioSlider.onValueChanged.RemoveAllListeners();
        uIAudioSlider.onValueChanged.RemoveAllListeners();
        sFXAudioSlider.onValueChanged.RemoveAllListeners();
        musicAudioSlider.onValueChanged.RemoveAllListeners();
    }
    private void Start()
    {
        generalAudioSlider.value = PlayerPrefs.GetFloat("GeneralAudio");
        uIAudioSlider.value = PlayerPrefs.GetFloat("UIAudio");
        sFXAudioSlider.value = PlayerPrefs.GetFloat("SFXAudio");
        musicAudioSlider.value = PlayerPrefs.GetFloat("MusicAudio");
    }
    private void OnGeneralChangeValue(float value)
    {
        ChangeSoundValue("GenerealAudio", value);
        PlayerPrefs.SetFloat("GeneralAudio", value);
    }
    private void OnuIChangeValue(float value)
    {
        ChangeSoundValue("UIAudio", value);
        PlayerPrefs.SetFloat("UIAudio", value);
    }
    private void OnsFXChangeValue(float value)
    {
        ChangeSoundValue("SFXAudio", value);
        PlayerPrefs.SetFloat("SFXAudio", value);
    }
    private void OnMusicChangeValue(float value) 
    {
        ChangeSoundValue("MusicAudio",value);
        PlayerPrefs.SetFloat("MusicAudio", value);

    }


    private void ChangeSoundValue(string sound, float value) 
    {
        float finalSound = Mathf.Clamp(Mathf.Log10(value) * 35, -80, 0);
        mixerSelected.SetFloat(sound, finalSound);

        sliderSound.PlayOneShot(soundEffect);
    }
}
