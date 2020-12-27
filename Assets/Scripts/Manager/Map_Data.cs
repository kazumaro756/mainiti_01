using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//enumタイプ
public enum unit_type
{
    //
    歩兵
    ,砲兵
    ,騎兵
    ,機甲

}

public enum unit_rank:int
{
    //
    総軍 =1
    ,方面軍
    ,軍
    ,師団
    ,旅団
    ,連隊
    ,大隊
    ,中隊
    ,小隊
    ,分隊
}

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
    private int air_fleet_battle_order_rank;

    public Air_Fleet(string name, int air_fleet_id, int attached_base, int aircraft_number, int task_id, int pilot_number, string leader_name, int fatigue, string unit_type, int air_fleet_battle_order_rank)
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
        this.air_fleet_battle_order_rank = air_fleet_battle_order_rank;

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
    public int Air_fleet_battle_order_rank { get => air_fleet_battle_order_rank; set => air_fleet_battle_order_rank = value; }

    //基地の変更。
    public void Change_Base(int base_id)
    {
        attached_base = base_id;

    }

    //階層の変更。あげたり下げたり。
    public void Change_Battle_Order_Rank(int new_rank )
    {
        Air_fleet_battle_order_rank = new_rank;
    }





}

//パイロット
public class Pilot
{
    private int pilot_id;
    private string pilot_name;
    private string pilot_rank;
    private int using_aircraft_id;
    private int attached_airfleet_id;
    private bool airfleet_leader_flag;

    //leader_ship
    private int pilot_exp_leadership;
    private int pilot_skill_leadership;

    //private pilot skill
    private int pilot_exp_air_battle;
    private int pilot_exp_land_bombing;
    private int pilot_exp_naval_unit_bombing;
    private int pilot_exp_troped;
    private int pilot_exp_recon;


    //これらのスキルは最終効果で期待側に乗せる。
    private int pilot_skill_air_battle;
    private int pilot_skill_bombing_land;
    private int pilot_skill_bombing_naval_unit;
    private int pilot_skill_troped;
    private int pilot_skill_recon;

    //コンストラクタ。
    public Pilot(int pilot_id, string pilot_name, string pilot_rank, int using_aircraft_id, int attached_airfleet_id, bool airfleet_leader_flag, int pilot_exp_leadership, int pilot_skill_leadership, int pilot_exp_air_battle, int pilot_exp_land_bombing, int pilot_exp_naval_unit_bombing, int pilot_exp_troped, int pilot_exp_recon, int pilot_skill_air_battle, int pilot_skill_bombing_land, int pilot_skill_bombing_naval_unit, int pilot_skill_troped, int pilot_skill_recon)
    {
        this.pilot_id = pilot_id;
        this.pilot_name = pilot_name;
        this.pilot_rank = pilot_rank;
        this.using_aircraft_id = using_aircraft_id;
        this.attached_airfleet_id = attached_airfleet_id;
        this.airfleet_leader_flag = airfleet_leader_flag;
        this.pilot_exp_leadership = pilot_exp_leadership;
        this.pilot_skill_leadership = pilot_skill_leadership;
        this.pilot_exp_air_battle = pilot_exp_air_battle;
        this.pilot_exp_land_bombing = pilot_exp_land_bombing;
        this.pilot_exp_naval_unit_bombing = pilot_exp_naval_unit_bombing;
        this.pilot_exp_troped = pilot_exp_troped;
        this.pilot_exp_recon = pilot_exp_recon;
        this.pilot_skill_air_battle = pilot_skill_air_battle;
        this.pilot_skill_bombing_land = pilot_skill_bombing_land;
        this.pilot_skill_bombing_naval_unit = pilot_skill_bombing_naval_unit;
        this.pilot_skill_troped = pilot_skill_troped;
        this.pilot_skill_recon = pilot_skill_recon;
    }
}

//機体
public class Aircraft_unit
{
    private int aircraft_id;
    private string aircraft_type;
    private int aircraft_class_id;
    private string aircraft_class_name;
    private int pilot_id;

    //最終的にはこういう実装にするんだろうけど今はそのときではない。
    //列複数もたせるしかねーんじゃねーかなというきもする。
    //private List<Weapon> list_weapons;
}


