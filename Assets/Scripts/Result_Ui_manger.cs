using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result_Ui_manger : MonoBehaviour
{
    [SerializeField]
    Text texta;

    [SerializeField]
    Text textb;

    [SerializeField]
    Text textc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //UIを更新するやつ。
    public void Update_ui(string a,string b,string c)
    {
        texta.text = a;
        textb.text = b;
        textc.text = c;
    }




}
