using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Order : MonoBehaviour
{
    //配下のリストを得てみよう。
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //子供を追加。する。
    public void Add_Children()
    {
        //使いたいプレファブの指定。
        GameObject pilot_unit = (GameObject)Resources.Load("Prefabs/Panel_2");

        //インスタンス化。
        GameObject p1 = Instantiate(pilot_unit, this.transform.parent);

        //場所を変更。
        p1.transform.SetSiblingIndex(this.transform.GetSiblingIndex()+1);

    }

}
