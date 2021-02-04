using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerA : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    public Objectpooler stickman;
    public GameObject player;
    public GameObject stickmanpoint;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        myAnimator.SetFloat("speed", myRigidbody.velocity.x);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("stickmanspawn"))
        {
            player.SetActive(false);
            GameObject stick = stickman.GetPooledObject();
            stick.transform.position = stickmanpoint.transform.position;
            stick.SetActive(true);
        }

    }
}
