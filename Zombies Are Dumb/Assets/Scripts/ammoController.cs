using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Jugador")
        {
            if (Input.GetButton("Interact"))
            {
                GameObject.FindGameObjectWithTag("Gun").GetComponent<HandgunScriptLPFP>().ammo += 10;
                GameObject.FindGameObjectWithTag("Gun").GetComponent<HandgunScriptLPFP>().totalAmmoText.text = GameObject.FindGameObjectWithTag("Gun").GetComponent<HandgunScriptLPFP>().ammo.ToString();
                Destroy(this.gameObject);
            }


        }
    }
}
