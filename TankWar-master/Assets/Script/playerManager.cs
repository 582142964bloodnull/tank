using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour {
	public int houseLife =5;//设置基地的血量
    public int nScore = 0;//分数


	public int player1hp=5;//玩家1血量
	public int player2hp=0;//玩家2血量

    public Text PlayerScore;//玩家分数文本
    public GameObject ImgGameOver;//游戏结束的图片
	public  GameObject RstartScore;//游戏结束的提示
	public Text p1Hp;//玩家1血量文本
	public Text p2Hp;//玩家2血量文本
	public Text househp;//基地血量文本

    private static playerManager instance;

    public static playerManager Instance
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
		
		PlayerScore.text = nScore.ToString();//获取分数
		p1Hp.text = player1hp.ToString ();//获取玩家1血量
		p2Hp.text = player2hp.ToString ();//获取玩家2血量
		househp.text = houseLife.ToString ();//获取基地血量
		if (houseLife <= 0) {//基地血小于等于0
			ImgGameOver.SetActive (true);//显示gameover游戏结束的图片
			RstartScore.SetActive (true);//显示游戏结束的提示
			Rstart ();
			Back ();
		}
		if (player1hp <= 0 && player2hp <=0) {//玩家1和玩家2的血量都小于等于0
				ImgGameOver.SetActive (true);
				RstartScore.SetActive (true);
				Rstart ();
			    Back ();
			}
		}

     void  Rstart()
	 {
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			//重新启动现在的场景（网上看的）
		}
	 }
	void  Back()
	{
		if (Input.GetKeyDown (KeyCode.B)) {
			SceneManager.LoadScene(0);//返回场景0（主菜单）
		}
	}


}
