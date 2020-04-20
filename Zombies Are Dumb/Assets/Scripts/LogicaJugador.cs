using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaJugador : MonoBehaviour
{
    public Vida vida;
    public GameObject hermano;
    public bool vida0 = false;
    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Vida>();
        

    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
    }

    void RevisarVida()
    {
        if (vida0)
        {
            return;
        }

        if (vida.valor <= 0)
        {
            vida0 = true;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Casa" && hermano.GetComponent<brotherController>().playerSeen)
        {
            Debug.Log("Has ganado");
        }
    }
}
