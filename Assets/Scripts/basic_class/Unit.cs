using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{

    [SerializeField]
    Text name_text;

    [SerializeField]
    Text name_durability;

    [SerializeField]
    Slider slider_durability;

    private string unit_name;
    private int max_durability;
    private int current_durability;


    public int Max_Durability { get => max_durability; set => max_durability = value; }
    public int Current_durability { get => current_durability; set => current_durability = value; }
    public string Unit_name { get => unit_name; set => unit_name = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        name_text.text = unit_name;
        name_durability.text = current_durability.ToString();
        slider_durability.value = current_durability * 1.0f / max_durability * 1.0f;

    }
}
