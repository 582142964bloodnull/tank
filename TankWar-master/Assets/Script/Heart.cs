using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

    private SpriteRenderer sr;
    public Sprite BrokenSprite;
	public AudioClip Audiohit;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}

    private void Die()
    {
		AudioSource.PlayClipAtPoint(Audiohit, transform.position);
        sr.sprite = BrokenSprite;
		playerManager.Instance.houseLife -= 1;
		if(playerManager.Instance.houseLife<=0){
		Destroy (gameObject);
		}
    }
}
