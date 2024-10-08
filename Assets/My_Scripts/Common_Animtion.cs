using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Common_Animtion : MonoBehaviour,
IPointerUpHandler,
IPointerDownHandler,
IPointerEnterHandler,
IPointerExitHandler
{
    private RectTransform myDelta;
    private CanvasGroup myImage;
    // Start is called before the first frame update
    void Start()
    {
        myDelta = this.GetComponent<RectTransform>();
        myImage = GetComponent<CanvasGroup>();
    }
// タップダウン  
    public void OnPointerDown(PointerEventData eventData)
    {
        myImage.DOFade(0.8f, 0.24f);
    }  
    
    // タップアップ  
    public void OnPointerUp(PointerEventData eventData)
    {
        myImage.DOFade(1f, 0.24f);
    }  
    //ポインターイン
    public  void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.05f, 0.3f);
        //myDelta.DOSizeDelta(new Vector2(10, 10), 0.3f).SetRelative();
    }
    //ポインターアウト
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.3f);
        //myDelta.DOSizeDelta(new Vector2(-10, -10), 0.3f).SetRelative();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
