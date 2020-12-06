using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Butai_hensei_view : MonoBehaviour
{
    [SerializeField]
    private Text text_name;


    [SerializeField]
    private Dropdown dd_type;

    [SerializeField]
    private Dropdown dd_rank;

    private int selected_value_type;
    private int selected_value_rank;

    private Air_Fleet self_af;

    public Air_Fleet Self_af { get => self_af; set => self_af = value; }

    // Start is called before the first frame update
    void Start()
    {
        Update_enum<unit_type>(dd_type);
        //Update_enum<unit_rank>(dd_rank);

        Limit_rank(dd_rank, self_af.Air_fleet_battle_order_rank);

        //dropdownの初期値を入れないとバグるので入れる
        //実態としては入りうるナカで一番上のランクが入る。
        selected_value_rank = self_af.Air_fleet_battle_order_rank + 1;

    }

    //ただし、選びホーダイというわけではないので注意。自分のランクより低いものを使うべき。自分自身を知らないことにはな。


    public void Limit_rank(Dropdown drop,int selfrank)
    {
        List<int> list_int = new List<int>();
        List<string> list_string = new List<string>();

        //使えるもののみ利用。
        foreach (int a in System.Enum.GetValues(typeof(unit_rank)))
        {
            if (a > selfrank) { list_int.Add(a); }
        }

        //使えるものリストから抽出して、文字列のデータを作る。
        foreach(int a in list_int)
        {
            unit_rank enumValue = (unit_rank)System.Enum.ToObject(typeof(unit_rank), a);
            string enum_string = System.Enum.GetName(typeof(unit_rank), enumValue);
            list_string.Add(enum_string);

        }
        //DropDownの要素にリストを追加
        drop.AddOptions(list_string);
    }


    public void Update_enum<T>(Dropdown drop) where T : struct
    {

        

        //EnumをStringの配列に変換
        string[] enumNames = System.Enum.GetNames(typeof(T));

        


        //Stringの配列をリストに変換
        List<string> names = new List<string>(enumNames);

        //DropDownの要素にリストを追加
        drop.AddOptions(names);


    }

    public void Update_all(Air_Fleet af)
    {
        text_name.text = af.Name;
        
    }

    public void Get_drop_type()
    {
        selected_value_type = dd_type.value;
        
    }

    public void Get_drop_rank()
    {
        //このとり方だとenum側と合わなくなるのですよ。1スタートなので1を足す。
        selected_value_rank = dd_rank.value + self_af.Air_fleet_battle_order_rank + 1;
        Debug.Log(selected_value_rank);
    }


    // Update is called once per frame
    void Update()
    {
       
    }

    //わからんですが
    public void Add_new_org()
    {
        //が
        //


        //int parent_id,int rank_parent , int rank_child)

        //gameobject
        Debug.Log(selected_value_rank);

        GameObject.Find("MapManager").GetComponent<Map_Data>().Create_new_org(Self_af.Air_fleet_id, Self_af.Air_fleet_battle_order_rank, selected_value_rank);

    }


}
