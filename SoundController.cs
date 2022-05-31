using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource audioBackGround;

    public void ActiveSound(bool active)
    {
        if (active) audioBackGround.Play();
        else audioBackGround.Stop();
    }
}
