using System;
using System.Collections;
using System.Collections.Generic;
using My_Scripts;
using UnityEngine;

public class PatinetsManager : MonoBehaviour
{
    [SerializeField] private int pjNumber;
    [SerializeField] private Sprite tree;
    [SerializeField] private SpriteRenderer treebaloon;
    [SerializeField] private SpriteRenderer sad;
    [SerializeField] private Sprite egao;
    [SerializeField] private Player_Manager playermanager; 
    //[SerializeField] private int kotai;

    private bool _myKotai;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetPoint()
    {
        playermanager.goodPoint++;
        playermanager.hai[pjNumber] = true;
        playermanager.goodtext.text = "善き行いの数:"+playermanager.goodPoint;
        sad.sprite = egao;
        playermanager.movespeed += 0.05f;
        playermanager.mm.SeExport(4);
    }
    //
    void outText(string a, string b)
    {
        playermanager.whotext.text = a;
        playermanager.texts.text = b;
    }

    private void OnTriggerEnter(Collider other)
    {
        playermanager.mm.SeExport(2);
    }
    private void OnTriggerExit(Collider other)
    {
        playermanager.whotext.text = "町の声:";
        playermanager.texts.text = "";
    }
    
    private void OnTriggerStay(Collider other)
    {
        switch (pjNumber)
        {
            case 0:
            {
                outText("おばあさん:","腰が重くてスーパーに行けない...\nだれか運んでくれんかのぉ");
                break;
            }
            case 1:
            {
                if (!(playermanager.hai[pjNumber]))
                {
                    outText("スーパー:", "いつもくるはずのおばあちゃんがいない...");
                }
                else
                {
                    outText("おばあさん:","本当にありがとうね...");
                }

                break;
            }
            case 2:
            {
                
                if (!(playermanager.hai[pjNumber]))
                {
                    outText("サラリーマン:","財布を落とした...\n赤いがま口の財布気に入ってたのに..");
                }
                else
                {
                    outText("サラリーマン:","あったぁぁぁぁぁぁぁ！！！！ありがとう！");
                }
                break;
            }
            case 3:
            {
                outText("赤い財布","持ち主に届けよう！");
                break;
            }
            case 4:
            {
                outText("ゴミ収集所","ここにゴミを集めよう！");
                break;
            }
            case 5:
            case 6:
            case 7:
            case 8:
            {
                outText("ゴミ","ゴミだ！！！！！！\n捨てなきゃ!!!!!");
                
                break;
            }
            case 9:
            {
                if (!(playermanager.hai[pjNumber]))
                {
                    outText("緑サラリーマン:","財布を落としtaaa...\n緑のがま口の財布気に入ってたのに..");
                }
                else
                {
                    outText("緑サラリーマン:","みつけてくれたのぉ？ほんとありがとねぇ...!");
                }
                break;
            }
            case 10:
            {
                outText("緑色の財布","緑色の財布だ！\n 持ち主に届けよう！");
                break;
            }
            case 11:
            {
                
                if (!(playermanager.hai[pjNumber]))
                {
                    outText("スーパーの警備員:", "悪い人を倒すための道具を置いてきてしまった...\nどこにおいたっけ...?");
                }
                else
                {
                    outText("スーパーの警備員:", "ありがとう！\nついでだからこのさすまたあげるよ！");
                }
                break;
            }
            case 12:
            {
                outText("さすまた","これで悪い人をとっちめられる...!");
                
                break;
            }
            case 13:
            {
                
                if (!(_myKotai))
                {
                    outText("少女:","風船が...!\nなにか登れるものはないかしら...?");
                }
                else
                {
                    outText("少女:", "うおおおぉ、ありがとう...!\n(しかし、脚立は壊れてしまった)");
                }

                break;
            }
            case 14:
            {
                outText("脚立専門店","脚立を売ってるお店!");
                break;
            }
            case 15:
            {
                
                if (!(playermanager.hai[pjNumber]))
                {
                    outText("銀行","銀行強盗だ...!\n早くここから逃げよう！");
                }
                else
                {
                    outText("銀行の偉い人:","極悪人を倒したこと、感謝するよ。本当にありがとう。");
                }
                break;
            }
            case 16:
            {
                
                if (!(_myKotai))
                {
                    outText("少年:","アイス落としちゃった...!\nどうして自分ばかり...");
                }
                else
                {
                    outText("少年:","うぇぇえぇえ神!?\n本当に本当にありがとう！！");
                }
                break;
            }
            case 17:
            {
                outText("アイスクリームの店","アイス屋さんだ\nここではアイスを買えるよ!");
                break;
            }
            case 18:
            {
                
                if (!(_myKotai))
                {
                    outText("子猫:","ニャー(登ったら降りれなくなった...\nなにか降りれるものが欲しい二ャ)");
                }
                else
                {
                    outText("子猫:","ニャー(恩に着る！)\n(しかし脚立は壊れてしまった)");
                }
                break;
            }
            default:
            {
                break;
            }
        }
        //コライダーが当たっていると継続して呼ばれる
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            switch (pjNumber)
            {
                case 0: //おばあさんを担ぐ
                {
                    playermanager.projectnumbers[pjNumber] = true;//イベント統括
                    playermanager.projectnumbers[pjNumber+1] = true; // sorrry
                    playermanager.mm.SeExport(3);
                    playermanager.movespeed -= 0.25f;
                    outText("おばあさん:","優しい猫だ、ありがとう\n(おばあさんを乗せたためスピードダウン)");
                    this.gameObject.SetActive(false);
                    //Debug.Log("おばあ担ぐ");
                    break;
                }
                case 1:　// おばあさんをゴールまで届ける
                {
                    if (playermanager.projectnumbers[pjNumber-1]&&playermanager.projectnumbers[pjNumber] )
                    {
                        playermanager.movespeed += 0.3f;
                        playermanager.projectnumbers[pjNumber] = false;
                        playermanager.mm.SeExport(4);
                        GetPoint();
                        //Debug.Log("おばあおろす");
                        //this.gameObject.SetActive(false);
                    }
                    else
                    {
                        outText("スーパー:","どこにいるんだろう...");
                        playermanager.mm.SeExport(1);
                    }

                    break;
                }
                case 2:　// 落とし物をして困っている
                {
                    if (playermanager.projectnumbers[pjNumber])
                    {
                        GetPoint();
                        //Debug.Log("落とし物渡す");
                        this.gameObject.SetActive(false);
                    }
                    else
                    {
                       // Debug.Log("落とし物渡せない");
                       playermanager.mm.SeExport(1);
                    }

                    break;
                }
                case 3:　// 落とし物自体のイベント
                {
                    playermanager.projectnumbers[pjNumber-1] = true;
                    //Debug.Log("落とし物拾った");
                    playermanager.mm.SeExport(3);
                    this.gameObject.SetActive(false);

                    break;
                }
                case 4:　// ゴミ箱のイベント
                {
                    int gomi = 0;
                    if (playermanager.projectnumbers[5])
                    {
                        GetPoint();
                        outText("ゴミ収集所","ゴミを正しい場所に捨てるのは気持ちがいいね！");
                        playermanager.projectnumbers[5] = false;
                    }
                    else
                    {
                        gomi++;
                    }
                    if (playermanager.projectnumbers[6])
                    {
                        GetPoint();
                        outText("ゴミ収集所","ゴミを正しい場所に捨てるのは気持ちがいいね！");
                        playermanager.projectnumbers[6] = false;
                    }
                    else
                    {
                        gomi++;
                    }
                    if (playermanager.projectnumbers[7])
                    {
                        GetPoint();
                        outText("ゴミ収集所","ゴミを正しい場所に捨てるのは気持ちがいいね！");
                        playermanager.projectnumbers[7] = false;
                    }
                    else
                    {
                        gomi++;
                    }
                    if (playermanager.projectnumbers[8])
                    {
                        GetPoint();
                        outText("ゴミ収集所","ゴミを正しい場所に捨てるのは気持ちがいいね！");
                        playermanager.projectnumbers[8] = false;
                    }
                    else
                    {
                        gomi++;
                    }

                    if (gomi == 4)
                    {
                        playermanager.mm.SeExport(1);
                    }

                    break;
                }
                case 5:　// ゴミ自体のイベント
                {
                    playermanager.projectnumbers[pjNumber] = true;
                    //Debug.Log("落とし物拾った");
                    playermanager.mm.SeExport(3);
                    this.gameObject.SetActive(false);
                    break;
                }
                case 6:　// 落とし物自体のイベント
                {
                    playermanager.projectnumbers[pjNumber] = true;
                    //Debug.Log("落とし物拾った");
                    playermanager.mm.SeExport(3);
                    this.gameObject.SetActive(false);
                    break;
                }
                case 7:　// 落とし物自体のイベント
                {
                    playermanager.projectnumbers[pjNumber] = true;
                    //Debug.Log("落とし物拾った");
                    playermanager.mm.SeExport(3);
                    this.gameObject.SetActive(false);
                    break;
                }
                case 8:　// 落とし物自体のイベント
                {
                    playermanager.projectnumbers[pjNumber] = true;
                    //Debug.Log("落とし物拾った");
                    playermanager.mm.SeExport(3);
                    this.gameObject.SetActive(false);
                    break;
                }
                case 9:　// 緑の落とし物をして困っている
                {
                    if (playermanager.projectnumbers[pjNumber])
                    {
                        GetPoint();
                        //Debug.Log("落とし物渡す");
                        this.gameObject.SetActive(false);
                    }
                    else
                    {
                        // Debug.Log("落とし物渡せない");
                        playermanager.mm.SeExport(1);//キャンセル
                    }

                    break;
                }
                case 10:　// 落とし物自体のイベント
                
                {
                    playermanager.projectnumbers[pjNumber-1] = true;
                    playermanager.mm.SeExport(3);
                    //Debug.Log("落とし物拾った");
                    this.gameObject.SetActive(false);

                    break;
                }
                case 11:　// さすまたの落とし物をして困っている、銀統合等倒せる
                {
                    if (playermanager.projectnumbers[pjNumber])
                    {
                        GetPoint();
                        //Debug.Log("落とし物渡す");
                        playermanager.projectnumbers[15] = true;
                        playermanager.projectnumbers[pjNumber+1] = false;
                        outText("スーパーの警備員:", "ありがとう！\nついでだからこのさすまたあげるよ！");
                        this.gameObject.SetActive(false);

                    }
                    else
                    {
                        // Debug.Log("落とし物渡せない");
                        playermanager.mm.SeExport(1);
                        
                    }

                    break;
                }
                case 12:　// さすまた落とし物自体のイベント
                {
                    playermanager.projectnumbers[pjNumber-1] = true;
                    playermanager.projectnumbers[pjNumber] = true;
                    //Debug.Log("落とし物拾った");
                    playermanager.mm.SeExport(3);
                    this.gameObject.SetActive(false);

                    break;
                }
                case 13:　// 風船のイベント
                {
                    if (playermanager.projectnumbers[pjNumber])
                    {
                        GetPoint();
                        //Debug.Log("落とし物渡す");
                        treebaloon.sprite = tree;
                        _myKotai = true;
                        playermanager.projectnumbers[pjNumber] = false;
                        
                    }
                    else
                    {
                        // Debug.Log("落とし物渡せない");
                        playermanager.mm.SeExport(1);
                    }

                    break;
                }
                case 14:　// 脚立のイベント
                {
                    if (playermanager.projectnumbers[pjNumber - 1] == false)
                    {
                        playermanager.projectnumbers[pjNumber - 1] = true;
                        playermanager.mm.SeExport(3);
                        //Debug.Log("落とし物拾った");
                    }
                    else
                    {
                        outText("自分自身:","(2個以上持つのは厳しいニャ)");
                        playermanager.mm.SeExport(1);
                    }

                    break;
                }
                case 15:　// さすまたの落とし物をして困っている、銀行強盗倒せる
                {
                    if (playermanager.projectnumbers[12])
                    {
                        outText("自分自身:","いくら落とし物だからと言って、人のものを勝手に使うのは気が引けるニャ...");
                        break;
                    }
                    if (playermanager.projectnumbers[pjNumber])
                    {
                        
                        playermanager.goodPoint += 2;
                        GetPoint();
                        //Debug.Log("落とし物渡す");
                        playermanager.projectnumbers[pjNumber] = false;
                        treebaloon.sprite = tree;
                    }
                    else
                    {
                        // Debug.Log("落とし物渡せない");
                        playermanager.mm.SeExport(1);
                    }

                    break;
                }
                case 16:　// アイスクリームのイベント
                {
                    if (playermanager.projectnumbers[pjNumber])
                    {
                        GetPoint();
                        //Debug.Log("落とし物渡す");
                        treebaloon.sprite = tree;
                        _myKotai = true;
                        outText("少年:","うぇぇえぇえ神!?\n本当に本当にありがとう！！");
                        playermanager.projectnumbers[pjNumber] = false;
                        
                    }
                    else
                    {
                        // Debug.Log("落とし物渡せない");
                        playermanager.mm.SeExport(1);
                    }

                    break;
                }
                case 17:　// アイス買いに行くイベント
                {
                    if (playermanager.projectnumbers[pjNumber - 1] == false)
                    {
                        playermanager.projectnumbers[pjNumber - 1] = true;
                        playermanager.mm.SeExport(3);
                        _myKotai = true;
                        //Debug.Log("落とし物拾った");
                    }
                    else
                    {
                        outText("自分自身:","(2個以上持つのは厳しいニャ)");
                        playermanager.mm.SeExport(1);
                    }

                    break;
                }
                case 18:　// 木の猫のイベント
                {
                    if (playermanager.projectnumbers[13])
                    {
                        GetPoint();
                        //Debug.Log("落とし物渡す");
                        playermanager.projectnumbers[13] = false;
                        _myKotai = true;
                        outText("子猫:","ニャー(恩に着る！)\n(しかし脚立は壊れてしまった)");
                        this.gameObject.SetActive(false);
                        
                    }
                    else
                    {
                        // Debug.Log("落とし物渡せない");
                        playermanager.mm.SeExport(1);
                    }

                    break;
                }
                
                default:
                {

                    break;
                }
            }
        }
    }
}
