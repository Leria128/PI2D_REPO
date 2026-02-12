using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  
   public static AudioManager instance;

    [Header("Audio Source References")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clip Arrays")]
    public AudioClip[] musicList;
    public AudioClip[] sfxList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;    
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(int musicIndex)
    {
        
        musicSource.clip = musicList[musicIndex];
        musicSource.Play();
    }

    public void PlaySFX(int sfxIndex)
    {
        sfxSource.PlayOneShot(sfxList[sfxIndex]);
    }

}
