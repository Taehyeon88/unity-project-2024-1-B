using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;
    public bool isUsed;
    Rigidbody2D rigidbody2D;
    void Start()
    {
        isUsed = false;                             //사용 완료가 되지 않음(처음 사용)
        rigidbody2D = GetComponent<Rigidbody2D>();  //강체를 가져온다.

    }

    void Update()
    {
        if (isUsed) return;                                         //사용완료된 물체를 어디상 업데이트

        if(isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float leftBorder = -4f + transform.localScale.x / 2f;   
            float rightBorder = 4f - transform.localScale.x / 2f;  

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;    //최대 왼쪽으로 갈 수 있는 범위를 넘어갈 경우 최대 범위 위치를 대입해서 점어가지 못하게 한다.
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;  //최대 오른쪽으로 갈 수 있는 범위를 넘어갈 경우 최대 범위 위치를 대입해서 넘어가지 못하게 한다.


            mousePos.y = 8;
            mousePos.z = 0;

            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f); //이 오브젝트의 위치는 마우스 위치로 이동 된다. 0.2f 속도로 이동된다
        }
         
        if (Input.GetMouseButtonDown(0)) Drag();    //마우스 버튼이 눌렸을 때 Drag함수 호출
        if (Input.GetMouseButtonUp(0)) Drop();      //마우스 버튼이 올라갈 때 Drop함수 호출
    }

    void Drag()
    {
        isDrag = true;                 //드래그 시작(true)
        rigidbody2D.simulated = false; //드래그 중에는 물리현상이 일어나나는 것을 막기 우해서 (false)
    }

    void Drop()
    {
        isDrag = false;               //드래그가 종료
        isUsed = true;                //사용이 완료
        rigidbody2D.simulated = true; //물리 현상 시작 

        GameObject Temp = GameObject.FindWithTag("GameManeger");
        if(Temp != null)
        {
            Temp.gameObject.GetComponent<GameManeger>().GenObject();
        }
    }
}
