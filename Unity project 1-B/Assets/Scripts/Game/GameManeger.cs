using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public GameObject CircleObject;
    public Transform GenTransform;
    public float TimeCheck;                       //�ð��� üũ�ϱ� ���� (float)�� 
    public bool isGen;                            //���� ��ǥ üũ (bool)�� 
    void Start()
    {
        GenObject();                           //������ ���۵Ǿ����� �Լ��� ȣ���ؼ� �ʱ�ȭ ��Ų��. 
    }

    // Update is called once per frame
    void Update()
    {
      if (!isGen)
        {
            TimeCheck -= Time.deltaTime;
            if(TimeCheck <= 0)
            {
                GameObject Temp = Instantiate(CircleObject);   //���������� ������Ʈ�� ���� �����ش� (Instantiate)
                Temp.transform.position = GenTransform.position;   //������ ��ġ�� �̵� ��Ų��.
                isGen = true;                                      //Gen�� �Ǿ��ٰ� true�� bool ���� �����Ѵ�.
            }
        }
    }

    public void GenObject()
    {
        isGen = false;                 //�ʱ�ȭ :  isGen�� false(���� ���� �ʾҴ�)
        TimeCheck = 1.0f;              //1���� ���� �������� ���� ��Ű�� ���� �ʱ�ȭ 
    }
}
