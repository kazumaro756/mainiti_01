using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //これが武装に関するものですね。
    //各種メンバ変数
    private string weapon_name;
    private string weapon_type;

    private int weapon_attack;
    private int weapon_attack_speed;
    private int weapon_penitration_armar;
    private int weapon_penitration_shield;



    //コンストラクタ
    public Weapon(string w_name,string w_type,int w_attack,int w_attack_s,int w_peni_arm , int w_peni_shi)
    {
        weapon_name = w_name;
        weapon_type = w_type;

        weapon_attack = w_attack;
        weapon_attack_speed = w_attack_s;
        weapon_penitration_armar = w_peni_arm;
        weapon_penitration_shield = w_peni_shi;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //武器の使用。
    public void  Using_arm <Type>(Type tgt)
    {
        

    }

}
