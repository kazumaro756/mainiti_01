using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle_manager : MonoBehaviour
{
    //このクラスでは戦闘を実施する。
    //todo 一旦、個別のユニット単位のみ扱うので、分隊ごとの処理とかはあとでやる。
    //このクラスで処理を描写し、その描画はVEIE側に任せる。



    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("OrgManager").GetComponent<Org_manager>();
    }



    public void test_attack()
    {
        StopAllCoroutines();

        StartCoroutine("Corutin_battle_system");

        Debug.Log("攻撃終了");
    }

    //コルーチンでウェイトを入れながら処理をかける。
    IEnumerator Corutin_battle_system()
    {
        //最終的な処理結果を表示するためのものだよ。
        int num_sanka = 0;
        int num_can_Attack = 0;
        int num_sucees_attack = 0;



        Debug.Log("処理開始");
        yield return new WaitForSeconds(0);
        //リストから使える機体だけを使う。
        List<Aircraft> list_can_use = GameObject.Find("OrgManager").GetComponent<Org_manager>().List_friend_aircraft.FindAll(x => x.Flg_disabled != true);

        if (list_can_use.Count > 0)
        {
            //処理ループ開始。
            foreach (Aircraft aircraft in list_can_use)
            {
                //0参加人数を増やす。
                num_sanka += 1;

                //1まず登場人物を確定させる。そして表示する。
                yield return new WaitForSeconds(0.1f);

                //2 攻撃対象を選定。
                Ship tgt_ship = select_target();

                UpdateBattleUI(aircraft, tgt_ship);
                OFF_damageUI();

                //3 対空砲火判定。敵艦隊が艦隊防空をかける。
                foreach (Ship ship in GameObject.Find("OrgManager").GetComponent<Org_manager>().List_enemy_ships)
                {
                    //弾幕対空攻撃を実施。
                    ship.Danamaku(aircraft);

                    //対空攻撃されて滅んだら処理終了。
                    if (aircraft.Current_durability <= 0)
                    {
                        aircraft.Pilot_exp += 10;

                        //Debug.Log("しにました～～");
                        //Destroy(aircraft);
                        //機体の利用不可フラグ。
                        aircraft.Flg_disabled = true;
                        ON_damageUI();
                        break;
                    }

                }

                yield return new WaitForSeconds(0);

                if (aircraft.Flg_disabled != true)
                {
                    //攻撃を実施。
                    num_can_Attack += 1;

                    //4 攻撃実施。
                    if (aircraft.Attack_troped(tgt_ship))
                    {
                        num_sucees_attack += 1;
                        
                        //攻撃ができさえしたら＋３０。
                        aircraft.Pilot_exp += 60;
                    }
                    else
                    {
                        //攻撃はうまくいかなかったけど攻撃はした。
                        aircraft.Pilot_exp += 25;

                    }

                }
                
                //5処理終了。
                UpdateBattleUI(aircraft, tgt_ship);
                
            }
        }
        else
        {
            Debug.Log("もう航空機がいないです。");
            Logging("もう航空機がいないです。");

        }


        Debug.Log(num_sanka + "参加航空兵力" );
        Debug.Log(num_can_Attack + "攻撃態勢に入った人");
        Debug.Log(num_sucees_attack + "攻撃成功");
    }


    //攻撃対象選定。対象船舶が帰ってくる。もうちょっとまともなアルゴリズムをあとで書く。
    public Ship select_target()
    {

        return GameObject.Find("OrgManager").GetComponent<Org_manager>().List_enemy_ships[0];
    }


    //表示切り替え。
    public void UpdateBattleUI(Aircraft aircraft, Ship ship)
    {
        GameObject panel = GameObject.Find("Panel_battle");
        panel.GetComponent<View_Battle>().updateUI(aircraft, ship);

    }

    //表示切り替え。
    public void ON_damageUI()
    {
        GameObject panel = GameObject.Find("Panel_battle");
        panel.GetComponent<View_Battle>().upadate_damage_ui_enable();

    }

    //表示切り替え。
    public void OFF_damageUI()
    {
        GameObject panel = GameObject.Find("Panel_battle");
        panel.GetComponent<View_Battle>().upadate_damage_ui_disable();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //ロギング系の関数。
    public void Logging(string out_put)
    {
        // CubeプレハブをGameObject型で取得
        GameObject log_unit = (GameObject)Resources.Load("Prefabs/Panel");

        GameObject test1 = Instantiate(log_unit, GameObject.Find("Content_log").transform);

        test1.GetComponent<test_base>().textupdate(out_put);

    }

}
