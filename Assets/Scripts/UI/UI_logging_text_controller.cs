using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_logging_text_controller : MonoBehaviour
{
    [SerializeField]
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Updatetext(string text_act)
    {
        text.text = text_act;
    }

}
