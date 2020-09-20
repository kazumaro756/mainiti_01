using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle_manager : MonoBehaviour
{
    //このクラスでは戦闘を実施する。
    //todo 一旦、個別のユニット単位のみ扱うので、分隊ごとの処理とかはあとでやる。
    //このクラスで処理を描写し、その描画はVEIE側に任せる。

    private List<Aircraft> list_friend_aircraft;
    private List<Ship> list_enemy_ships;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //戦闘処理。
    public void Battle_System()
    {
        //まず登場人物を確定させる。
        
        //処理ループ開始。
        foreach( Aircraft aircraft in list_friend_aircraft )
        {
            //1 to do 攻撃態勢に入れるか否か。
            //2 対空砲火判定
            foreach (Ship ship in list_enemy_ships)
            {
                //弾幕対空攻撃を実施。
                ship.Danamaku(aircraft);

            }
            //3 攻撃対象を選定。

            Ship tgt_ship = select_target();

            //4 攻撃実施。
            aircraft.Attack_troped(tgt_ship);

               
        }

    } 

    //攻撃対象選定。対象船舶が帰ってくる。もうちょっとまともなアルゴリズムをあとで書く。
    public Ship select_target()
    {

        return list_enemy_ships[0];
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
