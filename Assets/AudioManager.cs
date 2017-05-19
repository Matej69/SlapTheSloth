using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AudioManager : MonoBehaviour {

    static public AudioManager refrence;
    
    public enum E_AUDIO
    {
        SLAP,
        CASH,
        BACKGROUND
    }

    [System.Serializable]
    public class AudioInfo
    {
        public E_AUDIO id;
        public AudioClip clip;
    }

    public List<AudioInfo> audioList = new List<AudioInfo>();
    public AudioClip backgroundClip;

    AudioSource backgroundMusic;
    [HideInInspector]
    public bool isMusicMuted = false;
    [HideInInspector]
    public bool isSoundMuted = false;


    void Awake()
	{
        refrence = this;
    }
	
	void Start () 
	{
        InitBackgroundMusic();
    }

	void Update () 
	{
	}



    private AudioClip GetAudioClip(E_AUDIO _id)
    {
        foreach (AudioInfo audio in audioList)
            if (audio.id == _id)
                return audio.clip;
        Debug.LogError("can not return audio clip with ID =" + _id);
        return null;
    }
    public void PlaySound(E_AUDIO _id)
    {
        if (!isSoundMuted)
        {
            GameObject newAudio = new GameObject("AudioObject");
            AudioSource audioSource = newAudio.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(_id);
            audioSource.pitch = Random.Range(90f, 110f) / 100f;
            audioSource.volume = 0.5f;
            audioSource.Play();
        }
    }



    private void InitBackgroundMusic()
    {
        GameObject backMusic = new GameObject("Background music");
        backMusic.transform.SetParent(transform);
        backgroundMusic = backMusic.AddComponent<AudioSource>();
        backgroundMusic.clip = backgroundClip;
        backgroundMusic.volume = 0.5f;
        backgroundMusic.loop = true;
        backgroundMusic.Play();
    }
    public void UpdateMusicVolume()
    {
        if (isMusicMuted)
            backgroundMusic.volume = 0;
        else
            backgroundMusic.volume = 0.5f;
    }







}
