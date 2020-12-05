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


    public void update_all_ui(Air_Fleet af )
    {
        update_view(af.Name);
        update_image(af.Air_fleet_battle_order_rank);
        update_order(af.Air_fleet_battle_order_rank);
    }



    //テクストアップデート
    public void update_view(string text)
    {
        text_butai_name.text = text;
    }

    public void update_image(int rank)
    {
        image_panel.GetComponent<Image>().sprite = Resources.Load<Sprite>("symbols/rank_" + rank.ToString() );
    }

    public void update_order(int rank)
    {

        RectTransform rt = contents.GetComponent<RectTransform>();

        Vector3 localPos = rt.localPosition;
        float loca_x = localPos.x;
        float loca_y = localPos.y;
        float loca_z = localPos.z;

        //ランク1は一番上に来るのでマイナス1をしないと変になる
        rt.localPosition = new Vector3(loca_x + 60*(rank-1),loca_y,loca_z);


    }


}
