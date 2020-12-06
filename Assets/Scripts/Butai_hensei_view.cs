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

    private int selected_value;

    private Air_Fleet self_af;

    public Air_Fleet Self_af { get => self_af; set => self_af = value; }

    // Start is called before the first frame update
    void Start()
    {
        Update_enum<unit_type>(dd_type);
        Update_enum<unit_rank>(dd_rank);
    }

    //ただし、選びホーダイというわけではないので注意。自分のランクより低いものを使うべき。自分自身を知らないことにはな。



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
        selected_value = dd_type.value;
        
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
        GameObject.Find("MapManager").GetComponent<Map_Data>().Create_new_org(Self_af.Air_fleet_id, Self_af.Air_fleet_battle_order_rank, Self_af.Air_fleet_battle_order_rank  + 1);

    }


}
