using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     //UI를 사용하기 위해서

public class Explayer : MonoBehaviour

    
{
    public Rigidbody m_Rigidbody;
    public int Force = 100;
    public int point = 0;
    public float checkTime = 0;   //
    public Text m_Text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          m_Rigidbody.AddForce(transform.up * Force);
        }

        checkTime += Time.deltaTime;         //point =point + 1
        if(checkTime >= 1.0f)                //1초가 지날경우 초기화 (0초 -> 1초 -> 0초 -> 1초)
        {
            point += 1;
            checkTime = 0.0f;
        }

        m_Text.text = point.ToString();        //UI 표시
          
    }
    private void OnCollisionEnter(Collision collision)  //충돌이 시작되었을 때
    {
        if(collision != null)                          //충돌물체가 존재할 경우
        {
            point = 0;
            gameObject.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
            Debug.Log(collision.gameObject.name);      //해당오브젝트의 이름을 출력한다
        }
    }
}
