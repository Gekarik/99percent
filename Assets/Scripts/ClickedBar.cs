using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickedBar : UIBar, IPointerDownHandler
{
    public BarConnect barConnect;

    [SerializeField] private int maxClickCount = 10;
    [SerializeField] private int currentClickCount;
    public int CurrentClickCount => currentClickCount;

    [SerializeField] private float fillTime = 0.5f;
    [SerializeField] private bool isWork = false;

    private void Awake()
    {
        InitializationClicks();
    }

    public override void Initialization()
    {
        InitializationClicks();
    }

    public void InitializationClicks()
    {
        currentClickCount = maxClickCount;

        float clickCoef = 1f / maxClickCount;
        FillImage.fillAmount = 1f - (clickCoef * currentClickCount);
        isWork = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isWork)
            return;

        if (FillImage == null || currentClickCount <= 0)
            return;

        float clickCoef = 1f / maxClickCount;
        currentClickCount -= 1;

        isWork = true;
        UIAction.FillTheBarTo(this, 1f - (clickCoef * currentClickCount), fillTime);
    }

    public override void OnComplete()
    {
        isWork = false;
        if (barConnect != null)
            if (currentClickCount == 0)
                barConnect.FillTo();
    }
}