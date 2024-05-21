using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public GameObject[] CircleObject;
    public Transform GenTransform;
    public float TimeCheck;                       //�ð��� üũ�ϱ� ���� (float)�� 
    public bool isGen;                            //���� ��ǥ üũ (bool)�� 

    public int Point;                              //���� �� ���� (int)
    public int BestScore;                          //���ھ� �� ���� (int)
    public static event Action<int> OnPointChanged;      //event Action ����(Point���� ����� ��� ȣ��)
    public static event Action<int> OnBestScoreChanged;  //event Action ����(Point���� ����� ��� ȣ��)
    void Start()
    { 
        BestScore = PlayerPrefs.GetInt("BestScore");     //������ ����� ���� �ҷ��´�.
        GenObject();                           //������ ���۵Ǿ����� �Լ��� ȣ���ؼ� �ʱ�ȭ ��Ų��. 
        OnPointChanged?.Invoke(Point);
        OnBestScoreChanged?.Invoke(BestScore);
    }

    // Update is called once per frame
    void Update()
    {
      if (!isGen)
        {
            TimeCheck -= Time.deltaTime;
            if(TimeCheck <= 0)
            {
                int RandNumber = UnityEngine.Random.Range(0, 3);              //0 ~2������ ���� ���ڸ� ����
                GameObject Temp = Instantiate(CircleObject[RandNumber]);   //���������� ������Ʈ�� ���� �����ش� (Instantiate)
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

    public void MergeObject(int index, Vector3 position) //Merge �Լ��� ���Ϲ�ȣ(int)�� ���� ��ġ��(Vector3)�� ���� �޴´�.
    {
        GameObject Temp = Instantiate(CircleObject[index]);  //index�� �״�� ����. (0���� �迭�� ���۵����� index
        Temp.transform.position = position;
        Temp.GetComponent<CircleObject>().Used();  //���ӿ�����Ʈ�� ����Ŭ���� ������Ʈ���� ����, �׸��� �� ������Ʈ�� �̸�����<>(),
                                                   //������ ������Ʈ(Script���� Class)�� ���� �޼����� Usedȣ��.

        Point += (int)Mathf.Pow(index, 2) * 10;   //index�� 2������ ���� ����Ʈ ���� Pow�Լ� ���
        OnPointChanged?.Invoke(Point);            //����Ʈ�� ����Ǿ��� ��, ����Ǿ��ٰ� �˸�.
    }
    public void EndGame()
    {
        int BestScore = PlayerPrefs.GetInt("BestScore");             //������ ����� ������ �ҷ��´�.

        if(Point > BestScore)                                        //����Ʈ�� ���Ѵ�.
        {
            BestScore = Point;
            PlayerPrefs.SetInt("BestScore", BestScore);                  //����Ʈ�� �� Ŭ ���, �����Ѵ�.
            OnBestScoreChanged?.Invoke(BestScore);
        }
    }
}
