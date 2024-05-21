using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;
    public bool isUsed;
    Rigidbody2D rigidbody2D;

    public int index;       //���� ��ȣ�� �����.

    public float EndTime = 0.0f;                    
    public SpriteRenderer spriteRenderer;           //����� ��������Ʈ ���� ��ȯ ��Ű�� ���� ���� ����

    public GameManeger gameManeger;                 //GameManeger ������ ����
    void Awake()                                    //�����ϱ��� �ҽ��ܰ迡�� 
    {
        isUsed = false;                             //��� �Ϸᰡ ���� ����(ó�� ���)
        rigidbody2D = GetComponent<Rigidbody2D>();  //��ü�� �����´�.
        rigidbody2D.simulated = false;              //�����ɶ��� �ùķ����� ���� �ʴ´�.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        gameManeger = GameObject.FindWithTag("GameManeger").GetComponent<GameManeger>();     //���ӸŴ����� ���´�.
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

    public void Used()
    {
        isDrag = false;
        isUsed = true;
        rigidbody2D.simulated = true;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "EndLine")
        {
            EndTime += Time.deltaTime;

            if(EndTime > 1)
            {
                spriteRenderer.color = new Color(0.9f, 0.2f, 0.2f);
            }
            if(EndTime >3)
            {
                gameManeger.EndGame();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "EndLine")
        {
            EndTime = 0.0f;
            spriteRenderer.color = Color.white;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (index >= 7)
            return;

        if(collision.gameObject.tag == "Fruit")          //�浹��ü�� tag�� fruit�� ���
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>();  //�ӽ÷� Class temp�� �����ϰ� �浹ü�� class(CircleObject)�� �޾ƿ´�.

            if(temp.index ==index) //���� ��ȣ�� ���� ���
            {
                if(gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())   //����Ƽ���� �����ϴ� ������ ID�� �޾ƿͼ� ID�� ū�ʿ��� ���� ���� ����
                {
                    //GameManeger ���� �����Լ� ȣ��
                    GameObject Temp = GameObject.FindWithTag("GameManeger");
                    if (Temp != null)
                    {
                        Temp.gameObject.GetComponent<GameManeger>().MergeObject(index, gameObject.transform.position); //������ MerageObject�Լ��� �μ��� �Բ� ����
                    }
                    
                    Destroy(temp.gameObject);                    //�浹 ��ü �ı�
                    Destroy(gameObject);                         //�ڱ� �ڽ� �ı�
                }
            }
        }
    }
}
