using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playermanager : MonoBehaviour {

    public int lifeValue = 3;
    public int playerScore = 0;
    public bool isDead = false;
    public bool isDefeat;


    public Text playersocoretext;
    public Text lifevaltext;
    public GameObject born;
    public GameObject gameoverui;

    //单例
    private static Playermanager instance;

    public static Playermanager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
            Recover();
        playersocoretext.text = playerScore.ToString();
        lifevaltext.text = lifeValue.ToString();
        if (isDefeat)
        {
            gameoverui.SetActive(true);
            Invoke("Returntomenu", 3); 
            return;
        }
	}

    private void Recover()
    {
        if (lifeValue < 0)
        {
            //游戏失败 返回主界面
            isDefeat = true;
        }
        else
        {
            lifeValue--;
            GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<Born>().iscreateenenmy = true;
            isDead = false;
        }
    }

    private void Returntomenu()
    {
        SceneManager.LoadScene(1);
    }
}
