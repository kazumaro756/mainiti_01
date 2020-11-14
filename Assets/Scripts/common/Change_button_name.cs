using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_button_name : MonoBehaviour
{
    [SerializeField]
    Text buttun_name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ボタン配下のテキストを変更。
    public void Update_Button_Name(string name)
    {
        buttun_name.text = name;

    }

}
