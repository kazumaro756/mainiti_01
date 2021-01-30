using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ui_ship_pool : MonoBehaviour
{

    [SerializeField]
    Text class_type;

    [SerializeField]
    Text class_name;

    [SerializeField]
    Text ship_name;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Update_UI(string type,string cs,string name)
    {
        class_type.text = type;
        class_name.text = cs;
        ship_name.text = name;


    }


}
