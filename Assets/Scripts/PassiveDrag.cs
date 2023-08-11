using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PassiveDrag : UIBar, IDropHandler
{
    public void Update()
    {
        if (FillImage.fillAmount < 0.4f)
            FillImage.fillAmount += 0.025f * Time.deltaTime;
        else
            return;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            UIAction.FillTheBarTo(this, 1f, 0.5f);
            Destroy(eventData.pointerDrag);
        }
    }
}
