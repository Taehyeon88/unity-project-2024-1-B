using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExClinderMove : MonoBehaviour
{
    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //해당 스크립트가 붙어있는 오브잭트는 X축 마이너스방향으로 이동을 한다.
        //+= 는 += 7 <- x = x + 7를 축약해주는 표시
        //Vector3은 x,y,z축을 나타내는 함수
        //프레임간격시간 (Time.deltaTime)모든 컴퓨터에서 일정하게 이동을 시켜야하기 때문에 사용
        //컴퓨터마다 프레임이 다르기때문

        gameObject.transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * Time.deltaTime;

        if(gameObject.transform.position.x < -12)   //x축좌표가 -12미만으로 내려갈때
        {
            gameObject.transform.position += new Vector3(24.0f, 0.0f, 0.0f);  //오른쪽으로 X축 24만큼 이동
        }
    }
}
