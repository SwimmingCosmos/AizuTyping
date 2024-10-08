using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using unityroom.Api;

public class OnOff : MonoBehaviour  // 物を隠したり表示したりする
{
    [SerializeField] private GameObject[] titles;
    [SerializeField] private GameObject[] games;
    [SerializeField] private GameObject[] results;
    [SerializeField] private AudioClip[] bgms;

    [SerializeField] private GameObject owari;
    [SerializeField] private TypingManager tyMg;

    [SerializeField] private GameObject kekka;
    [SerializeField] private TextMeshProUGUI xxdan;

    [SerializeField] private GameObject xdan;

    [SerializeField] private GameObject result;

    [SerializeField] private GameObject don;
    [SerializeField] private GameObject good;
    [SerializeField] private TextMeshProUGUI dondo;

    [SerializeField] private AudioSource meoto;
    [SerializeField] private AudioSource cat;
    [SerializeField] private AudioSource over;
    [SerializeField] private Slider ss;
    // Start is called before the first frame update
    void Start()
    {
        float basicCat = cat.volume;
        float basicmeoto = meoto.volume;
        float basicover = over.volume;
    }

    public void allMusic()
    {
        meoto.volume =*ss.value;
        cat.volume = 0.1f*ss.value;
        over.volume = ss.value;
    }
    public void otoman(int o)
    {
        meoto.PlayOneShot(bgms[o]);
    }

    public void FirstClick()
    {
        meoto.Stop();
        foreach (GameObject i in titles)//タイトル全部消す
        {
            i.gameObject.SetActive(false);
        }
        
        
        foreach (GameObject i in games)//ゲーム始める
        {
            i.gameObject.SetActive(true);
        }
        cat.Play();
        tyMg.InitializeQuestion();
        StartCoroutine(tyMg.DoorsOpen());
    }
    public void SecondOut()
    {
        cat.Stop();
        foreach (GameObject i in games)//ゲーム始める
        {
            i.gameObject.SetActive(false);
        }
       /* foreach (GameObject i in results)//ゲーム始める
        {
            i.gameObject.SetActive(true);
        }*/

        xxdan.text = tyMg.score+"段";
        UnityroomApiClient.Instance.SendScore(1, tyMg.score, ScoreboardWriteMode.HighScoreDesc);
        if (tyMg.score <= 1)
        {
            dondo.text = "教育教育教育教育教育教育教育教育教育教育教育教育教育教育教育市形市形市形市形市形市形市形市形市形教育教育教育教育教育教育教育教育教育教育教育教育教育教育教育";
        }
        else if (tyMg.score <= 4)
        {
            dondo.text = "Never give Up";
        }
        else if (tyMg.score <= 8)
        {
            dondo.text = "頑張ったね";
        }
        else if (tyMg.score <= 12)
        {
            dondo.text = "お疲れさま";
        }
        else if (tyMg.score <= 15)
        {
            dondo.text = "たくましいですね";
        }
        else if (tyMg.score <= 19)
        {
            dondo.text = "すごい！つぎは20段だ！";
        }
        else
        {
            good.SetActive(true);
        }
        
        StartCoroutine(Moves());
    }

    public void Retry()
    {
        cat.Stop();
        over.Stop();
        meoto.Play();
        StartCoroutine(tyMg.DoorsClose());
        foreach (GameObject i in games)//最後の部分全部消す
        {
            i.gameObject.SetActive(false);
        }
        foreach (GameObject i in results)//最後の部分全部消す
        {
            i.gameObject.SetActive(false);
        }
        foreach (GameObject i in titles)//最後の部分全部戻す
        {
            i.gameObject.SetActive(true);
        }
        tyMg.countTime = 60.0f;
        tyMg.score = 1;
        tyMg.InitializeQuestion();
    }
    

    private IEnumerator Moves()
    {
       owari.SetActive(true);
       otoman(1);
       yield return new WaitForSeconds(3f);
       owari.SetActive(false);
       yield return new WaitForSeconds(0.5f);
       kekka.SetActive(true);
       otoman(0);
       yield return new WaitForSeconds(0.8f);
       xdan.SetActive(true);
       otoman(0);
       yield return new WaitForSeconds(0.8f);
       result.SetActive(true);
       otoman(0);
       yield return new WaitForSeconds(0.8f);
       don.SetActive(true);
       otoman(0);
       over.Play();
    }
    // Update is called once per frame
    void OnGUI()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Retry();
        }
    }
}
