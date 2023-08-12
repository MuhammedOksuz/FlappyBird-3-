using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    // Sky
    public GameObject skyOne;
    public GameObject skyTwo;
    float lenght;
    public float skyVelocity = -1.6f;
    // Rigidbody
    Rigidbody2D skyOneRB;
    Rigidbody2D skyTwoRB;
    // Obstacles
    public GameObject obstacle;
    public int obstaclesNumber = 10;
    GameObject[] obstacles;
    bool gameOver = true;
    int counter = 0;
    // Time
    float obstaclesTime = 0;
    public float obstacleBuýldTime = 2;



    

    void Start()
    {
        skyOneRB = skyOne.GetComponent<Rigidbody2D>();
        skyTwoRB = skyTwo.GetComponent<Rigidbody2D>();

        skyOneRB.velocity = new Vector2(skyVelocity, 0);
        skyTwoRB.velocity = new Vector2(skyVelocity, 0);
        lenght = skyOne.GetComponent<BoxCollider2D>().size.x;

        obstacles = new GameObject[obstaclesNumber];

        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i] = Instantiate(obstacle, new Vector3(-22, -22), Quaternion.identity);             
            Rigidbody2D obstaclesRB = obstacles[i].AddComponent<Rigidbody2D>();
            obstaclesRB.gravityScale = 0;
            obstaclesRB.velocity = new Vector2(skyVelocity, 0);
        }
    }

    void Update()
    {
        SkyAnimation();

        obstaclesTime += Time.deltaTime;
        if (obstaclesTime >= obstacleBuýldTime && gameOver)
        {
            obstaclesTime = 0;
            float yAxis = Random.Range(-3.6f, -0.8f);
            obstacles[counter].transform.position = new Vector3(4, yAxis);
            counter++;
            if (counter==obstacles.Length)
            {
                counter = 0;
            }
        }
    }
    void SkyAnimation()
    {
        if (skyOne.transform.position.x <= -lenght)
        {
            skyOne.transform.position += new Vector3(lenght * 2, 0);
        }
        if (skyTwo.transform.position.x <= -lenght)
        {
            skyTwo.transform.position += new Vector3(lenght * 2, 0);
        }
    }
     public void GameOver()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            gameOver = false;
            obstacles[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            skyOneRB.velocity = Vector2.zero;
            skyTwoRB.velocity = Vector2.zero;
        }
    }
}
