using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenTest : MonoBehaviour
{
    Tween tween;
    Sequence sequence;
    void Start()
    {
        /*tween = transform.DOMoveX(5, 0.5f);           //Tween을 통해서 오브젝트는 X축으로 0.5초동안 5만큼 간다.
         transform.DORotate(new Vector3(0, 0, 180), 0.3f);  //Tween을 통해서 오브젝트는 Z축으로 0.3초 동안 180도 회전한다.
         transform.DOScale(new Vector3(2, 2, 2), 2);  //Tween을 통해서 오브젝트는 2초동안 2배로 커진다.

         Sequence sequence = DOTween.Sequence();      //시퀸스를 생성한다.(앞의 Tween이 끝나면 다음 트윈이 시작된다.)
         sequence.Append(transform.DOMoveX(5, 0.5f));
         sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 0.3f));
         sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 2));*/

        //transform.DOMoveX(5, 0.0f).SetEase(Ease.OutBounce).OnComplete(DeactivateObject);    //이동할 때 효과를 추가 시킬 수 있다.(Ease OutBounce)
        //transform.DOShakeRotation(2f, new Vector3(0, 0, 5), 10, 9);   //이동하는 동안 회전충격효과

        sequence = DOTween.Sequence();      //시퀸스 생성
        sequence.Append(transform.DOMoveX(5, 2f));   //움직임 추가
        sequence.SetLoops(-1, LoopType.Yoyo);        //루프를 돌리기위한 옵션들 설정
    }


    void DeactivateObject()                //연출이 종료된 이후에 함수를 호출
    {
        gameObject.SetActive(false);       //오브젝트를 끈다
        Debug.Log("연출 종료");
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sequence.Kill();
            //tween.Kill();
        }
    }
}
