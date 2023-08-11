using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarConnect : MonoBehaviour
{
    [SerializeField] private UIBar firstBar;
    [SerializeField] private UIBar secondBar;

    [SerializeField] private float fillTime = 0.5f;

    [SerializeField] private int maxFillCountTo = 5;
    [SerializeField] private int currentFillCount;

    private void Awake()
    {
        currentFillCount = maxFillCountTo;
    }

    [ContextMenu("Fill To")]
    public void FillTo()
    {
        float fillCoef = 1f / maxFillCountTo;

        if (currentFillCount <= 0)
            return;

        if (firstBar != null && !firstBar.IsFill)
        {
            currentFillCount -= 1;
            UIAction.FillTheBarTo(firstBar.FillImage, 1f - (fillCoef * currentFillCount), fillTime);

            if (secondBar != null)
            {
                if (currentFillCount == 0)
                    return;

                StartCoroutine(Cooldown());
                //UIAction.FillTheBarTo(secondBar.FillImage, 0, 0.25f);
            }
        }
    }

    [SerializeField] private float cooldownTime=0.15f;
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        secondBar.Initialization();
    }
}