using System;
using System.Collections;
using System.Collections.Generic;
using My_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menus : MonoBehaviour,IPointerClickHandler
{
   　[SerializeField] private ulong firstCost;//初期の値段
    private ulong nowCost = 0;//現在のコスト
    [SerializeField] private ulong sellCost;//値段の上がり幅
    [SerializeField] private TextMeshProUGUI costText;//単位
    [SerializeField] private TextMeshProUGUI nameText;//名前
    public ulong produceUnits = 0;
    [SerializeField] private UI_Manager ui;
    [SerializeField] private Music_Manager mg;
    // Start is called before the first frame update
    void Start()
    {
        costText.text = firstCost.ToString()+"単位";
        nowCost = firstCost;
        StartCoroutine(Selling());
    }

    private IEnumerator Selling()
    {
        for (;;)
        {
            yield return new WaitForSeconds (1f);
            ui.UnitIncrease(produceUnits);
        }
    }

   /* private void Update()
    {
        throw new NotImplementedException();
    }*/
   public void OnPointerClick(PointerEventData eventData)
   {
       if (ui._unitSum >= nowCost)
       {
           produceUnits += sellCost;
           nowCost = (ulong) (nowCost + Mathf.Pow(nowCost, 1.05f));
           costText.text = nowCost.ToString() + "単位";
       }
   }
    // Update is called once per frame
    public void Pay()
    {

    }
}
