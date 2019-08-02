using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //属性值
    public float moveSpeed = 1000;
    private Vector3 bullecteulerangles;
    private float h;
    private float v;
    
    //引用 
    public Sprite[] tanksprite;
    private SpriteRenderer sr;
    public GameObject bullectprefab;
    public GameObject explosionprefab;

    //计时器;
    private float timeVal;
    private float changeDirection=4;


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
        //攻击cd
        if (timeVal >=3)
        {
            Attack();
        }
        else
            timeVal += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        Move();
    }


    //坦克攻击
    private void Attack()
    {
        
            Instantiate(bullectprefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullecteulerangles));
            timeVal = 0;
    }

    //坦克的移动
    private void Move()
    {
        if (changeDirection >= 4)
        {
            int num = Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                h = -1;
                v = 0;
            }
            else
            {
                h = 1;
                v = 0;
            }
            changeDirection = 0;
        }
        else
            changeDirection += Time.fixedDeltaTime;

        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (h < 0)
        {
            sr.sprite = tanksprite[3];
            bullecteulerangles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tanksprite[1];
            bullecteulerangles = new Vector3(0, 0, -90);
        }

        if (h != 0)
            return;
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tanksprite[2];
            bullecteulerangles = new Vector3(0, 0, -180);
        }
        else if (v > 0)
        {
            sr.sprite = tanksprite[0];
            bullecteulerangles = new Vector3(0, 0, 0);
        }
    }

    //坦克死亡
    private void Die()
    {

        //爆炸
        Instantiate(explosionprefab, transform.position, transform.rotation);
        //死亡
        Destroy(gameObject);
        Playermanager.Instance.playerScore++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            changeDirection = 4;
        }
    }
}
