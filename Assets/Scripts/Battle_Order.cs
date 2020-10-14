using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Order : MonoBehaviour
{
    //配下のリストを得てみよう。
    List<int> a;

    private bool tenkai_flg;

    [SerializeField]
    Text t;

    // Start is called before the first frame update
    void Start()
    {
        tenkai_flg = false;

        //a.Add(1);
        //a.Add(2);
        //a.Add(3);

    }

    // Update is called once per frame
    void Update()
    {

    }


    //統合的な2つの関数を表現している。
    public void Control_Children()
    {
        if (tenkai_flg)
        {
            //展開されているときは殺す。
            Close_Chirldren();

            tenkai_flg = false;
        }
        else
        {
            //展開されていなければ展開する。
            Add_Children();

            //展開されている
            tenkai_flg = true;

        }

    }


    //子供を追加。する。
    public void Add_Children()
    {
        //使いたいプレファブの指定。
        GameObject pilot_unit1 = (GameObject)Resources.Load("Prefabs/Panel_2");
        GameObject pilot_unit2 = (GameObject)Resources.Load("Prefabs/Panel_3");
        GameObject pilot_unit3 = (GameObject)Resources.Load("Prefabs/Panel_4");
        GameObject pilot_unit4 = (GameObject)Resources.Load("Prefabs/Panel_5");

        //リストから取得してインスタンス化

        //インスタンス化。
        //GameObject p1 = Instantiate(pilot_unit1, this.transform.parent);

        //インスタンス化。
        GameObject p2 = Instantiate(pilot_unit2, this.transform.parent);

        //インスタンス化。
        GameObject p3 = Instantiate(pilot_unit3, this.transform.parent);

        //インスタンス化。
        //GameObject p4 = Instantiate(pilot_unit4, this.transform.parent);

        int i = 0;
        //フォーイーチ文
        //foreach (int item in a)
        //{
        //    if (item == 1) { p1.transform.SetSiblingIndex(this.transform.GetSiblingIndex() + 1); }
        //}

        //場所を変更。
        p2.name = "aaaa";
        p2.transform.SetSiblingIndex(this.transform.GetSiblingIndex() + 1);
        p3.name = "bbbb";
        p3.transform.SetSiblingIndex(this.transform.GetSiblingIndex() + 2);


    }

    public void Close_Chirldren()
    {
       　//配下になっているチルドレンを破壊する。
        GameObject g1 = GameObject.Find("aaaa");
        Destroy(g1);

        GameObject g2 = GameObject.Find("bbbb");
        Destroy(g2);
        //Destroy(GameObject.transform.GetSiblingIndex(this.transform.GetSiblingIndex() + 1));


    }


}
