using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class UIBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    public Image FillImage => fillImage;

    [SerializeField] private float stopValue = 1f;
    [SerializeField] private bool isFill;
    public bool IsFill => isFill;

    private void Update()
    {
        if (fillImage == null)
            return;

        isFill = fillImage.fillAmount >= stopValue;
    }

    public virtual void Initialization() { }
    public virtual void OnComplete() { }
}