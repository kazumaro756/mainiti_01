using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ただのマップクラス。
public class Province
{
    private int provincial_id;
    private string provincial_name;
    private string provincial_owner_faction;
    private string provincial_owner_unit;
    private int provincial_stock_metal;
    private int provincial_stock_supply;

    private int mil_port_size;
    private int mil_port_damage;

    private int pri_port_size;
    private int pri_port_damage;

    private int supply_count;
    private int fuel_count;


    /// <summary>
    /// プロヴィンスのコンストラクタ
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="owner"></param>
    /// <param name="metal"></param>
    /// <param name="supply"></param>
    public Province(int id, string name, string owner, string unit
        , int mil_pt_size, int mil_pt_damage, int pri_pt_size, int pri_pt_damage
        , int supply, int fuel)
    {
        Provincial_id = id;
        provincial_name = name;
        provincial_owner_faction = owner;
        provincial_owner_unit = unit;


        mil_port_size = mil_pt_size;
        mil_port_damage = mil_pt_damage;

        pri_port_size = pri_pt_size;
        pri_port_damage = pri_pt_damage;

        supply_count = supply;
        fuel_count = fuel;


    }

    public int Provincial_id { get => provincial_id; set => provincial_id = value; }
    public string Provincial_name { get => provincial_name; set => provincial_name = value; }
    public string Provincial_owner_faction { get => provincial_owner_faction; set => provincial_owner_faction = value; }
    public string Provincial_owner_unit { get => provincial_owner_unit; set => provincial_owner_unit = value; }
    public int Provincial_stock_metal { get => provincial_stock_metal; set => provincial_stock_metal = value; }
    public int Provincial_stock_supply { get => provincial_stock_supply; set => provincial_stock_supply = value; }
    public int Mil_port_size { get => mil_port_size; set => mil_port_size = value; }
    public int Mil_port_damage { get => mil_port_damage; set => mil_port_damage = value; }
    public int Pri_port_size { get => pri_port_size; set => pri_port_size = value; }
    public int Pri_port_damage { get => pri_port_damage; set => pri_port_damage = value; }
    public int Supply_count { get => supply_count; set => supply_count = value; }
    public int Fuel_count { get => fuel_count; set => fuel_count = value; }

    public void Add_test()
    {
        provincial_stock_metal += 20;
    }

}


public class Map_Data : MonoBehaviour
{
    //
    [SerializeField]
    GameObject panel_provi;


    //プロヴィンスの入ったリスト。　TODO　DBとやり取りするようにする。
    private List<Province> list_province = new List<Province>();

    // Start is called before the first frame update
    void Start()
    {
        Deploy();
    }

    public void Deploy()
    {
        Province p1 = new Province(1, "シンガポール", "イングランド王国", "南方軍", 10, 8, 10, 4, 40, 50);
        Province p2 = new Province(2, "ロンディニウム", "イングランド王国", "南方軍", 6, 3, 5, 33, 600, 330);


        list_province.Add(p1);
        list_province.Add(p2);
    }


    public void Pick_Province(int id)
    {
        //ボタンを押したときの情報を取得。
        //todo。今は引数で取ってる。

        //panelを表示。
        panel_provi.SetActive(true);

        //idを受け取って、プロヴィンスを取得。
        Province a = list_province.Find(x => x.Provincial_id == id);

        GameObject province_view = GameObject.Find("Panel_province");

        //プロヴィンスの情報を反映させる。
        province_view.GetComponent<View_Province>().UpdateAllUI(a.Provincial_name,
            a.Provincial_owner_faction,
            a.Provincial_owner_unit,
            a.Mil_port_size.ToString(), 
            a.Mil_port_damage.ToString(), 
            a.Pri_port_size.ToString(), 
            a.Pri_port_damage.ToString(),
            a.Supply_count.ToString(), 
            a.Fuel_count.ToString()
            );

    }


}
