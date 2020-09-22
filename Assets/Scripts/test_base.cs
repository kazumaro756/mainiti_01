using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test_base : MonoBehaviour
{

    private string text_logging;

    [SerializeField]
    Text testtext;

    // Start is called before the first frame update
    void Start()
    {

    }


    public void textupdate(string text_text)
    {
        testtext.text = text_text;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
