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

    [SerializeField]
    GameObject pool_hyouzi_panel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //プールに保存してある艦船を表示する。
    public void Deploy_ship_in_pool(List<Ship_test> list_st)
    {
        //まず初期化。
        foreach (Transform n in pool_hyouzi_panel.transform)
        {
            GameObject.Destroy(n.gameObject);
        }


        foreach (Ship_test st in list_st)
        {
            GameObject obj = (GameObject)Resources.Load("Prefabs/Panel_poolship");

            //instance化
            GameObject ins = Instantiate(obj, pool_hyouzi_panel.transform);

            ins.GetComponent<ui_ship_pool>().Update_UI(st.ship_type,st.ship_class,st.ship_name);

        }


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
                sc.ship_class_id  );

            //ボタンに設定。
 

        }



    }
    


}
