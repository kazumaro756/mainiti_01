using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 製造するクラスについての情報を表示するUI管理コントローラー。
/// 
/// 
/// </summary>
public class Port_Panel_ui_controller : MonoBehaviour
{
    //gameobject コンテンツ
    [SerializeField]
    GameObject hyouzi_panel;

    [SerializeField]
    GameObject port_manager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //public void deploy_classes
    public void Deploy_Calsses (List<Ship_Class> list_sc )
    {
        //portmanager から制作する艦船リストを取得
        foreach (Ship_Class sc in list_sc)
        {

            //取得
            GameObject obj = (GameObject)Resources.Load("Prefabs/panel_class");
            

            //instance化
            GameObject ins = Instantiate(obj, hyouzi_panel.transform);

            //UI更新に必要な処理を呼び出し。
            ins.GetComponent<ui_ship_class>().Update_ui(sc.ship_type,sc.ship_class_name,sc.money_to_make,
                port_manager.GetComponent<MilitalyPortManager>() , 
                port_manager.GetComponent<MilitalyPortManager>().CreateShip("test",false,sc) );

            //ボタンに設定。
 

        }



    }
    


}
