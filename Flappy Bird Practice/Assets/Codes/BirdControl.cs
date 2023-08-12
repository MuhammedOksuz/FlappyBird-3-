using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdControl : MonoBehaviour
{
    // Rigidbody
    Rigidbody2D birdsRB;
    public float JumpForce = 200;
    bool gameOver = true;
    // Sprites
    SpriteRenderer spriteR;
    public Sprite[] birds;
    bool spritesControl = true;
    int spritesCounter = 0;
    // Time
    float time = 0f;
    public float wingsTime = 0.1f;
    // Scor
    int counter = 0;
    public Text scor;
    int highestScore = 0;
    // Game Control
    GameControl gameControl;
    


    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        birdsRB = GetComponent<Rigidbody2D>();

        gameControl = GameObject.FindGameObjectWithTag("gameControl").GetComponent<GameControl>();
        highestScore = PlayerPrefs.GetInt("scor");
    }

    
    void Update()
    {
        Animation();
        Rigidbody();


    }
    void Animation()
    {
        time += Time.deltaTime;
        if (time > wingsTime)
        {
            time = 0;

            if (spritesControl)
            {
                spriteR.sprite = birds[spritesCounter];
                spritesCounter++;
                if (spritesCounter == birds.Length)
                {
                    spritesCounter--;
                    spritesControl = false;
                }
            }

            else
            {
                spritesCounter--;
                spriteR.sprite = birds[spritesCounter];
                if (spritesCounter == 0)
                {
                    spritesCounter++;
                    spritesControl = true;
                }

            }
        }
    }
    void Rigidbody()
    {

            if (Input.GetMouseButtonDown(0) && gameOver)
            {
                birdsRB.velocity = new Vector2(0, 0);
                birdsRB.AddForce(new Vector2(0, JumpForce));
            }
            if (birdsRB.velocity.y > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 45);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, -45);
            }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "scor")
        {
            counter += 10;
            scor.text = "Scor : " + counter; 
        }
        if (collision.gameObject.tag == "obstacle")
        {
            gameOver = false;
            gameControl.GameOver();

            Invoke("WaitForSecond", 2);
        }
        if (counter > highestScore)
        {
            highestScore = counter;
            PlayerPrefs.SetInt("scor",highestScore);
        }
        

    }
    void WaitForSecond()
    {
        PlayerPrefs.SetInt("LastScor", counter);
        SceneManager.LoadScene("Menu");
    }
}
