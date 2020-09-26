using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Org_manager : MonoBehaviour
{

    //機体数
    private int Num_Tensan_Stock;


    private int pilot_id = 0;

    private List<Aircraft> list_friend_aircraft = new List<Aircraft>();
    private List<Ship> list_enemy_ships = new List<Ship>();

    public List<Aircraft> List_friend_aircraft { get => list_friend_aircraft; set => list_friend_aircraft = value; }
    public List<Ship> List_enemy_ships { get => list_enemy_ships; set => list_enemy_ships = value; }
    public int Num_Tensan_Stock1 { get => Num_Tensan_Stock; set => Num_Tensan_Stock = value; }

    private void Awake()
    {

        

        Deploy();
    }

    // Start is called before the first frame update
    void Start()
    {
        Num_Tensan_Stock = 100 ;

        //Debug.Log(list_friend_aircraft.Count);

    }


    //配置。これはあとで変える。
    public void Deploy()
    {
        Aircraft ac1 = new Aircraft("天山", "近藤狂四郎", 100, 100, 0, false, false);
        Aircraft ac2 = new Aircraft("天山", "磐田禅師", 100, 100, 0, false, false);
        Aircraft ac3 = new Aircraft("天山", "アナルシコ太郎", 100, 100, 0, false, false);

        list_friend_aircraft.Add(ac1);
        list_friend_aircraft.Add(ac2);
        list_friend_aircraft.Add(ac3);

        Ship ship1 = new Ship("飛龍", 20000, 20000);

        list_enemy_ships.Add(ship1);

    }

    // Update is called once per frame
    void Update()
    {

    }

    //機体を補充する。
    public void Hozyu(Aircraft ac )
    {
        //条件文
        if (Num_Tensan_Stock > 0 && ac.Flg_disabled != false)
        {
            //破損フラグ修正。
            ac.Flg_disabled = false;

            //HP回復。
            ac.Current_durability = ac.Max_Durability;

            //在庫から一つ減らす。
            Num_Tensan_Stock -= 1;

            Debug.Log(Num_Tensan_Stock);

        }

    }

    //パイロットを追加。
    public void Add_pilot()
    {
        pilot_id += 1;

        //作成。
        Aircraft ac1 = new Aircraft("天山", "パイロット" + pilot_id + "-san" , 100, 100, 0, false, false);

        //リストに追加
        list_friend_aircraft.Add(ac1);
    }




   
}
