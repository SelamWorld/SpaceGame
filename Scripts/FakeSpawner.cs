using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FakeSpawner : MonoBehaviour
{                        
public TextMeshProUGUI CharGUI;
private int CharScore;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ast")
        {
           // karakterin scriptine eriþ ve skor textini güncelle
           CharScore= ++FindObjectOfType<CharacterMovement>().CharScore;
           // meteorlarý yukarý yolla
           col.transform.position=new Vector3 (Random.Range(-9, 9), Random.Range(6,10), -0.1f);
        }
    }
     

    void Start()                                                       
    {
        

    }

    private void Update()
    {
        // Update Score into text
        CharGUI.text = CharScore.ToString();
    }
}
