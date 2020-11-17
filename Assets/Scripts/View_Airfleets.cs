using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Airfleets : MonoBehaviour
{
    [SerializeField]
    GameObject koukuutai;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //駐留艦隊情報。　渡すべきは、リストと、実際の型。
    public void Update_Unit_Rerated_UI(List<Air_Fleet> a)
    {
        //部隊ごとの処理が必要。

        //ボタンのプレファブを作成
        GameObject prefab_air = (GameObject)Resources.Load("Prefabs/Panel_air_fleet");

        //実際の関数を叩く。
        koukuutai.GetComponent<UI_system_list_panel>().Deploy<List<Air_Fleet>, Air_Fleet, Prefab_UI_airfleet_task>(a, prefab_air);
    }

}
