using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource bgmAudio;
    public Slider volumeSlider;

    private void Update()
    {
        bgmAudio.volume = volumeSlider.value;
    }

}
