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
        isUsed = false;                             //��� �Ϸᰡ ���� ����(ó�� ���)
        rigidbody2D = GetComponent<Rigidbody2D>();  //��ü�� �����´�.

    }

    void Update()
    {
        if (isUsed) return;                                         //���Ϸ�� ��ü�� ���� ������Ʈ

        if(isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float leftBorder = -4f + transform.localScale.x / 2f;   
            float rightBorder = 4f - transform.localScale.x / 2f;  

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;    //�ִ� �������� �� �� �ִ� ������ �Ѿ ��� �ִ� ���� ��ġ�� �����ؼ� ����� ���ϰ� �Ѵ�.
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;  //�ִ� ���������� �� �� �ִ� ������ �Ѿ ��� �ִ� ���� ��ġ�� �����ؼ� �Ѿ�� ���ϰ� �Ѵ�.


            mousePos.y = 8;
            mousePos.z = 0;

            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f); //�� ������Ʈ�� ��ġ�� ���콺 ��ġ�� �̵� �ȴ�. 0.2f �ӵ��� �̵��ȴ�
        }
         
        if (Input.GetMouseButtonDown(0)) Drag();    //���콺 ��ư�� ������ �� Drag�Լ� ȣ��
        if (Input.GetMouseButtonUp(0)) Drop();      //���콺 ��ư�� �ö� �� Drop�Լ� ȣ��
    }

    void Drag()
    {
        isDrag = true;                 //�巡�� ����(true)
        rigidbody2D.simulated = false; //�巡�� �߿��� ���������� �Ͼ���� ���� ���� ���ؼ� (false)
    }

    void Drop()
    {
        isDrag = false;               //�巡�װ� ����
        isUsed = true;                //����� �Ϸ�
        rigidbody2D.simulated = true; //���� ���� ���� 

        GameObject Temp = GameObject.FindWithTag("GameManeger");
        if(Temp != null)
        {
            Temp.gameObject.GetComponent<GameManeger>().GenObject();
        }
    }
}
