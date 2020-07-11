using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opetion : MonoBehaviour {

	public int nChoice = 1;//游戏模式
    public Transform PosOne;//单人游戏图标位置
    public Transform PosTwo;//双人游戏图标位置

	void Start () {
		
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.W))
        {
			nChoice = 1;

            transform.position = PosOne.position;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
			nChoice = 2;

            transform.position = PosTwo.position;
        }
        else if (Input.GetKeyDown(KeyCode.Space))//按下空格，进入对应的场景
        {
			SceneManager.LoadScene(nChoice);
        }
        

    }

}
