using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public Rigidbody2D myBody;
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
        if(points > 0.00f)
            time += Time.deltaTime;

        timeText.text = (Mathf.Round(time * 100f)/100f).ToString();

        //Update points
        if (!onTarget && points > 0f)
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
        if (Input.GetKeyDown(KeyCode.F1))
            SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
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
