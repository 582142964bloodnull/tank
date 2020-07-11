using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 3f;//移动速度
    private float attackCD = 0f;//攻击间隔
    public GameObject Bullet;//获取子弹模型
    public GameObject ExplosionPrefab;//获取爆炸效果
    public Sprite[] TankSprtie; // 上 右 下 左


	private SpriteRenderer sr;//获取SpriteRenderer组件
    private Vector3 BulletAngle;//子弹角度

    private float ChangeDirVal;//玩家移动变化
    private float v = 0f;
    private float h = 0f;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Attack();//攻击
    }

    private void FixedUpdate()
    {
        Move();//移动
    }

    private void Move()
    {
        if(ChangeDirVal > 1)
        {
            int num = Random.Range(0, 8);//0-8随机数
            if(num >= 5)// 4/8前进
            {
                v = -1;
                h = 0;
            }
            else if( num == 0) //1/8后退
            {
                v = 1;
                h = 0;
            }
            else if(num > 0 && num <= 2)//2/8左转
            {
                h = -1;
                v = 0;
            }
			else if(num > 2 && num <= 4)//2/8右转
            {
                h = 1;
                v = 0;
            }
            ChangeDirVal = 0;
        }
        else
        {
			ChangeDirVal += Time.deltaTime;//按没一帧变化
        }

        transform.Translate(Vector3.right * h * speed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = TankSprtie[3];
            BulletAngle = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = TankSprtie[1];
            BulletAngle = new Vector3(0, 0, -90);
        }

        if (h != 0)
        {
            return;
        }

        transform.Translate(Vector3.up * v * speed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = TankSprtie[2];
            BulletAngle = new Vector3(0, 0, 180);
        }
        else if (v > 0)
        {
            sr.sprite = TankSprtie[0];
            BulletAngle = new Vector3(0, 0, 0);
        }
    }


    private void Attack()
    {
        if (attackCD < 1f)
        {
            attackCD += Time.deltaTime;
            return;
        }

        Instantiate(Bullet, transform.position, Quaternion.Euler(transform.eulerAngles + BulletAngle));
        attackCD = 0.5f;
    }

    private void Die()
    {
        playerManager.Instance.nScore += 1;
        // 爆炸特效
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);

        // 销毁自己
        Destroy(gameObject);
    }
}
