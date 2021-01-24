using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_log
{
    public int log_id;
    public int attack_ship_id;
    public int attacked_ship_id;
    public bool hit_flg;
    public bool sunk_flg;
    public int weapon_type_id;

    public Attack_log(int log_id, int attack_ship_id, int attacked_ship_id, bool hit_flg, bool sunk_flg, int weapon_type_id)
    {
        this.log_id = log_id;
        this.attack_ship_id = attack_ship_id;
        this.attacked_ship_id = attacked_ship_id;
        this.hit_flg = hit_flg;
        this.sunk_flg = sunk_flg;
        this.weapon_type_id = weapon_type_id;
    }
}

public class Ship_test
{
    //メンバー変数
    public int ship_id;
    public string ship_name;
    public string ship_class;
    public bool enemy_flg;
    public int hp;
    public int atk_point;
    public int agility;

    public Ship_test(int ship_id, string ship_name, string ship_class, bool enemy_flg, int hp, int atk_point, int agility)
    {
        this.ship_id = ship_id;
        this.ship_name = ship_name;
        this.ship_class = ship_class;
        this.enemy_flg = enemy_flg;
        this.hp = hp;
        this.atk_point = atk_point;
        this.agility = agility;
    }
    //

    //攻撃。
    public Attack_log Attack(Ship_test enemy_ship)
    {
        bool flg_hit;
        bool flg_sunk;

        //攻撃処理。俊敏性が一定より高いと入らなくなる。
        if (Random.Range(1f,100f) > enemy_ship.agility)
        {
            flg_hit = true;

            enemy_ship.hp -= this.atk_point;

            //爆発処理を呼びたい。

            //デバッグログ
            //Debug.Log(this.ship_name + "の攻撃処理開始");
            //Debug.Log(enemy_ship.ship_name + "が対象");
            //Debug.Log(enemy_ship.hp + ":攻撃後の敵HP");

            //攻撃で撃沈されてたら表示切り替え。
            if(enemy_ship.hp <= 0)
            {
                flg_sunk = true;
            }
            else
            {
                flg_sunk = false;
            }


        }
        else
        {
            flg_hit = false;
            flg_sunk = false;
            //Debug.Log(this.ship_name + "は攻撃失敗した。");
        }

        Attack_log al = new  Attack_log(1,this.ship_id,enemy_ship.ship_id,flg_hit,flg_sunk,1);

        return al;


    }

    //索敵
    public Ship_test Search(List<Ship_test> list_ships)
    {
        //自分と異なる部隊を選択。
        //ここの条件は適用されないかもしれん。
        List<Ship_test> result_rist = list_ships.FindAll(a => a.enemy_flg != this.enemy_flg);

        //対象を一つに対象。。
        Ship_test hoge = result_rist[Random.Range(0, result_rist.Count)];

        
        return hoge;

        //ランダムなレンジから取得する。

    }


}


public class BattleManager : MonoBehaviour
{
    public List<Ship_test> ship_list = new List<Ship_test>();

    public List<GameObject> ship_obj_list = new List<GameObject>();

    public List<Attack_log> atk_log_list = new List<Attack_log>();


    [SerializeField]
    GameObject logging_area;

    //戦闘を設計する。
    // Start is called before the first frame update
    void Start()
    {
        //艦隊の初期配置を設定。
        Ship_test fune1 = new Ship_test(0,"DD 吹雪","DD1",false,300,10,20);
        Ship_test fune2 = new Ship_test(1, "DD 初雪", "DD1", false, 300, 10, 20);
        Ship_test fune3 = new Ship_test(2, "DD 深雪", "DD1", false, 300, 10, 20);
        Ship_test fune4 = new Ship_test(3, "DD 睦月", "DD1", false, 300, 10, 30);
        Ship_test fune5 = new Ship_test(4, "DD 長良", "DD1", false, 300, 10, 20);


        Ship_test e_fune1 = new Ship_test(5, "AK A式輸送艦_1", "AK1", true, 300, 2, 10);
        Ship_test e_fune2 = new Ship_test(6, "AK A式輸送艦_2", "AK1",true, 300, 2, 10);
        Ship_test e_fune3 = new Ship_test(7, "AK A式輸送艦_3", "AK1",true, 300, 2, 10);


        ship_list.Add(fune1);
        ship_list.Add(fune2);
        ship_list.Add(fune3);
        ship_list.Add(fune4);
        ship_list.Add(fune5);

        ship_list.Add(e_fune1);
        ship_list.Add(e_fune2);
        ship_list.Add(e_fune3);


        //ここから実際の処理パート。
        //配置
        DeployFleet();

        //戦闘処理。
        ProcessBattle();

        //処理結果を映像として動く。
        StartCoroutine(PlayBattle(atk_log_list));
        

    }

