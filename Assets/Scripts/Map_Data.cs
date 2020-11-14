using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //位置情報
    private float posi_x;
    private float posi_y;
    //private string name_on_map;

    


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
        , int supply, int fuel
        , float x ,float y)
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

        posi_x = x;
        posi_y = y;

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
    public float Posi_x { get => posi_x; set => posi_x = value; }
    public float Posi_y { get => posi_y; set => posi_y = value; }
    

    public void Add_test()
    {
        provincial_stock_metal += 20;
    }

}

//プロヴィンスのUI。
public class UI_Province
    {
    private int provincial_id;
    private float posi_x;
    private float posi_y;
    private string name_on_map;

    public int Provincial_id { get => provincial_id; set => provincial_id = value; }
    public float Posi_x { get => posi_x; set => posi_x = value; }
    public float Posi_y { get => posi_y; set => posi_y = value; }
    public string Name_on_map { get => name_on_map; set => name_on_map = value; }

    public UI_Province(int id ,float x,float y , string name)
    {
        provincial_id = id;
        posi_x = x;
        posi_y = y;
        name_on_map = name;
    }

}


public class Map_Data : MonoBehaviour
{
    //
    [SerializeField]
    GameObject panel_provi;

    [SerializeField]
    GameObject Map;


    //プロヴィンスの入ったリスト。　TODO　DBとやり取りするようにする。
    private List<Province> list_province = new List<Province>();

    // Start is called before the first frame update
    void Start()
    {
        Deploy();
   
        
    }

    public void Deploy()
    {
        Province p1 = new Province(1, "シンガポール", "イングランド王国", "南方軍", 10, 8, 10, 4, 40, 50,-505,20);
        CreateButton(p1);

        Province p2 = new Province(2, "ブルネイ", "イングランド王国", "南方軍", 6, 3, 5, 33, 600, 330,-205,77);
        CreateButton(p2);

        Province p3 = new Province(3, "パレンバン", "イングランド王国", "南方軍", 6, 3, 5, 33, 600, 330,-484,-135);
        CreateButton(p3);

        Province p4 = new Province(4, "バタビア", "イングランド王国", "南方軍", 6, 3, 5, 33, 600, 330,-391,-298);
        CreateButton(p4);

        Province p5 = new Province(5, "ダバオ", "イングランド王国", "南方軍", 6, 3, 5, 33, 600, 330,377,287);
        CreateButton(p5);
        //Province p6 = new Province(6, "6", "イングランド王国", "南方軍", 6, 3, 5, 33, 600, 330);
        //Province p7 = new Province(7, "7", "イングランド王国", "南方軍", 6, 3, 5, 33, 600, 330);
        //Province p8 = new Province(8, "8", "イングランド王国", "南方軍", 6, 3, 5, 33, 600, 330);
        //Province p9 = new Province(9, "9", "イングランド王国", "南方軍", 6, 3, 5, 33, 600, 330);
        //Province p10 = new Province(10, "10", "イングランド王国", "南方軍", 6, 3, 5, 33, 600, 330);

        list_province.Add(p1);
        list_province.Add(p2);
        list_province.Add(p3);
        list_province.Add(p4);
        list_province.Add(p5);
    }

    public void Create_Province()
    {
        //クラスの作成

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
    

    //ボタンの作成
    public void CreateButton(Province provi)
    {
        //ボタンのプレファブを作成
        GameObject provi_button = (GameObject)Resources.Load("Prefabs/Map_Button");

        //インスタンス化
        GameObject puro_button = Instantiate(provi_button, Map.transform);

        //オブジェクト名を変更
        puro_button.name = "province_" + provi.Provincial_name ;

        //ボタン配下にあるテキストを更新。
        puro_button.GetComponent<Change_button_name>().Update_Button_Name(provi.Provincial_name);

        //座標を指定する。これは引数から取るようにする。
        //アクセサー取得。
        //ローカル座標で指定。todo//もうちょっと一般的な書きぶりを考えること。
        Vector3 posi = puro_button.transform.localPosition;

        //座標を指定。
        posi.x = provi.Posi_x;
        posi.y = provi.Posi_y;
        posi.z = 0; //guiなのでz面はゼロ。
        //
        puro_button.transform.localPosition = posi;

        //ボタンから呼び出す関数を設定。
        Button button = puro_button.GetComponent<Button>();
        //ブタンが持つ関数を取得。引数に注意。
        button.onClick.AddListener(() => Pick_Province(provi.Provincial_id));

    }



}