public class Test_pilot {
    private int pilot_id;
    private string pilot_name;

    public Test_pilot(int pilot_id, string pilot_name)
    {
        this.pilot_id = pilot_id;
        this.pilot_name = pilot_name;
    }
}

public class Test_unit
{
    private int unit_id;
    private string unit_name;

    public Test_unit(int unit_id, string unit_name)
    {
        this.unit_id = unit_id;
        this.unit_name = unit_name;
    }
}

//パイロットと機体のトランザクション
public class HR_transaction {
    private int HR_id;
    private int pilot_id;
    private int unit_id;
    private string status;

    public HR_transaction(int hR_id, int pilot_id, int unit_id, string status)
    {
        HR_id = hR_id;
        this.pilot_id = pilot_id;
        this.unit_id = unit_id;
        this.status = status;
    }
}


public class Infantry{
    private int id;
    private string name;
    private string kaikyuu;
    private int hp;
    private int power; //ここはあとで武装する感じに変える。
    private int faction_id;

    public Infantry(int id, string name, string kaikyuu, int hp, int power, int faction_id)
    {
        this.id = id;
        this.name = name;
        this.kaikyuu = kaikyuu;
        this.hp = hp;
        this.power = power;
        this.faction_id = faction_id;
    }
}

//武装
public class Weapon 
{
    //これが武装に関するものですね。
    //各種メンバ変数
    private int weapon_id;
    private string weapon_name;
    private string weapon_type;

    private int weapon_attack;
    private int weapon_attack_speed;
    private int weapon_penitration_armar;
    private int weapon_penitration_shield;

    //ここにサポート系も追加する。

    //コンストラクタ
    public Weapon(int w_id ,string w_name, string w_type, int w_attack, int w_attack_s, int w_peni_arm, int w_peni_shi)
    {
        weapon_id = w_id;

        weapon_name = w_name;
        weapon_type = w_type;

        weapon_attack = w_attack;
        weapon_attack_speed = w_attack_s;
        weapon_penitration_armar = w_peni_arm;
        weapon_penitration_shield = w_peni_shi;

    }




    //武器の使用。
    public void Using_arm<Type>(Type tgt)
    {


    }

}

//部隊の戦闘序列に関するデータ
public class Battle_order
{
    private int bo_id;
    private int parent_org_id;
    //private string parent_org_name;
    private int child_org_id;

    public Battle_order(int bo_id, int parent_org_id, int child_org_id)
    {
        this.bo_id = bo_id;
        this.parent_org_id = parent_org_id;
        this.child_org_id = child_org_id;
    }

    public int Bo_id { get => bo_id; set => bo_id = value; }
    public int Parent_org_id { get => parent_org_id; set => parent_org_id = value; }
    public int Child_org_id { get => child_org_id; set => child_org_id = value; }
    //private string child_org_name;


    //private bool spream_parent_code;


}



// TODO これが神クラスになりかけてるのであとで分割する。開発段階は許せ。
public class Map_Data : MonoBehaviour
{
    //  、ｍん。
    [SerializeField]
    GameObject panel_provi;

    [SerializeField]
    GameObject Map;

    [SerializeField]
    GameObject panel_air_fleets;

    [SerializeField]
    GameObject panel_battle_order;


    //プロヴィンスの入ったリスト。　TODO　DBとやり取りするようにする。
    private List<Province> list_province = new List<Province>();

    //航空艦隊が入ってるリスト
    private List<Air_Fleet> list_air_fleet = new List<Air_Fleet>();


    //人事上のやり取りが入っている。これは最後にはDBになるけどね.
    private List<HR_transaction> list_hr_transaction = new List<HR_transaction>();


    //戦闘序列の記録
    private List<Battle_order> list_battle_ordre = new List<Battle_order>();

    public List<Battle_order> List_battle_ordre { get => list_battle_ordre; set => list_battle_ordre = value; }
    public List<Air_Fleet> List_air_fleet { get => list_air_fleet; set => list_air_fleet = value; }
    public List<Infantry> List_infantry_butai { get => list_infantry_butai; set => list_infantry_butai = value; }
    public List<Infantry> List_infantry_enemy { get => list_infantry_enemy; set => list_infantry_enemy = value; }


