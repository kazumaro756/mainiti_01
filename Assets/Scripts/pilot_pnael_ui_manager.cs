using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pilot_pnael_ui_manager : MonoBehaviour
{
    [SerializeField]
    Text text_pilot_name,text_unit_name,text_unit_status;

    private int pilot_id;

    public int Pilot_id { get => pilot_id; set => pilot_id = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //自らのIDを知る。
    public void Know_its_id(int index)
    {
        pilot_id = index;
    }

    //補充
    public void Hozyuu()
    {
        GameObject og = GameObject.Find("OrgManager");

        og.GetComponent<Org_manager>().Hozyu(og.GetComponent<Org_manager>().List_friend_aircraft[pilot_id]);


        //UI更新。
        Update_ui(og.GetComponent<Org_manager>().List_friend_aircraft[pilot_id].Pilot_name, og.GetComponent<Org_manager>().List_friend_aircraft[pilot_id].Unit_name, og.GetComponent<Org_manager>().List_friend_aircraft[pilot_id].Flg_disabled);
    }


    //updateui 生成するときに呼ばれる。
    public void Update_ui(string pilot_name, string unit_name, bool status)
    {
        text_pilot_name.text = pilot_name;
        text_unit_name.text = unit_name;

        //破壊フラグがtrueなら
        if (status)
        {
            text_unit_status.text = "損壊";
        }
        else
        {
            text_unit_status.text = "健全";
        }

    }

}
