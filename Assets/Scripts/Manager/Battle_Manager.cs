using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//戦闘に関する処理。
public class Battle_Manager : MonoBehaviour
{
    ////お気持ち
    ///基本的には配置処理をする。
    ////
    List<Infantry> lf_butai = new List<Infantry>();
    List<Infantry> lf_enemy = new List<Infantry>();


    [SerializeField]
    GameObject inf_unit;

    // Start is called before the first frame update
    void Start()
    {
        //インスタンス化された部隊の取得。
        lf_butai = GameObject.Find("Map_Manager").GetComponent<Map_Data>().List_infantry_butai;
        lf_enemy = GameObject.Find("Map_Manager").GetComponent<Map_Data>().List_infantry_enemy;

        //リスト内の諸々の物理的な配置。

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    



    //リストをもらって物理的に配置する処理。
    public void Deploy(float x,float y,float z)
    {
        //これは何？
        Vector3 pos = new Vector3(x,y,z);

        //発生させる
        GameObject unit_info = Instantiate(inf_unit, pos, Quaternion.identity) as GameObject;


    }

}
