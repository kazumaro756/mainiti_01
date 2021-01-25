using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUiController : MonoBehaviour
{
    [SerializeField]
    Text money_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Update_money_text(string mt)
    {
        money_text.text = mt;
    }

}
