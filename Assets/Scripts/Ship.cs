using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    [SerializeField]
    Text name_text;

    [SerializeField]
    Text name_durability;

    [SerializeField]
    Slider slider_durability;

    private string unit_name;
    private int max_durability;
    private int current_durability;


    public int Max_Durability { get => max_durability; set => max_durability = value; }
    public int Current_durability { get => current_durability; set => current_durability = value; }
    public string Unit_name { get => unit_name; set => unit_name = value; }


    //コンストラクタ
    public Ship(string con_unit_name , int con_max_dura,int con_cure_dura)
    {
        unit_name = con_unit_name;
        max_durability = con_max_dura;
        current_durability = con_cure_dura;

    }



    // Start is called before the first frame update
    void Start()
    {
        //Unit_name = "飛龍";
        //Max_Durability = 20000;
        //Current_durability = 20000;

    }

    // Update is called once per frame
    void Update()
    {
        name_text.text = unit_name;
        name_durability.text = current_durability.ToString();
        slider_durability.value = current_durability * 1.0f / max_durability * 1.0f;


    }

    //艦隊防空による反撃。これにやられる人多し。
    public void Danamaku(Aircraft tgt_aircraft)
    {
        //命中率
        if (Random.Range(1.0f, 100.0f) < 50 +(10) -(tgt_aircraft.Pilot_exp/100)  )
        {
            //
          

            tgt_aircraft.Current_durability -= 200;
            
            Logging(unit_name + "HIT\n対空攻撃は成功しました。");
        }
        else
        {
            Logging(unit_name + "NO HIT\n対空攻撃は失敗しました。");
        }




    }

    //ロギング系の関数。
    public void Logging(string out_put)
    {
        // CubeプレハブをGameObject型で取得
        GameObject log_unit = (GameObject)Resources.Load("Prefabs/Panel");

        GameObject test1 = Instantiate(log_unit, GameObject.Find("Content_log").transform);

        test1.GetComponent<test_base>().textupdate(out_put);

    }


}
