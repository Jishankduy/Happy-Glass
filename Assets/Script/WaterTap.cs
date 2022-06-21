using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : MonoBehaviour
{
    public bool isMainMenu;
    public GameObject water;
    float timeToSpawn = 0.1f;
    float spawnTime;
    public float timeToSpawnWater;
    Manager GM;
    LineFactory lineFactory;
    public int instantiatedGoCount;
    public Vector2 particleFlowDirection;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<Manager>();
        lineFactory = FindObjectOfType<LineFactory>();
    }

    // Update is called once per frame
    void Update()
    {  if (!GM.isGameEndStarted) return;
        if (!isMainMenu)
        {
            if (!lineFactory.isRunning) return;
        }
        if (timeToSpawnWater <= 0) return;
        timeToSpawnWater -= Time.deltaTime;

        if (spawnTime + timeToSpawn < Time.time)
        {
            GameObject GO = Instantiate(water,
      new Vector2(Random.Range(transform.position.x - .1f, transform.position.x + .1f), transform.position.y)
      , Quaternion.identity) as GameObject;
            GO.tag = "Water";

            GO.GetComponent<Rigidbody2D>().AddForce(particleFlowDirection);
            spawnTime = Time.time;

        }
    }
}
