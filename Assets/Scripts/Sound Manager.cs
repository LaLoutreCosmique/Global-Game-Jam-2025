using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private AudioMixer mixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMusicVolume(float value)
    {
        mixer.SetFloat("musicVolume", Mathf.Log10(musicSlider.value) * 20);
    }

    public void ChangeSfxVolume(float value)
    {
        mixer.SetFloat("SfxVolume", Mathf.Log10(sfxSlider.value) * 20);
    }

    public void PlaySFX(AudioSource clip)
    {
        clip = clip.GetComponent<AudioSource>();
        clip.Play();
    }

    public void StopSFX(AudioSource clip)
    {
        clip.Stop();
    }
}
