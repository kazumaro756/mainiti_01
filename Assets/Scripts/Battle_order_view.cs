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
        update_image();
        update_order();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //テクストアップデート
    public void update_view(string text)
    {
        text_butai_name.text = text;
    }

    public void update_image()
    {
        image_panel.GetComponent<Image>().sprite = Resources.Load<Sprite>("symbols/rank_6");
    }

    public void update_order()
    {

        RectTransform rt = contents.GetComponent<RectTransform>();

        float wi = rt.sizeDelta.x;
        float he = rt.sizeDelta.y;


        rt.sizeDelta = new Vector2(wi-60f, he);


    }


}
