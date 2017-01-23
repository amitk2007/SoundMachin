using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]

public class OnKeyDown : MonoBehaviour
{

    AudioSource[] audios;
    KeyCode[] keyArray;
    // Use this for initialization
    void Start()
    {
        audios = GetComponents<AudioSource>();
        SetUpKeyArray();
        //print(KeyCode.UpArrow.ToString());
        //print(KeyCode.DownArrow.ToString());
        //print(KeyCode.RightArrow.ToString());
        //print(KeyCode.LeftArrow.ToString());
        //print(KeyCode.Keypad0.ToString());
        //print(KeyCode.Keypad1.ToString());
        //print(KeyCode.Keypad2.ToString());
        //print(KeyCode.Keypad3.ToString());
        //print(KeyCode.Keypad4.ToString());
        //print(KeyCode.Keypad5.ToString());
    }

    private void SetUpKeyArray()
    {
        keyArray = new KeyCode[] {
            KeyCode.Keypad0, KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4,
            KeyCode.Keypad5, KeyCode.Keypad6, KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9,
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShutUp();
        }
        foreach (KeyCode e in keyArray)
        {
            if (Input.GetKeyDown(e))
            {
                print(e.ToString());
                bool a = PlayMusic((AudioClip)Resources.Load("Sounds/" + e.ToString()));
                if (a == false)
                {
                    //no audio sours avilible
                }
            }
        }
        //if (Input.anyKey)
        //{
        //    print((string)Input.inputString+"*************");
        //    audio.clip = (AudioClip)Resources.Load("Sounds/"+(string)Input.inputString);
        //    audio.Play();
        //    Debug.Log((string)Input.inputString.GetHashCode().ToString()+"haxj");
        //    print("You have pressed " );
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //    print("space key was pressed");
        //
    }

    private void ShutUp()
    {
        foreach (AudioSource source in audios)
        {
            source.Stop();
        }
    }

    public bool PlayMusic(AudioClip audioclip)
    {
        for (int i = 0; i < audios.Length; i++)
        {
            if (audios[i].isPlaying == false)
            {
                audios[i].clip = audioclip;
                audios[i].Play();
                return true;
            }
        }
        return false; ;
    }
}

