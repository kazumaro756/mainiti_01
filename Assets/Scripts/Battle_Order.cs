using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Order : MonoBehaviour
{
    //外側から変更するメンバ変数。
    private int self_id;
    private int rank;

    //制御用
    private bool tenkai_flg;

    //これをインスタンス化したタイミングで渡す設計にする。
    public int Self_id { get => self_id; set => self_id = value; }
    public int Rank { get => rank; set => rank = value; }

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


    //子供を追加。する。
    public void Add_Children()
    {
        //使いたいプレファブを指定。自分自身の階層よりも一個下で取得。
        GameObject bo_unit = (GameObject)Resources.Load("Prefabs/Panel_"+(rank+1));
        
        //boのリストを取得。
        //使うもののみ取得。
        List<Battle_order> list_use = GameObject.Find("MapManager").GetComponent<Map_Data>().List_battle_ordre.FindAll(x => x.Parent_org_id == self_id);


        //対象のリストも取得。
        List<Air_Fleet> list_afs = GameObject.Find("MapManager").GetComponent<Map_Data>().List_air_fleet;

        //for文でまわす
        int idx = 1;
        //フォーイーチ文
        foreach (Battle_order bo in list_use)
        {
            //インスタンス化.自分と同じオブジェクトに配置する。
            GameObject t1 = Instantiate(bo_unit, this.transform.parent);

            //階層設定。親の一つ下に追加する。
            t1.transform.SetSiblingIndex(this.transform.GetSiblingIndex() + idx);

            //次の配置用に修正。
            idx += 1;

            //作成したインスタンスの設定。
            t1.name = "bo_" + bo.Child_org_id;
            //ビュー関数を流してUIを更新。
            //艦隊の詳細情報を取得。
            Air_Fleet af = list_afs.Find(x => x.Air_fleet_id == bo.Child_org_id);

            //TODO。リストをもらってくる。
            t1.GetComponent<Battle_order_view>().update_view(af.Name);
        }
    }

    //出ていたものを外す。
    public void Close_Chirldren()
    {
        //配下をすべて破壊する。
        foreach (Transform child in this.transform)
        {
            // 一つずつ破棄する
            Destroy(child.gameObject);
        }
    }


}
