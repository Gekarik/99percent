using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Image))]
public class TouchRotationBar : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    [Header("Move Settings")]
    [SerializeField] private Canvas canvas;
    [SerializeField] private BarRectZone parentRectZone;
    [SerializeField] private UIBar uiBar;

    [SerializeField] private Image pointImage;
    private RectTransform pointRectTransform;
    [SerializeField] private float rotationSpeed = 1f;

    [Header("Bar Settings")]
    [SerializeField] private Image fillImage;
    [SerializeField] private AnimationCurve fillSpeedCurve;

    [SerializeField] private float fillCoef = 0;
    [SerializeField] private float deadZone = 5f;

    private void Awake()
    {
        if (pointImage != null)
            pointRectTransform = pointImage.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (fillImage == null)
            return;

        int tempCoef;

        if (pointImage.rectTransform.localPosition.y == 0 || (pointImage.rectTransform.localPosition.y < deadZone && pointImage.rectTransform.localPosition.y > -deadZone))
        {
            fillCoef = 0;
            tempCoef = 0;
        }
        else
            tempCoef = pointImage.rectTransform.localPosition.y > 0 ? -1 : 1;

        float minClamp = -1;
        float maxClamp = 1;
        
        if (uiBar != null)
        {
            minClamp = uiBar.FillImage.fillAmount == 0 ? 0 : -1;
            maxClamp = uiBar.FillImage.fillAmount == 1 ? 0 : 1;
        }

        fillCoef += Time.deltaTime * tempCoef;
        fillCoef = Mathf.Clamp(fillCoef, minClamp, maxClamp);

        fillImage.fillAmount += fillSpeedCurve.Evaluate(fillCoef) * Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("On Pointer Down");
        if (canvas != null)
        {
            pointRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            pointRectTransform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("On Drag");
        if (canvas != null && pointImage != null)
        {
            pointRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

            float angle = Mathf.Atan2(pointImage.rectTransform.position.y - transform.position.y, pointImage.rectTransform.position.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
        }

        if (parentRectZone != null)
            parentRectZone.ClampingObject(pointImage);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End Drag");
    }
}