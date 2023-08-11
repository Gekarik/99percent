using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseBarMoving : UIBar, IPointerEnterHandler
{
    [SerializeField] private int maxPointRecount = 20;
    [SerializeField] private int pointCounter;

    private void Awake()
    {
        pointCounter = maxPointRecount;

        float coef = 1f / maxPointRecount;
        if (FillImage != null)
            FillImage.fillAmount = 1f - (coef * pointCounter);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (pointCounter <= 0)
            return;

        float coef = 1f / maxPointRecount;
        pointCounter -= 1;
        UIAction.FillTheBarTo(this, 1f - (coef * pointCounter), 0.5f);

    }
}