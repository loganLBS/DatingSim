using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterSlider;
    

    void Start()
    {
        // Load saved values (default 0.75f)
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
       

        // Add listeners
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
       
        // Apply initial values
        SetMasterVolume(masterSlider.value);
       
    }

    void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20); // Convert linear to dB
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
}