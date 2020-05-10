using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicaJugador : MonoBehaviour
{
    public Vida vida;
    public GameObject hermano;
    
    public Text currentLifeText;
    public Text totalLifeText;
    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Vida>();
        totalLifeText.text = "100";

    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        currentLifeText.text = vida.valor.ToString();
        
    }

    void RevisarVida()
    {
        

        if (vida.valor <= 0)
        {
            
            SceneManager.LoadScene("GameOver1");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Casa" && hermano.GetComponent<brotherController>().playerSeen)
        {
            Debug.Log("Has ganado");
            SceneManager.LoadScene("Win");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Blue" || collision.transform.tag == "Orange" || collision.transform.tag == "Genetic")
        {
            if (Input.GetButton("KnifeAttack"))
            {
                collision.gameObject.GetComponent<Vida>().recibirDaño(20f);
            }
        }
    }
}
