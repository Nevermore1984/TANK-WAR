using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //属性值
    public float moveSpeed = 1000;
    private Vector3 bullecteulerangles;
    private float timeVal;
    private float defendTimeVal=3;
    private bool isDefended=true;//bool默认值是flase;
    //引用 
    public Sprite[] tanksprite;
    private SpriteRenderer sr;
    public GameObject bullectprefab;
    public GameObject explosionprefab;
    public GameObject defendeffectprefab;

    public AudioSource moveAudio;
    public AudioClip[] tankAudio;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //无敌时间
        if (isDefended)
        {
            defendeffectprefab.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal <= 0)
            {
                isDefended = false;
                defendeffectprefab.SetActive(false);
            }
        }



       
    }
    private void FixedUpdate() 
    {

        if (Playermanager.Instance.isDefeat)
            return;
        Move();
        //攻击cd
        if (timeVal >= 0.4)
        {
            Attack();
        }
        else
            timeVal += Time.fixedDeltaTime;
    }


    //坦克攻击
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //子弹产生的角度：当前坦克角度+子弹应该旋转的角度
            Instantiate(bullectprefab, transform.position, Quaternion.Euler(transform.eulerAngles+bullecteulerangles));
            timeVal = 0;
        }
    }

    //坦克的移动
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
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
        if (Mathf.Abs(h) > 0.05f)
        {
            moveAudio.clip = tankAudio[1];

            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
      
        if (h != 0)
            return;
        float v = Input.GetAxisRaw("Vertical");
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

        if (Mathf.Abs(v)>0.05f)
        {
            moveAudio.clip = tankAudio[1];
            
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
        else
        {
            moveAudio.clip = tankAudio[0];

            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
    }

    //坦克死亡
    private void Die()
    {
        if (!isDefended)
        {
            //爆炸 
            Instantiate(explosionprefab, transform.position, transform.rotation);
            //死亡
            Destroy(gameObject);
            Playermanager.Instance.isDead = true;
        }
    }
}
