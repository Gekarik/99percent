using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Image))]
public class BarRectZone : MonoBehaviour
{
    [SerializeField] private bool XClamp = false;
    [SerializeField] private bool YClamp = false;
    [SerializeField] private bool CircleClamp = false;

    [SerializeField] private Image rectImage;

    private void Awake()
    {
        rectImage = GetComponent<Image>();
    }

    public void ClampingObject(Image objectImage)
    {
        Vector3 rectPosition = objectImage.rectTransform.localPosition;
        RectTransform objectRect = objectImage.rectTransform;

        float clampZoneHeight = rectImage.rectTransform.rect.height;
        float clampZoneWidth = rectImage.rectTransform.rect.width;

        if (YClamp)
            rectPosition = new Vector3(rectPosition.x, Mathf.Clamp(objectImage.rectTransform.localPosition.y, -(clampZoneHeight / 2 - objectRect.rect.height / 2), (clampZoneHeight / 2 - objectRect.rect.height / 2)), 0);

        if (XClamp)
            rectPosition = new Vector3(Mathf.Clamp(objectImage.rectTransform.localPosition.x, -(clampZoneWidth / 2 - objectRect.rect.width / 2), (clampZoneWidth / 2 - objectRect.rect.width / 2)), rectPosition.y, 0);

        if (CircleClamp)
        {
            float radius = clampZoneHeight > clampZoneWidth ? clampZoneHeight / 2 : clampZoneWidth / 2;

            Vector3 centerPosition = transform.localPosition;
            float distance = Vector3.Distance(objectImage.rectTransform.localPosition, centerPosition);

            if (distance > radius)
            {
                Vector3 fromOriginToObject = objectImage.rectTransform.localPosition - centerPosition;
                fromOriginToObject *= radius / distance;
                rectPosition = centerPosition + fromOriginToObject;
            }
        }

        objectImage.rectTransform.localPosition = rectPosition;
    }
}