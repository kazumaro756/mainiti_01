using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//継承しているのであった。UpdateUIだけ抽象クラスなので注意せよ。ちなみにmonobihaviorも孫継承してるよ。
public class Prefab_UI_airfleet_task : Prefab_UI_abs
{
    [SerializeField]
    Text name;
    [SerializeField]
    Text leader_name;
    [SerializeField]
    Dropdown task;
    [SerializeField]
    Text fatigue;
    [SerializeField]
    Text unit_type;
    [SerializeField]
    Text unit_num;
    [SerializeField]
    Text pilot_num;


    public override void UpdateUI<type>(type a)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
