using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

    Player thePlayer;

    public Vector3 maxScale;
    public Vector3 currentScale;
    public float explosionTime = 0.5f;
    public float lastFor;

    public bool exploded = false;

    public GameObject squareOutline;
    GameObject outline;

    public Vector2 force;

    void Awake()
    {
        maxScale = new Vector3(0.3f, 0.3f, 1f);
        currentScale = transform.localScale;

        outline = Instantiate(squareOutline) as GameObject;
        outline.transform.position = transform.position;
        outline.transform.localScale = maxScale;
        outline.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
    }


    // Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<Player>();
        StartCoroutine("Explode");
	}
	
	// Update is called once per frame
	void Update () {
  
	}

    IEnumerator Explode()
    {
        float dif = maxScale.x - currentScale.x;
        float currentTime = 0f;

        while (currentScale != maxScale) {
            Debug.Log("hi!");
       
            currentScale = Vector3.MoveTowards(currentScale, maxScale,dif/explosionTime*Time.deltaTime);
            transform.localScale = currentScale;
            yield return null;
        }
        exploded = true;
        Invoke("GoByeBye", lastFor);
    }

    void GoByeBye()
    {
        GameObject.Destroy(outline);
        GameObject.Destroy(this.gameObject);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("GORPH!");
        if (col.gameObject == thePlayer.gameObject && exploded == true)
        {
            Vector2 newVel = thePlayer.myBody.velocity;
            if (newVel.x < 0f)
                newVel -= force;
            else
                newVel += force;
            thePlayer.myBody.velocity = -newVel;
        }
    }

}
