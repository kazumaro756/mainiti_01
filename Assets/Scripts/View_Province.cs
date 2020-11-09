﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_Province : MonoBehaviour
{
    [SerializeField]
    Text provi_name;
    [SerializeField]
    Text provi_faction;
    [SerializeField]
    Text provi_butai;
    [SerializeField]
    Text mil_port_size;
    [SerializeField]
    Text mil_port_damage;

    [SerializeField]
    Text private_port_size, private_port_damage;

    [SerializeField]
    Text supply_count, fuel_count;


    //一般的な関数
    public void UpdateUI(Text arg_uitext,string arg_string)
    {
        arg_uitext.text = arg_string;
    }

    //アップデート
    public void UpdateAllUI(string arg1, string arg2, string arg3, string arg4, string arg5, string arg6, string arg7, string arg8, string arg9)
    {
        UpdateUI(provi_name, arg1);
        UpdateUI(provi_faction, arg2);
        UpdateUI(provi_butai, arg3);
        UpdateUI(mil_port_size, arg4);
        UpdateUI(mil_port_damage, arg5);
        UpdateUI(private_port_size, arg6);
        UpdateUI(private_port_damage, arg7);
        UpdateUI(supply_count, arg8);
        UpdateUI(fuel_count, arg9);
    }


}