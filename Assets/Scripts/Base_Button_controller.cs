using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Button_controller : MonoBehaviour
{

    [SerializeField]
    GameObject use;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //引数を取る方法を考えてみる。
    public void test(int a)
    {
        a += 1;
        //GameObject use = GameObject.Find("Panel_dayonn");
        use.SetActive(true);

        //ここで、ページ内の各種変数を取得してしまうという手続きを実施する。

    }

}
