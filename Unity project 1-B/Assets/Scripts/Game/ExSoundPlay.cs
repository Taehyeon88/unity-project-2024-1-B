using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ExSoundPlay : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Alpha1))                 //1��Ű�� ������
        {
            SoundManager.instance.PlaySound("BackGround");    //BackGround ���
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))             //2��Ű�� ������
        {
            SoundManager.instance.PlaySound("Cannon");        //Cannon ���
        }
    }
}
