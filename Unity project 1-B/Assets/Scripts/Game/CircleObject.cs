using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;
    public bool isUsed;
    Rigidbody2D rigidbody2D;

    public int index;       //과일 번호를 만든다.

    public float EndTime = 0.0f;                    
    public SpriteRenderer spriteRenderer;           //종료시 스프라이트 색을 변환 시키기 위해 접근 선언

    public GameManeger gameManeger;                 //GameManeger 접근을 선언
    void Awake()                                    //시작하기전 소스단계에서 
    {
        isUsed = false;                             //사용 완료가 되지 않음(처음 사용)
        rigidbody2D = GetComponent<Rigidbody2D>();  //강체를 가져온다.
        rigidbody2D.simulated = false;              //생성될때는 시뮬레이팅 되지 않는다.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        gameManeger = GameObject.FindWithTag("GameManeger").GetComponent<GameManeger>();     //게임매니저를 얻어온다.
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

        if(collision.gameObject.tag == "Fruit")          //충돌물체의 tag가 fruit일 경우
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>();  //임시로 Class temp를 선언하고 충돌체의 class(CircleObject)를 받아온다.

            if(temp.index ==index) //과일 번호가 같은 경우
            {
                if(gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())   //유니티에서 지원하는 고유의 ID를 받아와서 ID가 큰쪽에서 다음 과일 생성
                {
                    //GameManeger 에서 생성함수 호출
                    GameObject Temp = GameObject.FindWithTag("GameManeger");
                    if (Temp != null)
                    {
                        Temp.gameObject.GetComponent<GameManeger>().MergeObject(index, gameObject.transform.position); //생성된 MerageObject함수에 인수와 함께 전달
                    }
                    
                    Destroy(temp.gameObject);                    //충돌 물체 파괴
                    Destroy(gameObject);                         //자기 자신 파괴
                }
            }
        }
    }
}
