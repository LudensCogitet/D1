using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Rigidbody2D myBody;
    public float speed = 0.2f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.velocity = myBody.velocity + Vector2.left * speed; ;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myBody.velocity = myBody.velocity + Vector2.right * speed; ;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myBody.velocity = -myBody.velocity;
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("HI!");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("HI!");
    }


}
