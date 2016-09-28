using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    Rigidbody2D myBody;

    Vector2 movement;
    public float speed = 4f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        if (Random.value < 0.5f)
            movement = Vector2.left * speed;
        else
            movement = Vector2.right * speed;
    }

	// Use this for initialization
	void Start () {
        myBody.velocity = movement;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("bingo");
        if (col.gameObject.GetComponent<Player>() == null) {
            if (movement == Vector2.left * speed)
                movement = Vector2.right * speed;
            else
                movement = Vector2.left * speed;

            myBody.velocity = movement;
        }
    }
}
