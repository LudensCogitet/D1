using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    Rigidbody2D myBody;
    public Text timeText;
    public Text pointsText;

    public float speed = 0.2f;
    public float points = 100;
    public float time = 0.0f;

    bool onTarget = false;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {

        //Update elapsed time
        time += Time.deltaTime;
        timeText.text = (Mathf.Round(time * 100f)/100f).ToString();

        //Update points
        if (!onTarget)
            points -= Time.deltaTime * 4;

        pointsText.text = Mathf.Round(points).ToString();

        //Input
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
        onTarget = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        onTarget = false;
    }


}
