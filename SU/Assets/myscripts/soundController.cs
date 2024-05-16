using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    public AudioSource src;
    public AudioClip attacksound,runSound;
    public void playAttackSound()
    {
        src.clip = attacksound;
        src.PlayOneShot(attacksound);
    }
    public void playRunSound()
    {
        src.clip = runSound;
        src.Play();
    }
}

