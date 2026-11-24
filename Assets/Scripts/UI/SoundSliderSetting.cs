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
        // Bug: PlayerPrefs.GetFloat sin valor por defecto devuelve 0 en la primera ejecución: los sliders quedan en 0
        // y Log10(0) termina en -80 dB, el juego arranca muteado. Usá PlayerPrefs.GetFloat("GeneralAudio", 1f).
        generalAudioSlider.value = PlayerPrefs.GetFloat("GeneralAudio");
        uIAudioSlider.value = PlayerPrefs.GetFloat("UIAudio");
        sFXAudioSlider.value = PlayerPrefs.GetFloat("SFXAudio");
        musicAudioSlider.value = PlayerPrefs.GetFloat("MusicAudio");
    }
    private void OnGeneralChangeValue(float value)
    {
        // Warning: Claves de PlayerPrefs y parámetros del mixer como strings mágicos, y conviven 'GenerealAudio' (parámetro del mixer, con error de tipeo) y 'GeneralAudio' (clave de PlayerPrefs).
        // Definí constantes para cada clave.
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
        // Suggestion: Factor 35 mágico. La fórmula estándar es Log10(value) * 20.
        float finalSound = Mathf.Clamp(Mathf.Log10(value) * 35, -80, 0);
        mixerSelected.SetFloat(sound, finalSound);

        sliderSound.PlayOneShot(soundEffect);
    }
}
