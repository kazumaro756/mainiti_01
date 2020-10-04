using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aircraft : MonoBehaviour
{
    [SerializeField]
    Text name_text;

    [SerializeField]
    Text name_durability;

    [SerializeField]
    Slider slider_durability;

    private string unit_name;
    private string pilot_name;
    private int max_durability;
    private int current_durability;

    private int pilot_exp;

    private bool flg_disabled;
    private bool flg_destroyed;

    public int Max_Durability { get => max_durability; set => max_durability = value; }
    public int Current_durability { get => current_durability; set => current_durability = value; }
    public string Unit_name { get => unit_name; set => unit_name = value; }
    public bool Flg_disabled { get => flg_disabled; set => flg_disabled = value; }
    public bool Flg_destroyed { get => flg_destroyed; set => flg_destroyed = value; }
    public string Pilot_name { get => pilot_name; set => pilot_name = value; }
    public int Pilot_exp { get => pilot_exp; set => pilot_exp = value; }

    public Aircraft(string con_unit_name, string con_pilot_name, int con_max_dura, int con_current_dura, int con_exp, bool con_dis,bool con_des)
    {
        unit_name = con_unit_name;
        pilot_name = con_pilot_name;
        max_durability = con_max_dura;
        current_durability = con_current_dura;
        pilot_exp = con_exp; 
        flg_disabled = con_dis;
        flg_destroyed = con_des;

    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        name_text.text = unit_name;
        name_durability.text = current_durability.ToString();
        slider_durability.value = current_durability * 1.0f / max_durability * 1.0f;
    }

    /// <summary>
    /// 魚雷攻撃の話だ。
    /// </summary>
    /// <param name="tgt_ship"></param>
    /// <returns></returns>
    public bool Attack_troped(Ship tgt_ship )
    {
        //命中率
        if (Random.Range(1.0f, 100.0f) < 50 + (pilot_exp / 100) - (10))
        {

            tgt_ship.Current_durability -= 2000;
            //Debug.Log("HIT");
            Logging(pilot_name + "HIT\n攻撃は成功しました。");

            return true;
        }
        else
        {
           // Debug.Log("NO HIT");
            Logging(pilot_name + "NO HIT\n攻撃は失敗しました。");

            return false;
        }

        


    }
    
    //攻撃オプションはまた別よね。
    public void Attack_enemy()
    {
        Attack_troped(GameObject.Find("Panel_friend_info").GetComponent<Ship>());

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
