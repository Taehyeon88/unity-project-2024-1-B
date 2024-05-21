using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text pointText;          //점수 표시할 UI
    public Text bestscoreText;      //최고 점수 표시할 UI

    private void OnEnable()
    {
        GameManeger.OnPointChanged += UpdatePointText;             //이벤트 등록      등록과 삭제는 세트이고 이렇게 해야만 에러가 발생하지 않는다.
        GameManeger.OnBestScoreChanged += UpdateBestScoreText;     //이벤트 등록
    }
    private void OnDisable()
    {
        GameManeger.OnPointChanged -= UpdatePointText;            //이벤트 삭제
        GameManeger.OnBestScoreChanged -= UpdateBestScoreText;    //이벤트 삭제
    }
    private void UpdatePointText(int newPoint)                   //함수 이벤트를 만들어서 인수설정
    {
        pointText.text = "Point :" + newPoint;
    }
    private void UpdateBestScoreText(int newBestScore)           //함수 이벤트를 만들어서 인수설정
    {
        bestscoreText.text = "Best Score : " + newBestScore;
    }
}
