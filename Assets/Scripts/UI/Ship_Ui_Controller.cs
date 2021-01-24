using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Ship_Ui_Controller : MonoBehaviour
{
    [SerializeField]
    Text text_name;

    [SerializeField]
    Text popuptext;

    //爆発エフェクト
    [SerializeField]
    ParticleSystem exp_effect;

    [SerializeField]
    GameObject attacking_obj;


    [SerializeField]
    Slider slider_hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UPdateUI(Ship_test ship)
    {
        text_name.text = ship.ship_name;

    }


    public void UpdateTEXT(string text)
    {
        popuptext.text = text;
    }

    public void Explode()
    {
        exp_effect.Play();
    }

    public void ONAttacking(string text)
    {
        attacking_obj.SetActive(true);
        attacking_obj.GetComponent<Text>().text = text;
    }

    public void Finish_attacking()
    {
        attacking_obj.SetActive(false);
    }

    //HPバーの更新。
    public void UpdateHpSlider(int hp ,int max_hp)
    {
        slider_hp.GetComponent<Slider>().value = hp * 1.0f / max_hp * 1.0f;
    }


}
