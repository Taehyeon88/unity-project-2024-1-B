using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFollowObject : MonoBehaviour
{
    public Transform targetObject;       //따라갈 3d 오브젝트
    public Vector3 offSet;               //위치값보정
    public Slider slider;                //따라다닐 Slider UI

    void Update()
    {
        if(targetObject != null && slider != null)
        {
            // 3D오브젝트의 위치를 화면 좌표로 변환
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetObject.position + offSet);
            //화면좌표를 Canvas좌표로 변환
            RectTransform canvasRect = slider.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out canvasPos);

            //Slider UI위치를 업데이트
            slider.transform.localPosition = canvasPos;
        }
    }
}
