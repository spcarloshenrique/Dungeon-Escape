using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager AudioManagerInstance {get; private set;}
    
    AudioSource audioSource;

    [SerializeField] Slider audioSlider;
    
    void Awake()
    {
        if(AudioManagerInstance == null)
        {
            AudioManagerInstance = FindObjectOfType<AudioManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        audioSlider.onValueChanged.AddListener(delegate {
            RecebeValorSlider();
        });

        if(PlayerPrefs.HasKey("Volume")){
            audioSource.volume = PlayerPrefs.GetFloat("Volume");
            audioSlider.value = audioSource.volume;
        }else{
            audioSource.volume = 0.5f;
            audioSlider.value = 0.5f;
        }
    }

    public void RecebeValorSlider(){
        audioSource.volume = audioSlider.value;
        PlayerPrefs.SetFloat("Volume", audioSource.volume);
    }
}