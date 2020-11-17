using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//継承しているのであった。UpdateUIだけ抽象クラスなので注意せよ。ちなみにmonobihaviorも孫継承してるよ。
public class Prefab_UI_airfleet_task : Prefab_UI_abs
{
    [SerializeField]
    Text unit_name;
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
        if (a is Air_Fleet)
        {
            //型によって強制的にキャストしてるわけだが……これはうまくいかない気がするｗ。
            Air_Fleet a1 = a as Air_Fleet;
            Debug.Log(a1.Name);
            unit_name.text = a1.Name;
            leader_name.text = a1.Leader_name;
            task.value = a1.Task_id;
            fatigue.text = a1.Fatigue.ToString();
            unit_type.text = a1.Unit_type;
            unit_num.text = a1.Aircraft_number.ToString();
            pilot_num.text = a1.Pilot_number.ToString();
        }
    }

    //なんかこの実装はだめな気がするが一応書いておく……
    public void Change_task(Air_Fleet a)
    {
        a.Task_id = task.value;
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
