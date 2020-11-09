using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_ui_panel : MonoBehaviour
{
    //自分自身を閉じる。
    public void Disable_panel()
    {
        this.transform.gameObject.SetActive(false);
    }



}
