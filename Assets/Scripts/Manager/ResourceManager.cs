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
        money = 100;
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


}
