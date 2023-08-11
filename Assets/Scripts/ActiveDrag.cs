using UnityEngine;
using UnityEngine.EventSystems;

public class ActiveDrag : UIBar, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 defaultPosition;

    
    [SerializeField]
    private Canvas canvas;   

    private void Update()
    {
        if (FillImage.fillAmount != 1)
            FillImage.fillAmount += 0.25f * Time.deltaTime;
        else
            return;
    }

    private void Awake()
    {        
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        defaultPosition = GetComponent<RectTransform>().anchoredPosition;
    }
   
    public void OnBeginDrag(PointerEventData eventData)
    {        
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {        
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {        
        canvasGroup.alpha = 1f; ;
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = defaultPosition;
    }   
}
