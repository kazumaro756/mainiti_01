using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // <summary>
    ///砲弾を発生させる。 
    /// 
    /// 
    /// </summary>


    //自分にとっての敵をしるためのもの
    private bool flag_my_position;

    //ゲームフリーとリスト 宣言はこういうふうにしないとあかん。
    public List<GameObject> list_hitted_ships = new List<GameObject>();

    //ミサイルの攻撃対象用オブジェクト
    public GameObject target;

    //ダメージ量。外からも知ってもらうためにプロパテぃで定義
    private int damage;


    public int Damage { get => damage; set => damage = value; }
    public bool Flag_my_position { get => flag_my_position; set => flag_my_position = value; }



    // Start is called before the first frame update
    void Start()
    {
        damage = 30;
    }

    // Update is called once per frame
    void Update()
    {
        move_to_trgt();
    }


    public void move_to_trgt()
    {
        if (target == null)
        {
            //対象がない。
            //問答無用で破壊
            Destroy(this.gameObject);
        }
        else
        {
            //ちゃんとターゲットが設定されている。
            //ミサイルのスピード
            float speed = 1f;

            //向きの設定
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), 0.3f);

            //移動。
            transform.position += transform.forward * speed;


        }


    }

    //対城の砲兵攻撃限定の処理。あとで処理を変える。
    void OnCollisionEnter(Collision collision)
    {
        //不慮の事故でモデルを持ってないオブジェクトにあたったときの処理。
        if (collision.gameObject.GetComponent<Character>() == null)
        {

            //Debug.Log("aaaaa");
            //問答無用で破壊
            Destroy(this.gameObject);
        }
        else
        {
            //あたった対象に対してダメージを与える。
            collision.gameObject.GetComponent<Character>().Hp -= damage;
            //Debug.Log(collision.gameObject.name); // ぶつかった相手の名前を取得
            //あたったら破壊。
            Destroy(this.gameObject);

            //Debug.Log("bbbb");
        }

    }
}
