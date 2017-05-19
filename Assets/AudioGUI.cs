using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AudioGUI : MonoBehaviour {

    public Sprite spr_music;
    public Sprite spr_sound;
    public Sprite spr_musicMuted;
    public Sprite spr_soundMuted;

    public Button btn_music;
    public Button btn_sound;



    void Awake()
	{
	}
	
	void Start () 
	{
        InitButtonListeners();
    }

	void Update () 
	{	
	}



    void InitButtonListeners()
    {
        //music button
        btn_music.onClick.AddListener(delegate
        {
            if(AudioManager.refrence.isMusicMuted)
            {
                AudioManager.refrence.isMusicMuted = false;
                btn_music.image.sprite = spr_music;
            }
            else
            {
                AudioManager.refrence.isMusicMuted = true;
                btn_music.image.sprite = spr_musicMuted;
            }
            AudioManager.refrence.UpdateMusicVolume();
        });

        //sound button
        btn_sound.onClick.AddListener(delegate
        {
            if (AudioManager.refrence.isSoundMuted)
            {
                AudioManager.refrence.isSoundMuted = false;
                btn_sound.image.sprite = spr_sound;
            }
            else
            {
                AudioManager.refrence.isSoundMuted = true;
                btn_sound.image.sprite = spr_soundMuted;
            }            
        });
    }




}
