using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenColor : MonoBehaviour
{
    private Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Color color = new Color(Random.value, Random.value, Random.value);

            renderer .material.DOColor(color, 1f)
                .SetEase(Ease.InOutQuad)
                .SetAutoKill(false)
                .Pause()
                .OnComplete(() => Debug.Log("Color변환 완료"));

            renderer.material.DOPlay();
        }
    }
}
