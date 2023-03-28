
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterMovement : MonoBehaviour

{
    public TMP_Text hj;    
    public TextMeshProUGUI GameOver,Life,FinalScore;
    public GameObject Spawner,Panel,buton;
    public float CharSpeed;
    public Rigidbody2D rb;
    Vector2 Move;     
    int Health=3;
    public int CharScore=0;

    
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();

        FinalScore.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);
        Panel.gameObject.SetActive(false);
        buton.gameObject.SetActive(false);
        
       
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Transform Meteors  
        if (col.gameObject.tag == "Ast")
        {
            col.transform.position = new Vector3(Random.Range(-9, 9),Random.Range(6, 10), -0.1f);
            Health--;
            // Stop game when Health is 0
            if (Health==0)
            {

                Time.timeScale = 0;
                FinalScore.text = "Final Score: " + CharScore.ToString();
                FinalScore.gameObject.SetActive(true);
                GameOver.gameObject.SetActive(true);
                Panel.gameObject.SetActive(true);
                buton.gameObject.SetActive(true);
            }
        }
    }
    void Update()
    {
        // Health text
        Life.text ="Life: " + Health.ToString();

        //Movement 
        Move.y = Input.GetAxis("Horizontal");
        transform.Translate(CharSpeed * Move.y * Time.deltaTime,0,0);
        
        

    }
    // Reastard Game on Restart button click
    public void OnButtonClick(){
        Health = 3;
        CharScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;


    }
    
}
