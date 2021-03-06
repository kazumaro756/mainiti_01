﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Order : MonoBehaviour
{
    //外側から変更するメンバ変数。
    public int self_id;
    public int rank;


    //親になる部隊.
    public GameObject parent_object;

    //自分のaf。これをもらう仕様にするべき。

    //制御用
    private bool tenkai_flg;

    //削除するときに参照するよう
    //重複を無視してほしいので、Listなるものを使う。
    public List<GameObject> list_child = new List<GameObject>();



    //これをインスタンス化したタイミングで渡す設計にする。
    public int Self_id { get => self_id; set => self_id = value; }
    public int Rank { get => rank; set => rank = value; }

    //これについては、外側からわかるようにしておかないといけない。
    public List<GameObject> List_child { get => list_child; set => list_child = value; }
    public GameObject Paret_object { get => parent_object; set => parent_object = value; }


    // Start is called before the first frame update
    void Start()
    {
        tenkai_flg = false;
    }

    //統合的な2つの関数を表現している。純粋なview寄りのやつ。
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




    //再帰的追加処理。
    private void Recursive_add_child(GameObject p_object,GameObject tgt)
    {
        if (p_object != null)//親チェック
        {
            //親処理
            p_object.GetComponent<Battle_Order>().List_child.Add(tgt);

            //じいちゃんチェック
            if (p_object.GetComponent<Battle_Order>().Paret_object != null)
            {
                //じいちゃん処理。
                Recursive_add_child(p_object.GetComponent<Battle_Order>().Paret_object, tgt);


            }
            else
            {
                return;
            }

        }
        else
        {
            return;
        }



    }
   


    //子供を追加。する。
    public void Add_Children()
    {

        //boのリストを取得。
        //使うもののみ取得。 ここで子を知る　
        List<Battle_order> list_use = GameObject.Find("MapManager").GetComponent<Map_Data>().List_battle_ordre.FindAll(x => x.Parent_org_id == self_id);

        //対象のリストも取得。
        List<Air_Fleet> list_afs = GameObject.Find("MapManager").GetComponent<Map_Data>().List_air_fleet;

        //for文でまわす
        int idx = 1;

        //フォーイーチ文
        foreach (Battle_order bo in list_use)
        {


            //艦隊の詳細情報を取得。
            Air_Fleet af = list_afs.Find(x => x.Air_fleet_id == bo.Child_org_id);

            //使いたいプレファブを指定。自分自身の階層よりも一個下で取得。
            //ここの実装がなんか変では？
            //やっぱり編制と編成を分けてないのが問題だ。
            //ここではrankを作っている。
           
            GameObject bo_unit = (GameObject)Resources.Load("Prefabs/Panel_1");

            //画像を変更
            //(Image)Resources.Load("Symbols/rank_"+(af.Air_fleet_battle_order_rank));

            //インスタンス化.自分と同じオブジェクトに配置する。
            GameObject t1 = Instantiate(bo_unit, this.transform.parent);


            //子に親を教える。
            t1.GetComponent<Battle_Order>().Paret_object = this.gameObject;

            //階層設定。親の一つ下に追加する。kここでインデックスを使ってる。
            t1.transform.SetSiblingIndex(this.transform.GetSiblingIndex() + idx);

            //次の配置用に修正。
            idx += 1;

            //作成したインスタンスの設定。
            t1.name = "bo_" + bo.Child_org_id;
            //ビュー関数を流してUIを更新。


            //TODO。リストをもらってくる。
            t1.GetComponent<Battle_order_view>().update_all_ui(af,Rank);
            //Debug.Log(rank);

            //ここの処理について。

            //リスト作成用。
            list_child.Add(t1);

            //親にとっての子に対しても追加する。
            //ここもうちょっときれいにする。
            

            //親に対して取得
            //再帰的な処理。
            Recursive_add_child(Paret_object, t1);

            //if (Paret_object != null)
            //{
            //    //親処理
            //    Paret_object.GetComponent<Battle_Order>().List_child.Add(t1);

            //    //じいちゃんチェック
            //    if (Paret_object.GetComponent<Battle_Order>().Paret_object != null)
            //    {
            //        //じいちゃん処理。
            //        Paret_object.GetComponent<Battle_Order>().Paret_object.GetComponent<Battle_Order>().List_child.Add(t1);
                    
            //        //曾祖父ちゃんチェック
            //        if(Paret_object.GetComponent<Battle_Order>().Paret_object.GetComponent<Battle_Order>().Paret_object != null)
            //        {
            //            Paret_object.GetComponent<Battle_Order>().Paret_object.GetComponent<Battle_Order>().Paret_object.GetComponent<Battle_Order>().List_child.Add(t1);

            //            //if()
            //        }


            //    }

            //}

            //t1に対してさらにその配下もあたえないとね。
            //こっちは親の組織IDをもたせる。
            t1.GetComponent<Battle_Order>().Self_id = af.Air_fleet_id;

            //ここどういう設計にするかあとで考える。
            t1.GetComponent<Battle_Order>().Rank = af.Air_fleet_battle_order_rank;


            //テスト
            //Debug.Log( GameObject.Find("battle_order1").GetComponent<Battle_Order>().list_child.Count);

        }
    }

    //出ていたものを外す。
    public void Close_Chirldren()
    {

        //子供オブジェクトをすべて殺す。
        foreach (GameObject a in list_child)
        {
            Destroy(a);
        }

        //listはクリアする。
        list_child.Clear();

    }

    //組織編成画面をオープンする。
    public void Open_Org_Making_Panel()
    {
        //自分のインスタンスを取得
        //対象のリストも取得。
        Air_Fleet selfaf = GameObject.Find("MapManager").GetComponent<Map_Data>().List_air_fleet.Find(x => x.Air_fleet_id == Self_id);

        //部隊編成をするための画面をインスタンス化
        GameObject bo_unit = (GameObject)Resources.Load("Prefabs/Pane_butai_hensei");

        //インスタンス化
        GameObject t1 = Instantiate(bo_unit, this.transform.root);

        t1.GetComponent<Butai_hensei_view>().Update_all(selfaf);

        //自分自身を渡す。
        t1.GetComponent<Butai_hensei_view>().Self_af = selfaf;



    }





}
