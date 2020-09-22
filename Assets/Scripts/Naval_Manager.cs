﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naval_Manager : MonoBehaviour
{

    //Org_manager og;


    // Start is called before the first frame update
    void Start()
    {
        //ogの取得。
        //og = 
        Deploy_pilots();
    }

    // Update is called once per frame
    void Update()
    {
        //deploy_pilots();
    }

    public Org_manager og()
    {
        return GameObject.Find("OrgManager").GetComponent<Org_manager>();

    }

    //表示用。
    public void Deploy_pilots()
    {
        int i=0;

        //配下
        foreach (Transform n in GameObject.Find("Content_pilot_list").transform)
        {
            GameObject.Destroy(n.gameObject);
        }

        foreach (Aircraft ac in og().List_friend_aircraft)
        {


            //プレファブを配置する親を指定。
            //GameObject.Find("Content_pilot_list")

            //使いたいプレファブの指定。
            GameObject pilot_unit = (GameObject)Resources.Load("Prefabs/Panel_pilot");

            //インスタンス化。
            GameObject p1 = Instantiate(pilot_unit, GameObject.Find("Content_pilot_list").transform);

            //
            //UI更新
            p1.GetComponent<pilot_pnael_ui_manager>().Update_ui(ac.Pilot_name, ac.Unit_name, ac.Flg_disabled);

            //インデックスを教えてあげる。

            p1.GetComponent<pilot_pnael_ui_manager>().Know_its_id(i);

            //インデックス更新。
            i += 1;

        }




    }

}
