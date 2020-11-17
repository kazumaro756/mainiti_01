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

/// 航空艦隊
public class Air_Fleet
{
    private string name;
    private int air_fleet_id;
    private int attached_base;
    private int aircraft_number;
    private int task_id;
    private int pilot_number;
    private string leader_name;
    private int fatigue;
    private string unit_type;

    public Air_Fleet(string name, int air_fleet_id, int attached_base, int aircraft_number, int task_id, int pilot_number, string leader_name, int fatigue, string unit_type)
    {
        this.name = name;
        this.air_fleet_id = air_fleet_id;
        this.attached_base = attached_base;
        this.aircraft_number = aircraft_number;
        this.task_id = task_id;
        this.pilot_number = pilot_number;
        this.leader_name = leader_name;
        this.fatigue = fatigue;
        this.unit_type = unit_type;
    }

    public string Name { get => name; set => name = value; }
    public int Attached_base { get => attached_base; set => attached_base = value; }
    public int Aircraft_number { get => aircraft_number; set => aircraft_number = value; }
    public int Air_fleet_id { get => air_fleet_id; set => air_fleet_id = value; }
    public int Task_id { get => task_id; set => task_id = value; }
    public int Pilot_number { get => pilot_number; set => pilot_number = value; }
    public string Leader_name { get => leader_name; set => leader_name = value; }
    public int Fatigue { get => fatigue; set => fatigue = value; }
    public string Unit_type { get => unit_type; set => unit_type = value; }

    //基地の変更。
    public void Change_Base(int base_id)
    {
        attached_base = base_id;

    }


}

// TODO これが神クラスになりかけてるのであとで分割する。開発段階は許せ。
public class Map_Data : MonoBehaviour
{
    //
    [SerializeField]
    GameObject panel_provi;

    [SerializeField]
    GameObject Map;


    //プロヴィンスの入ったリスト。　TODO　DBとやり取りするようにする。
    private List<Province> list_province = new List<Province>();

    //航空艦隊が入ってるリスト
    private List<Air_Fleet> list_air_fleet = new List<Air_Fleet>();

    //
    private void Awake()
    {
        Deploy();
    }

    // Start is called before the first frame update
    void Start()
    {
 
   
        
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

        Air_Fleet af1 = new Air_Fleet("第一航空艦隊", 1, 1, 40,1,20,"権堂狂死郎",30,"A6M2");
        Air_Fleet af2 = new Air_Fleet("第二航空艦隊", 2, 1, 40,1,20, "徳川家定", 30, "A6M2");


        list_air_fleet.Add(af1);
        list_air_fleet.Add(af2);


    }

    public void Create_Province()
    {
        //クラスの作成

    }

    //これの関数をもうちょっと整理したい。全部の情報を一箇所から持ってこれるか？？？
    public void Pick_Province(int id)
    {
        //ボタンを押したときの情報を取得。
        //todo。今は引数で取ってる。

        //panelを表示。
        panel_provi.SetActive(true);

        //idを受け取って、プロヴィンスを取得。
        Province a = list_province.Find(x => x.Provincial_id == id);

        //idを受け取って本当に必要なリストを取得。
        List<Air_Fleet> list_af = list_air_fleet.FindAll(x => x.Attached_base == id);

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

        //リストから艦隊情報を与える。。
        province_view.GetComponent<View_Province>().Update_Unit_Rerated_UI(list_af);


    }
    

    public void Pick_Air_Fleets(int id)
    {


    }


    //MAP上の拠点ボタンの作成
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
        //ブタンが持つ関数を取得。引数に注意。拠点IDを読みにいってる。
        button.onClick.AddListener(() => Pick_Province(provi.Provincial_id));

    }



}
