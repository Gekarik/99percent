using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private UIBar bar;
    [SerializeField] private Slider slider;
    [SerializeField] private float fillTime = 3f;

    [SerializeField] private bool isWorks = false;
    public bool ZoneIsWorks => isWorks;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("I Enter");
        isWorks = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("I Exit");
        isWorks = false;
    }

    private void Update()
    {
        if (!isWorks || slider == null)
            return;

        if (bar != null)
            if (bar.IsFill)
                return;

        float fillCoef = 1 / fillTime * Time.deltaTime;
        slider.value = slider.value + fillCoef;
    }
}