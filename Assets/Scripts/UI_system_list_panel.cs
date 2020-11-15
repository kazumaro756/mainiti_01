using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// これがリストから並べる系処理の共通バージョンとなる。
/// </summary>
public class UI_system_list_panel : MonoBehaviour
{
    [SerializeField]
    GameObject content;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //引数の型を自由に指定できるようにする。
    //明らかに変な実装だ。。。。
    public void Deploy<TypeA_list, TypeB_class, TypeC_class>(TypeA_list list_unit, GameObject unit_prefab)
        where TypeA_list : List<TypeB_class>
        where TypeC_class : Prefab_UI_abs // これはあくまで既定クラスという意味なのだが。それであってるんか。
    {
        //リストを取得。

        //最初に配下をすべて破壊。要はリセット処理だ。
        foreach (Transform n in content.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
        //リスト内のループ処理で個別のものをインスタンス化
        foreach (TypeB_class unit in list_unit)
        {
            //プレファブをインスタンス化
            //インスタンス化。
            GameObject ins = Instantiate(unit_prefab, content.transform);

            
            //UI更新をかける。クラスを投げる
            ins.GetComponent<TypeC_class>().UpdateUI<TypeB_class>(unit);

        }
        
       
    }

}
