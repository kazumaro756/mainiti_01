using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Prefab_UI_abs : MonoBehaviour
{

    abstract public void UpdateUI<type>(type a) ;

}

public class Prefab_UI : Prefab_UI_abs
{

    [SerializeField]
    Text text_name;
    

    public override void UpdateUI<type>(type a)
    {
        if (a is Air_Fleet){
            //型によって強制的にキャストしてるわけだが……これはうまくいかない気がするｗ。
            Air_Fleet a1 = a as Air_Fleet;
            Debug.Log(a1.Name);
            text_name.text = a1.Name;
        }


        
    }

    


}



