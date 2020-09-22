using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_Battle : MonoBehaviour
{
    //ここでビューを決める。
    [SerializeField]
    Text friend_unit_name;

    [SerializeField]
    Text friend_current_dura;

    [SerializeField]
    Text enemy_unit_name;

    [SerializeField]
    Text enemy_current_dura;

    [SerializeField]
    Text pilot_name;

    [SerializeField]
    Slider friend_hp_slider;

    [SerializeField]
    Slider enemy_hp_slider;

    [SerializeField]
    GameObject aircraft_damage_image;

    private string local_friend_unit_name; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void updateUI(Aircraft aircraft ,Ship ship)
    {
        //
        friend_unit_name.text = aircraft.Unit_name;

        //
        friend_current_dura.text = aircraft.Current_durability.ToString();

        //
        pilot_name.text = aircraft.Pilot_name;

        //
        enemy_unit_name.text = ship.Unit_name;

        //
        enemy_current_dura.text = ship.Current_durability.ToString();

        //
        friend_hp_slider.value = aircraft.Current_durability * 1.0f / aircraft.Max_Durability  * 1.0f;

        enemy_hp_slider.value = ship.Current_durability * 1.0f / ship.Max_Durability * 1.0f;

    }

    //爆発ダメージon
    public void upadate_damage_ui_enable()
    {
        aircraft_damage_image.SetActive(true);
    }

    //爆発ダメージon
    public void upadate_damage_ui_disable()
    {
        aircraft_damage_image.SetActive(false);
    }



}
