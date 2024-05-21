using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text pointText;          //���� ǥ���� UI
    public Text bestscoreText;      //�ְ� ���� ǥ���� UI

    private void OnEnable()
    {
        GameManeger.OnPointChanged += UpdatePointText;             //�̺�Ʈ ���      ��ϰ� ������ ��Ʈ�̰� �̷��� �ؾ߸� ������ �߻����� �ʴ´�.
        GameManeger.OnBestScoreChanged += UpdateBestScoreText;     //�̺�Ʈ ���
    }
    private void OnDisable()
    {
        GameManeger.OnPointChanged -= UpdatePointText;            //�̺�Ʈ ����
        GameManeger.OnBestScoreChanged -= UpdateBestScoreText;    //�̺�Ʈ ����
    }
    private void UpdatePointText(int newPoint)                   //�Լ� �̺�Ʈ�� ���� �μ�����
    {
        pointText.text = "Point :" + newPoint;
    }
    private void UpdateBestScoreText(int newBestScore)           //�Լ� �̺�Ʈ�� ���� �μ�����
    {
        bestscoreText.text = "Best Score : " + newBestScore;
    }
}
