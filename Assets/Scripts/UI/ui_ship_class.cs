using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ui_ship_class : MonoBehaviour
{
    [SerializeField]
    Text class_type;

    [SerializeField]
    Text class_name;

    [SerializeField]
    Text class_cost;

    [SerializeField]
    Button btn;
 

    public void Update_ui(string type,string name , int cost,MilitalyPortManager mp ,Ship_test st )
    {
        class_type.text = type;
        class_name.text = name;
        class_cost.text = cost.ToString() + "円";

        //ボタンに対して設定をする。
        btn.onClick.AddListener(() => mp.AddShiptoPort(st));


    }


    


    //ボタンに対して関数を設定するようにするべきだ。
    //ブタンが持つ関数を取得。引数に注意。拠点IDを読みにいってる。
    //button.onClick.AddListener(() => Pick_Province(provi.Provincial_id));

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
