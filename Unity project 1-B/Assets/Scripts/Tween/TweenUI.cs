using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TweenUI : MonoBehaviour
{
    public float duration = 1f;
    public Image image;
    void Start()
    {
        image = GetComponent<Image>();

        image.DOFade(0f, duration)
                .SetEase(Ease.InOutQuad)
                .SetAutoKill(false)
                .Pause()
                .OnComplete(() => Debug.Log("UI ¿Ï·á"));

        image.DOPlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
