using UnityEngine;
using System.Collections;

public class ChangeSprite : MonoBehaviour {

    public Sprite[] sprites;

	// Use this for initialization
	void Start () {

        int imgIndex = Random.Range(0, sprites.Length);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[imgIndex];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
