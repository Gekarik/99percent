using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public static class UIAction 
{
    public static void FillTheBarTo(Image fillImage, float fillValue, float fillTime)
    {
        fillImage.DOFillAmount(fillValue, fillTime);        
    }
    public static void FillTheBarTo(UIBar uiBar, float fillValue, float fillTime)
    {
        uiBar.FillImage.DOFillAmount(fillValue, fillTime).OnComplete(()=> UIAction.OnComplete(uiBar));
    }

    public static void FillTheBarTo(Image fillImage, int procentValue, float fillTime)
    {
        float fillValue = 0.01f * procentValue;
        fillImage.DOFillAmount(fillValue, fillTime);        
    }

    private static void OnComplete(UIBar uiBar)
    {
        uiBar.OnComplete();
    }
}