    //戦闘処理。
    public void ProcessBattle()
    {


        //早い順
        ship_list.Sort((a, b) => b.agility - a.agility);

        Debug.Log(ship_list.Count  + "全量");

        //処理を順番に実施。
        foreach (Ship_test st in ship_list)
        {
            //Debug.Log("これから処理が始まるのは" + st.ship_name);

            //索敵および攻撃を実施し、それの結果帰ってくるログをリストに配置する。

            
            atk_log_list.Add(st.Attack(st.Search(ship_list)));
            
        }

    }



    //戦闘ログを使って、戦闘の描写をやる。
    IEnumerator PlayBattle(List<Attack_log> list_logs)
    {
        Debug.Log(list_logs.Count + "ログの全量");

        foreach (Attack_log log in list_logs)
        {
            //Debug.Log(ship_list[log.attack_ship_id].ship_name + "day");
            //Debug.Log(log.attack_ship_id + "ログないの攻撃湿布ID");

            //攻撃側の攻撃描写&ログ
            yield return new WaitForSeconds(2);
            LoggingSystem(ship_list.Find(item => item.ship_id == log.attack_ship_id).ship_name + "は1000ヤード距離にて砲撃を開始");

            //UI系処理
            ship_obj_list.Find(m => m.name == log.attack_ship_id.ToString()).GetComponent<Ship_Ui_Controller>().ONAttacking("攻撃中");
            ship_obj_list.Find(m => m.name == log.attacked_ship_id.ToString()).GetComponent<Ship_Ui_Controller>().ONAttacking("対象");
            yield return new WaitForSeconds(2);

            //hitしていたら被弾描写ログ。
            if (log.hit_flg)
            {

                yield return new WaitForSeconds(2);
                //ロギング
                LoggingSystem(ship_list.Find(item => item.ship_id == log.attacked_ship_id).ship_name + "に命中！");
                //爆発をやる。

                //ship_list[log.attacked_ship_id]
                //ここで攻撃された人を指定して爆発させる。
                ship_obj_list.Find(m => m.name == log.attacked_ship_id.ToString()).GetComponent<Ship_Ui_Controller>().Explode();
                yield return new WaitForSeconds(2);

            }

            //轟沈していたら轟沈描写&ログ。
            if (log.sunk_flg)
            {
                yield return new WaitForSeconds(2);

                LoggingSystem(ship_list[log.attacked_ship_id].ship_name + "は轟沈中……");

                yield return new WaitForSeconds(2);
            }

            //攻撃終了。
            ship_obj_list.Find(m => m.name == log.attack_ship_id.ToString()).GetComponent<Ship_Ui_Controller>().Finish_attacking();
            ship_obj_list.Find(m => m.name == log.attacked_ship_id.ToString()).GetComponent<Ship_Ui_Controller>().Finish_attacking();
        }

    }


    //ログテキストの作成
    public void LoggingSystem(string log_text)
    {
        GameObject log = (GameObject)Resources.Load("Prefabs/Panel_logging");

        GameObject log_obj = Instantiate(log, logging_area.transform);

        log_obj.GetComponent<UI_logging_text_controller>().Updatetext(log_text);

    }


