using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class LogicaEnemigo : MonoBehaviour
{
    private Vida vida;
    private Animator animator;
    private Collider collider;
    private Vida vidaJugador;
    private LogicaJugador logicaJugador;
    public bool vida0 = false;
    public bool estaAtacando = false;
    public float daño = 25;
    // Start is called before the first frame update
    void Start()
    {
        
        
 

        
        vida = GetComponent<Vida>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
    }

    

    void RevisarVida()
    {
        if (vida0) return;
        if (vida.valor <= 0)
        {
            vida0 = true;
            gameObject.GetComponent<GeneticPathfinder>().hasFinished = true;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bala")
        {
            vida.valor -= 50;
            Debug.Log("Vida del zombie: " + vida.valor);
            
        }
    }


}