    //歩兵部隊。
    private List<Infantry> list_infantry_butai = new List<Infantry>();
    private List<Infantry> list_infantry_enemy = new List<Infantry>();


    //部隊数
    private int org_num;


    //bo
    private int org_bo;

    //
    private void Awake()
    {
        Deploy();
    }

    // Start is called before the first frame update
    void Start()
    {
        org_num = 13;

        org_bo = 11;

    }

    //テスト用のコンストラクタを飛ばすやつ。
    public void Test_Deploy() {
        Test_pilot tp1 = new Test_pilot(1, "ゴンゾウ");
        Test_pilot tp2 = new Test_pilot(2, "珍太郎");

        Test_unit tu1 = new Test_unit(1, "A6M2");
        Test_unit tu2 = new Test_unit(2, "Ki44");
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

        Air_Fleet af1 = new Air_Fleet("北部総軍", 1, 1, 40,1,20,"権堂狂死郎",30,"A6M2",1);
        Air_Fleet af2 = new Air_Fleet("第1方面軍", 2, 1, 40,1,20, "徳川家定", 30, "A6M2",2);
        Air_Fleet af3 = new Air_Fleet("第2方面軍", 3, 2, 40, 1, 20, "ジョン・万次郎", 30, "A7M2",2);
        Air_Fleet af4 = new Air_Fleet("第3方面軍", 4, 3, 40, 1, 20, "コアリション", 30, "D2Y1",2);
        Air_Fleet af5 = new Air_Fleet("第1軍", 5, 3, 40, 1, 20, "コアリション", 30, "D2Y1", 3);
        Air_Fleet af6 = new Air_Fleet("第1師団", 6, 3, 40, 1, 20, "コアリション", 30, "D2Y1", 4);
        Air_Fleet af7 = new Air_Fleet("第22旅団", 7, 3, 40, 1, 20, "コアリション", 30, "D2Y1", 5);
        Air_Fleet af8 = new Air_Fleet("第1連隊", 8, 3, 40, 1, 20, "コアリション", 30, "D2Y1", 6);
        Air_Fleet af9 = new Air_Fleet("第1大隊", 9, 3, 40, 1, 20, "コアリション", 30, "D2Y1", 7);
        Air_Fleet af10 = new Air_Fleet("第1中隊", 10, 3, 40, 1, 20, "コアリション", 30, "D2Y1", 8);
        Air_Fleet af11 = new Air_Fleet("第1小隊", 11, 3, 40, 1, 20, "コアリション", 30, "D2Y1", 9);
        Air_Fleet af12 = new Air_Fleet("第1分隊", 12, 3, 40, 1, 20, "コアリション", 30, "D2Y1", 10);



        //Air_Fleet af7 = new Air_Fleet("第7航空艦隊", 6, 3, 40, 1, 20, "コアリション", 30, "D2Y1", 3);


        list_air_fleet.Add(af1);
        list_air_fleet.Add(af2);
        list_air_fleet.Add(af3);
        list_air_fleet.Add(af4);
        list_air_fleet.Add(af5);
        list_air_fleet.Add(af6);
        list_air_fleet.Add(af7);
        list_air_fleet.Add(af8);
        list_air_fleet.Add(af9);
        list_air_fleet.Add(af10);
        list_air_fleet.Add(af11);
        list_air_fleet.Add(af12);


        //戦闘序列
        Battle_order bo1 = new Battle_order(1, 1, 2);
        Battle_order bo2 = new Battle_order(2, 1, 3);
        Battle_order bo3 = new Battle_order(3, 1, 4);
        Battle_order bo4 = new Battle_order(4, 2, 5);
        Battle_order bo5 = new Battle_order(5, 5, 6);
        Battle_order bo6 = new Battle_order(6, 6, 7);
        Battle_order bo7 = new Battle_order(7, 7, 8);
        Battle_order bo8 = new Battle_order(8, 8, 9);
        Battle_order bo9 = new Battle_order(9, 9, 10);
        Battle_order bo10 = new Battle_order(9,10, 11);
        Battle_order bo11 = new Battle_order(9,11, 12);


        list_battle_ordre.Add(bo1);
        list_battle_ordre.Add(bo2);
        list_battle_ordre.Add(bo3);
        list_battle_ordre.Add(bo4);
        list_battle_ordre.Add(bo5);
        list_battle_ordre.Add(bo6);
        list_battle_ordre.Add(bo7);
        list_battle_ordre.Add(bo8);
        list_battle_ordre.Add(bo9);
        list_battle_ordre.Add(bo10);
        list_battle_ordre.Add(bo11);

        //
        Create_battle_order(af1);



        //歩兵味方
        Infantry if1 = new Infantry(1, "近藤十次郎","二等兵",100,2,1);
        Infantry if2 = new Infantry(2, "かまど炭治郎", "二等兵", 100, 2, 1);
        Infantry if3 = new Infantry(3, "冨岡義勇", "二等兵", 100, 2, 1);
        Infantry if4 = new Infantry(4, "かまど裕次郎", "二等兵", 100, 2, 1);
        Infantry if5 = new Infantry(5, "ダライ・ラマ", "二等兵", 100, 2, 1);

        //歩兵敵
        Infantry if1ene = new Infantry(6, "近藤十次郎", "二等兵", 100, 2, 2);
        Infantry if2ene = new Infantry(7, "かまど炭治郎", "二等兵", 100, 2, 2);
        Infantry if3ene = new Infantry(8, "冨岡義勇", "二等兵", 100, 2, 2);

        //歩兵関連。
        list_infantry_butai.Add(if1);
        list_infantry_butai.Add(if2);
        list_infantry_butai.Add(if3);
        list_infantry_butai.Add(if4);
        list_infantry_butai.Add(if5);

        list_infantry_enemy.Add(if1ene);
        list_infantry_enemy.Add(if2ene);
        list_infantry_enemy.Add(if3ene);



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

        //これでもって自分のプロヴィIDを与えちゃう。
        province_view.GetComponent<View_Province>().Provi_id = id;


    }

