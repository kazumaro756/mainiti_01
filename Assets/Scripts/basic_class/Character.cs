//https://qiita.com/t_Kaku_7/items/240e6fcab213a916c0bd から取得しています。


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Character : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;
    [SerializeField] private GameObject[] enemies;

    //ここで設定しているターゲットとはなんぞや。
    //[SerializeField] private string attackTag; //Inspectorで設定

    private float stopDistance;
    private float attackTimer;
    private bool isAttack;
    //ここから
    public int hp;
    public int power;
    //ここまでInspectorで設定

    //敵味方フラグ。これはプレイヤー側視点に立ったときの理屈で書いている。
    [SerializeField]
    private bool zinei_flg;

    //
    //enum
    private enum targetType
    {
        normal,
        castle
    }

    private targetType currentTargetType;


    //流用コード
    [SerializeField]
    GameObject ballet;


    //あとで自動化するけど、今はこれ。
    [SerializeField]
    private GameObject target_of_fire;

    //対象リスト
    public List<GameObject> list_hitted_ships = new List<GameObject>();

    //攻撃感覚を指定するコルーチン
    private IEnumerator corutin_fire;

    public int Hp { get => hp; set => hp = value; }


    //ナヴィメッシュを取得。
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        isAttack = false;
    }

    //アップデート関数。将来的にはこれはイベントベースにしたい。
    private void Update()
    {

        if(hp > 0)
        {
            SetStopDistance();

            if (target == null)
            {
                //索敵 これを無条件に放つのはもったいないので、ターゲットがいなければ、という条件付きに変える。
                Rader(100, zinei_flg);
            }

            if (target != null)
            {
                //ターゲット
                agent.SetDestination(target.transform.position);

                //ここの処理がありえんほど重い
                //射程内にターゲットがいるときの処理、ということになっている。実質的には。
                if (Vector3.Distance(transform.position, target.transform.position) <= stopDistance)
                {
                    isAttack = true;
                    agent.speed = 0;
                }

                if (isAttack)
                {
                    SetStopDistance(); //攻撃中にtargetが変わった時のためにここでも記述
                    Attack();
                }
            }

        }
        else
        {
            //死ぬときゃしぬ。
            Die_when_die();

        }

    }
   
    //停止距離を指定。
    private void SetStopDistance()
    {
        if(target != null)
        {

            stopDistance = 20f;

            //if (target.gameObject.name.Contains("Castle"))
            //{
            //    currentTargetType = targetType.castle;
            //    stopDistance = 30f;
            //}
            //else
            //{
            //    currentTargetType = targetType.normal;
            //    stopDistance = 0.7f;
            //}
        }
    }


    //攻撃処理。全般に言えるけど、攻撃側が死亡判定を持つのは変なので実装を変える。
    private void Attack()
    {
        //攻撃間隔の初期化
        attackTimer += Time.deltaTime;

        //射撃間隔
            if (attackTimer > 1.0f)
            {

            //target.GetComponent<Castle>().Hp -= power;
            //射撃をする処理を追加。
            //敵に向かって進んでいく玉を発生させる。

            //砲撃開始処理。
                Fire();

                attackTimer = 0f;
            }

    }



        //case (targetType.normal):
        //    if (attackTimer > 1.0f)
        //    {
        //        //攻撃間隔についての処理。
        //        target.GetComponent<Character>().hp -= power;
        //        attackTimer = 0f;
        //    }
        //    if (target.GetComponent<Character>().hp <= 0)
        //    {
        //        //ここの処理がすごく気に食わない！！！！！！！！！！！！！！！！！！
        //        //攻撃終了。
        //        isAttack = false;

        //        //破壊処理。
        //        Destroy(target.gameObject);

        //        //走る処理を再設定？？？
        //        agent.speed = 1;
        //    }
        //    break;
        //case (targetType.castle):
        //    if (attackTimer > 1.0f)
        //    {

        //        //target.GetComponent<Castle>().Hp -= power;
        //        //射撃をする処理を追加。
        //        //敵に向かって進んでいく玉を発生させる。

        //        //砲撃開始処理。
        //        Fire();

        //        attackTimer = 0f;
        //    }
        //    break;



                
            


///以下、もうちょっと書く。。。

    //砲弾のインスタンス化という意味で砲撃と表現している。
    public void Fire()
    {
        //レーダーで敵を補足できたかどうかで場合分け。
        if (target != null)
        {//レーダーで補足成功していた場合

            //ちょっとずらしたところに発生させる。
            //自分自身の座標を取得
            Vector3 pos = transform.position;
            //玉を表示するポジションを表示
            pos.y += 3f;

            //砲弾をインスタンス化。
            GameObject bullet_obj = Instantiate(ballet, pos, Quaternion.identity) as GameObject;

            //砲弾に自分自身の陣営を教えてあげる。一旦ここは見方しかいないのでOK。フレンドリーファイアを管理している。
            // bullet_obj.GetComponent<Bullet>().Flag_my_position = zinei_flg;

            //ターゲットはここに与える。こっちがわのターゲットは関係ない。
            bullet_obj.GetComponent<Bullet>().target = target;

        }
        else
        {
            //もし敵を取得できていないのであれば、何もしない。

        }


    }

    //指定の秒数間隔で処理を実施しつづける処理。攻撃間隔の処理だと思ってくれればOK。
    private IEnumerator Delay_regene(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //射撃
            Fire();
        }
    }


    //レーダーで敵発見を絞るシステム。 これが事実上のfind target 関数になる。
    private void Rader(float rader_range , bool z_flg)
    {
        //レイのビームを発射。
        Ray ray = new Ray(transform.position, transform.forward);

        //リストが失敗したときの処理。
        //hitted_obj
        //RaycastHit[] neko; 
        //あたったもののリスト
        //
        list_hitted_ships = Physics.SphereCastAll(transform.position, rader_range, transform.forward, 0.01f).Select(h => h.transform.gameObject).ToList();
        //neko = Physics.SphereCastAll(transform.position, rader_range, transform.forward, 0.01f);

        //tagによって敵味方識別
        if (z_flg)
        {//自分の出身がエネミー側。
            list_hitted_ships = list_hitted_ships.Where(h => h.tag == "player").ToList();
        }
        else
        {//自分自身がプレイヤー側なのであれば「enemy]のタグを探す。
            list_hitted_ships = list_hitted_ships.Where(h => h.tag == "enemy").ToList();
        }

        if (list_hitted_ships.Count > 0)
        {//リストの中身が何かしら残っているときは、これの一つを探す。これはなんかガバガバすぎるんではないか……
            //ここの中身の処理に関しては、以上で考える。
            //もっとも近いものを治す

            float min_distance = float.MaxValue;
            foreach (GameObject hitted in list_hitted_ships)
            {
                float target_distance = Vector3.Distance(transform.position, hitted.transform.position);

                //最短が見つかった場合
                if(target_distance < min_distance)
                {
                    min_distance = target_distance;
                    target = hitted.transform.gameObject;

                }

            }

            //target = list_hitted_ships[0];
        }
        else
        {//リストの中身がないならやめておく。
            target = null;
        }

    }


    //死ぬときに死ぬ。
    private void Die_when_die()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }



}