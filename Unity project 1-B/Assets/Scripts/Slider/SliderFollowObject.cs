using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFollowObject : MonoBehaviour
{
    public Transform targetObject;       //���� 3d ������Ʈ
    public Vector3 offSet;               //��ġ������
    public Slider slider;                //����ٴ� Slider UI

    void Update()
    {
        if(targetObject != null && slider != null)
        {
            // 3D������Ʈ�� ��ġ�� ȭ�� ��ǥ�� ��ȯ
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetObject.position + offSet);
            //ȭ����ǥ�� Canvas��ǥ�� ��ȯ
            RectTransform canvasRect = slider.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out canvasPos);

            //Slider UI��ġ�� ������Ʈ
            slider.transform.localPosition = canvasPos;
        }
    }
}