    public void pick_air_fleet_manage(int id)
    {
        //panelを表示。
        panel_air_fleets.SetActive(true);

        //idを受け取って本当に必要なリストを取得。
        List<Air_Fleet> list_af = list_air_fleet.FindAll(x => x.Attached_base == id);

        //リストから艦隊情報を与える。。
        panel_air_fleets.GetComponent<View_Airfleets>().Update_Unit_Rerated_UI(list_af);

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


    //戦闘序列 ただしこの関数は最上位だけを吐かせる。
    public void Create_battle_order( Air_Fleet af)
    {
        //戦闘序列を作成。ここで配置するのは、あくまで最上位の部隊。
        GameObject bato = (GameObject)Resources.Load("Prefabs/Panel_1");

        //インスタンス化。一覧のところに生成する。
        GameObject ins_bato = Instantiate(bato, panel_battle_order.transform);

        //オブジェクト名を変更
        ins_bato.name = "battle_order" + af.Air_fleet_id;

        //UI更新
        ins_bato.GetComponent<Battle_order_view>().update_all_ui(af,0);

        //戦闘序列側が持っている処理を追加する。
        //こっちは親の組織IDをもたせる。
        ins_bato.GetComponent<Battle_Order>().Self_id = af.Air_fleet_id;

        //ここどういう設計にするかあとで考える。
        ins_bato.GetComponent<Battle_Order>().Rank= af.Air_fleet_battle_order_rank;

        //最上級部隊なので、親に対して明示的にnullを入れる。
        ins_bato.GetComponent<Battle_Order>().Paret_object = null;

    }

    //新組織の作成。
    public void Create_new_org(int parent_id,int rank_parent , int rank_child)
    {
        org_num += 1;
        org_bo += 1;

        Air_Fleet afx = new Air_Fleet("第一歩兵連隊", org_num, 3, 40, 1, 20, "コアリション", 30, "D2Y1", rank_child);  
        
        list_air_fleet.Add(afx);

        //序列に対して追加 // BO自体のID、親のID、子のID
        Battle_order box = new Battle_order(org_bo,parent_id , org_num);

        list_battle_ordre.Add(box);
    }



    public void Create_Supreme_org()
    {
        org_num += 1;
        Air_Fleet af_xxx = new Air_Fleet("第一歩兵連隊", org_num, 3, 40, 1, 20, "コアリション", 30, "D2Y1", 4);
        list_air_fleet.Add(af_xxx);

        Create_battle_order(af_xxx);

    }

}
