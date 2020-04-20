using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstAidController : MonoBehaviour
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
        if (other.tag == "Player")
        {
            if (Input.GetButton("Interact"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Vida>().recuperarSalud(30);

                Destroy(this.gameObject);
            }


        }
    }
}
