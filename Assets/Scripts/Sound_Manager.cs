using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Sound_Manager : MonoBehaviour
{
    public AudioSource main_sound;
    public AudioSource badge_sound;
    public AudioSource poster_sound;
    public AudioSource back_sound;

    public void main_sound_play () {
        main_sound.Play();
        
	}
    public void main_sound_stop()
    {
        main_sound.Stop();
    }
    public void badge_sound_play()
    {
        badge_sound.Play();
    }
    public void badge_sound_stop()
    {
        badge_sound.Stop();
    }
    public void poster_sound_play()
    {
        poster_sound.Play();
    }
    public void poster_sound_stop()
    {
        poster_sound.Stop();
    }

    public void back_sound_play()
    {
        back_sound.Play();
    }
    public void back_sound_stop()
    {
        back_sound.Stop();
    }

}
