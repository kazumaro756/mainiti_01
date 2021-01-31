using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    [SerializeField]
    GameObject Resouce_ui_controller;

    //リソースクラスを持った方がいいんでねえかね？
    //こっちの方がよい。

    public int money;


    // Start is called before the first frame update
    void Start()
    {
        money = 2000;
        //UI
        Resouce_ui_controller.GetComponent<ResourceUiController>().Update_money_text(100.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //撃沈されたときのリザルト結果
    public void GetMoneyFromEnemy(int get_money )
    {
        //お金を増やす。
        money += get_money;
        Resouce_ui_controller.GetComponent<ResourceUiController>().Update_money_text(money.ToString());

    }

    //お金をもっているのかを確認処理。
    public bool Check_enough_money(int cost)
    {
        
        if (cost <= money)
        {
            //お金を使う処理。
            return true;
        }
        else
        {

            //Debug.Log("お金ないです");
            return false;
        }
      

    }

    //
    public void UseMoney(int cost )
    {
        //お金を減らす。
        money -= cost;

        //UIを更新する。
        Resouce_ui_controller.GetComponent<ResourceUiController>().Update_money_text(money.ToString());

    }

}
