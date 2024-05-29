using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ExSoundPlay : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Alpha1))                 //1번키를 누르면
        {
            SoundManager.instance.PlaySound("BackGround");    //BackGround 재생
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))             //2번키를 누르면
        {
            SoundManager.instance.PlaySound("Cannon");        //Cannon 재생
        }
    }
}
