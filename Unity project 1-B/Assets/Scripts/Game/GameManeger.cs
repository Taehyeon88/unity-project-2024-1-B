using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public GameObject CircleObject;
    public Transform GenTransform;
    public float TimeCheck;                       //시간을 체크하기 위한 (float)값 
    public bool isGen;                            //생성 완표 체크 (bool)값 
    void Start()
    {
        GenObject();                           //게임이 기작되었으때 함수를 호출해서 초기화 시킨다. 
    }

    // Update is called once per frame
    void Update()
    {
      if (!isGen)
        {
            TimeCheck -= Time.deltaTime;
            if(TimeCheck <= 0)
            {
                GameObject Temp = Instantiate(CircleObject);   //과일프리팹 오브젝트를 생성 시켜준다 (Instantiate)
                Temp.transform.position = GenTransform.position;   //설정한 위치로 이동 시킨다.
                isGen = true;                                      //Gen이 되었다고 true로 bool 값을 변경한다.
            }
        }
    }

    public void GenObject()
    {
        isGen = false;                 //초기화 :  isGen을 false(생성 되지 않았다)
        TimeCheck = 1.0f;              //1초후 과일 프리팹을 생성 시키기 위한 초기화 
    }
}
