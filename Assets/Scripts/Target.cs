using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    Rigidbody2D myBody;
    Player thePlayer;

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
        thePlayer = FindObjectOfType<Player>();
        myBody.velocity = movement;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x > 0f)
            transform.localScale = new Vector3((thePlayer.points/1000f)*5, (thePlayer.points/1000f)*5, transform.localScale.z);

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
