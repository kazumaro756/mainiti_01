using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//艦級。建造された瞬間の話だ。
public class Ship_Class
{
    public int ship_class_id;
    public string ship_class_name;
    public string ship_type;
    public int max_hp;
    public int atk_point;
    public int agility;
    public int reward_money;

    public int money_to_make;

    public Ship_Class(int ship_class_id, string ship_class_name, string ship_type, int max_hp, int atk_point, int agility, int reward_money, int money_to_make)
    {
        this.ship_class_id = ship_class_id;
        this.ship_class_name = ship_class_name;
        this.ship_type = ship_type;
        this.max_hp = max_hp;
        this.atk_point = atk_point;
        this.agility = agility;
        this.reward_money = reward_money;
        this.money_to_make = money_to_make;
    }
}


//軍港
public class MilitalyPortManager : MonoBehaviour
{
    //艦級のリスト
    public List<Ship_Class> List_ship_class = new List<Ship_Class>();


    //溜まっている艦船リスト
    List<Ship_test> List_ships_in_port = new List<Ship_test>();


    //グローバルな変数。艦船の通し番号。軍港で生産されたときに知ればよいのでOK。
    static int ship_id;

    [SerializeField]
    GameObject port_ui;

    [SerializeField]
    GameObject RM;

    // Start is called before the first frame update
    void Start()
    {
        ship_id = 10;

        Ship_Class sc1 = new Ship_Class(1,"ワンダー級","DD",2000,20,30,100,300);
        Ship_Class sc2 = new Ship_Class(2,"オットー級","AK", 350, 50, 10, 600,500);

        List_ship_class.Add(sc1);
        List_ship_class.Add(sc2);


        //ポート画面を更新。
        port_ui.GetComponent<Port_Panel_ui_controller>().Deploy_Calsses(List_ship_class);
        port_ui.GetComponent<Port_Panel_ui_controller>().Deploy_ship_in_pool(List_ships_in_port);
            
        //


        //建造。してポートにつなげる。
        //AddShiptoPort(CreateShip(ship_id, "ティルピッツ", false, List_ship_class[0]));


    }

    // Update is called once per frame
    void Update()
    {
        
    }





    //個別のシップをインスタンス化する処理。実際には建造に相当する処理。
    public void CreateShip( string this_ship_name ,bool enemy_flg ,Ship_Class sc )
    {
        if (RM.GetComponent<ResourceManager>().Check_enough_money(sc.money_to_make))
        {
            //艦船を作るときにお金を減らす。
            //RM.GetComponent<ResourceManager>().money -= sc.money_to_make;
            RM.GetComponent<ResourceManager>().UseMoney(sc.money_to_make);

            //インスタンス化する処理。
            Ship_test n_ship = new Ship_test
                (ship_id,
                this_ship_name + ship_id.ToString(),
                sc.ship_class_name,
                enemy_flg,
                sc.max_hp,
                sc.max_hp,
                sc.atk_point,
                sc.agility,
                sc.reward_money,
                sc.ship_type
                );

            ship_id += 1;

            Debug.Log(ship_id + "だよ");
            Debug.Log(n_ship.ship_id + "だよ");


            //軍港に配置。
            List_ships_in_port.Add(n_ship);

            //UI更新
            PortShiplistUpdate();
        }
        else
        {
            //お金ないでつ。
            Debug.Log("お金ないです");

        }




    }

    //インスタンス化した艦船を軍港に入れる処理。
    public void AddShiptoPort(Ship_test st)
    {

        List_ships_in_port.Add(st);
        Debug.Log(List_ships_in_port.Count + "隻が軍港にあります。");
        PortShiplistUpdate();
    }


    //作成
    public void CreateAndAddport(int id)
    {
        //ここの処理はだめ。インデックスじゃなくてidを見に行く実装にしないとダメ。
        CreateShip("test", false, List_ship_class[id - 1]);

    }

    public void PortShiplistUpdate()
    {
        port_ui.GetComponent<Port_Panel_ui_controller>().Deploy_ship_in_pool(List_ships_in_port);
    }




}
