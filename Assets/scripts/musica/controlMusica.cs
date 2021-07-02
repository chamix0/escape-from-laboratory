using System;
using UnityEngine;

/*
 * controla si la musica esta muteada o no
 */
public class controlMusica : MonoBehaviour
{
    private static AudioSource audio;
    private static bool muted = false;
    private static Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GameObject.FindGameObjectWithTag("icono").GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        mute();
    }

    public bool getMuted()
    {
        return muted;
    }

    void mute()
    {
        if (muted)
        {
            _animator.SetBool("mute", true);
            audio.mute = true;
        }

        if (Input.GetKeyDown(KeyCode.M) && !muted)
        {
            _animator.SetBool("mute", true);
            muted = true;
            audio.mute = true;
        }

        else if (Input.GetKeyDown(KeyCode.M) && muted)
        {
            _animator.SetBool("mute", false);
            audio.mute = false;
            muted = false;
        }
    }
}