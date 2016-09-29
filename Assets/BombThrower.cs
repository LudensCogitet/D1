using UnityEngine;
using System.Collections;

public class BombThrower : MonoBehaviour {

    Player thePlayer;

    public Bomb bombPrefab;
    public float maxSpawnTime = 10f;
    public float minSpawnTime = 2f;

    public float leftWallX;
    public float rightWallX;

    void Awake()
    {
    }

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<Player>();
        Invoke("SpawnBomb", Random.Range(0.0001f, maxSpawnTime));
    }

	void SpawnBomb()
    {
        Vector3 initPos = new Vector3(Random.Range(leftWallX, rightWallX), 0f, 0f);
        Instantiate(bombPrefab, initPos,Quaternion.identity);
        Invoke("SpawnBomb", Random.Range(0.0001f, maxSpawnTime));
        if (maxSpawnTime > minSpawnTime)
            maxSpawnTime -= (thePlayer.time / 10f)/4;
    }
}
