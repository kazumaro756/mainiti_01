using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class root_info_manager : MonoBehaviour
{

    [SerializeField]
    GameObject panel_battle;

    [SerializeField]
    GameObject panel_result;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //画面の関連。
    public void Battle_panae_ui_activate()
    {
        panel_battle.SetActive(true);
        
    }

    public void Battle_panel_ui_deactive()
    {
        panel_battle.SetActive(false);
        //更新。
        GameObject.Find("Panel_manage").GetComponent<Naval_Manager>().Deploy_pilots();

    }

    //結果の表示。
    public void Result_panel_ui_activate()
    {
        panel_result.SetActive(true);
    }

    public void Result_panel_ui_deactivate()
    {
        panel_result.SetActive(false);
    }



}
