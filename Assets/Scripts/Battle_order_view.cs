using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_order_view : MonoBehaviour
{
    //部隊名。
    [SerializeField]
    Text text_butai_name;

    [SerializeField]
    GameObject contents;

    [SerializeField]
    GameObject image_panel;


    //人からもらうAF。
    //private Air_Fleet af;
    


    // Start is called before the first frame update
    void Start()
    {
        //update_image();
        //update_order();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void update_all_ui(Air_Fleet af ,int parent_rank)
    {
        update_view(af.Name);
        update_image(af.Air_fleet_battle_order_rank);
        update_order(parent_rank);
    }



    //テクストアップデート
    public void update_view(string text)
    {
        text_butai_name.text = text;
    }

    //これはランク依存でOK。
    public void update_image(int rank)
    {
        image_panel.GetComponent<Image>().sprite = Resources.Load<Sprite>("symbols/rank_" + rank.ToString() );
    }

    //こっちの処理は、親との関係という観点からの処理。AF自体は親を知らないので引数はちょっと変える。
    public void update_order(int rank)
    {

        RectTransform rt = contents.GetComponent<RectTransform>();

        Vector3 localPos = rt.localPosition;
        float loca_x = localPos.x;
        float loca_y = localPos.y;
        float loca_z = localPos.z;

        //この処理はランクじゃなくて、親依存に変えたい
        //ランク1は一番上に来るのでマイナス1をしないと変になる

        //int rank_test;
        //if (rank == 1) { rank_test = 0; }else{ rank_test = rank - 1; }

        rt.localPosition = new Vector3(loca_x + 60*(rank),loca_y,loca_z);

        

    }

    


}