    //艦隊配置処理。
    public void DeployFleet()
    {
        //友軍の表示。
        //友軍の湿布リストを取得
        List<Ship_test> result_rist_friend = ship_list.FindAll(a => a.enemy_flg != true);
        int i1 = 0;
        //配置場所
        List<Vector3> list_friend =  GetFriendDeployPoints();

        foreach (Ship_test ship in result_rist_friend)
        {
            DeployShip(ship, list_friend[i1]);
            i1++;
        }


        List<Ship_test> result_rist_enemy = ship_list.FindAll(a => a.enemy_flg == true);
        int i2 = 0;
        //配置場所
        List<Vector3> list_enemy = GetEnemyDeployPoints();

        foreach (Ship_test ship in result_rist_enemy)
        {
            DeployShip(ship, list_enemy[i2]);
            i2++;
        }





    }

    //艦船の配置。
    public void DeployShip(Ship_test ship,Vector3 point)
    {
        //クラスが持っている艦級を取得。
        GameObject ship_model = (GameObject)Resources.Load("3d/Ship_model/" + ship.ship_class );

        //スケール調整。今回は半分にする。最終的にはモデルを調整
        ship_model.transform.localScale  = new Vector3(0.5f, 0.5f, 0.5f);

        //中のメッシュモデルだけ変えてみる。
        //ship_model.GetComponentInChildren<MeshFilter>().mesh =

        //Assets/Resources/Models/AK_1.obj

        GameObject ship_object = Instantiate(ship_model,point, Quaternion.identity);

        //インスタンス化したうえで、艦名を指定する。
        ship_object.name = ship.ship_id.ToString();

        //艦名を表示
        ship_object.GetComponent<Ship_Ui_Controller>().UPdateUI(ship);

        //列に加え入れる.
        ship_obj_list.Add(ship_object);

    }


    /// <summary>
    /// リストとして座標を取得。
    /// </summary>
    /// <returns></returns>
    public List<Vector3> GetEnemyDeployPoints()
    {
        //CSVとかから読み込むようにしたいけどとりあえず。

        //格納用リスト作成
        List<Vector3> list_friend_points = new List<Vector3>();
        //友軍ポイント
        Vector3 friend_point_1 = new Vector3(200f, 1f, 0f);

        Vector3 friend_point_2 = new Vector3(200f, 1f, 50f);

        Vector3 friend_point_3 = new Vector3(200f, 1f, -50f);

        Vector3 friend_point_4 = new Vector3(200f, 1f, 100f);

        Vector3 friend_point_5 = new Vector3(200f, 1f, -100f);

        Vector3 friend_point_6 = new Vector3(200f, 1f, 150f);

        Vector3 friend_point_7 = new Vector3(200f, 1f, -150f);


        list_friend_points.Add(friend_point_1);
        list_friend_points.Add(friend_point_2);
        list_friend_points.Add(friend_point_3);
        list_friend_points.Add(friend_point_4);
        list_friend_points.Add(friend_point_5);
        list_friend_points.Add(friend_point_6);
        list_friend_points.Add(friend_point_7);

        return list_friend_points;


    }


    public List<Vector3> GetFriendDeployPoints()
    {
        //CSVとかから読み込むようにしたいけどとりあえず。

        //格納用リスト作成
        List<Vector3> list_friend_points = new List<Vector3>();
        //友軍ポイント
        Vector3 friend_point_1 = new Vector3(-200f, 1f, 0f);

        Vector3 friend_point_2 = new Vector3(-200f, 1f, 50f);

        Vector3 friend_point_3 = new Vector3(-200f, 1f, -50f);

        Vector3 friend_point_4 = new Vector3(-200f, 1f, 100f);

        Vector3 friend_point_5 = new Vector3(-200f, 1f, -100f);

        Vector3 friend_point_6 = new Vector3(-200f, 1f, 150f);

        Vector3 friend_point_7 = new Vector3(-200f, 1f, -150f);


        list_friend_points.Add(friend_point_1);
        list_friend_points.Add(friend_point_2);
        list_friend_points.Add(friend_point_3);
        list_friend_points.Add(friend_point_4);
        list_friend_points.Add(friend_point_5);
        list_friend_points.Add(friend_point_6);
        list_friend_points.Add(friend_point_7);

        return list_friend_points;


    }


    
}
