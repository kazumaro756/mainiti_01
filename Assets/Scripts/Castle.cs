using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{

    public float hp;

    public float Hp { get => hp; set => hp = value; }

    // Start is called before the first frame update
    void Start()
    {
        hp = 3000;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
