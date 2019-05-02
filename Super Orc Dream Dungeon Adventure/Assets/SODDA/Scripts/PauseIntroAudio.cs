using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseIntroAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IntroMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
