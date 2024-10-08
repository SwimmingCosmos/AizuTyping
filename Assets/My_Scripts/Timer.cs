using System;
using System.Collections;
using System.Collections.Generic;
using My_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using unityroom.Api;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timetext;
    [SerializeField] private TextMeshProUGUI timeUptext;
    [SerializeField] private Player_Manager pm;
    [SerializeField] private Music_Manager mm;
    [SerializeField] private GameObject btn;

    private int hours = 6,minute = 45;
    public int skiptime;
    private float times;
    private int mongen = 22;
    // Start is called before the first frame update
    void Start()
    {
        timetext.text = hours.ToString("00") + ":" + minute.ToString("00");
        StartCoroutine(AAA());
    }

    IEnumerator AAA()
    {
        timeUptext.text = "3";
        mm.SeExport(0);
        yield return new WaitForSeconds(1f);
        timeUptext.text = "2";
        mm.SeExport(0);
        yield return new WaitForSeconds(1f);
        timeUptext.text = "1";
        mm.SeExport(0);
        yield return new WaitForSeconds(1f);
        timeUptext.text = "Start!";
        mm.SeExport(5);
        yield return new WaitForSeconds(1f);
        timeUptext.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameView");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        times += Time.deltaTime;
        if (times >= 1.0f)
        {
            times = 0f;
            minute += skiptime;
            if (minute >= 60)
            {
                hours++;
                minute = 0;
                if (hours >= mongen-2)
                {
                    timetext.color = Color.red;
                    
                }
                if (hours >= mongen)
                {
                    timetext.text = hours.ToString("00") + ":" + minute.ToString("00");
                    timeUptext.text = "Time's Up!";
                    btn.SetActive(true);
                    UnityroomApiClient.Instance.SendScore(1, pm.goodPoint, ScoreboardWriteMode.HighScoreDesc);
                    Time.timeScale = 0;
                }
            }
            timetext.text = hours.ToString("00") + ":" + minute.ToString("00");
        }



        
        
        
    }
    public void tweet()
    {
        naichilab.UnityRoomTweet.Tweet ("theultimategoodact", "善き行いを積み重ねたことで、心が癒された...!");
    }
}
