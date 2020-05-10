using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class brotherController : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    public bool playerSeen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Vida>().valor <= 0)
        {
            Debug.Log("Has perdido");
            SceneManager.LoadScene("GameOver2");
        }

        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(player.position, this.transform.position) < 12 && angle < 45)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isHello", true);
            playerSeen = true;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);



            if (direction.magnitude > 3.5 && direction.magnitude < 10)
            {
                anim.SetBool("isIdle", false);
                anim.SetBool("isHello", false);
                anim.SetBool("isWalking", true);
                this.transform.Translate(0f, 0f, 0.05f);
            }

            else if(direction.magnitude > 8)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isHello", true);
            }

            else
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isHello", false);
                anim.SetBool("isIdle", true);
            }



        }

        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isHello", false);
            anim.SetBool("isIdle", true);
            playerSeen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Path")
        {
            Debug.Log("Collider lol");
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Path")
        {
            Debug.Log("Collider lol");
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        }
    }
}
