using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_order_view : MonoBehaviour
{
    //部隊名。
    [SerializeField]
    Text text_butai_name;

    

    // Start is called before the first frame update
    void Start()
    {
        
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

}
