using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3;
    private float random;
    private float dirNumb;
    private int health = 3;
    [SerializeField]
    private float timer = 3;
    private Vector3 dirWalk;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Animation hitAnim;
    int lastH = 3;

    // Update is called once per frame
    void Start()
    {
        dirNumb = ChooseDir();
        WalkRandDir(dirNumb);
    }

    void Update()
    {
        lastH = health;
        timer -= 1 * Time.deltaTime;
        if(timer <= 0)
        {
            dirNumb = ChooseDir();
            timer = 3;
        }
        transform.position += dirWalk * speed * Time.deltaTime;
        
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        //             Animation
        if( dirWalk == new Vector3(0, 1, 0)|| dirWalk == new Vector3(0.5f, 0.5f, 0.0f))
        {
            anim.SetInteger("WalkCount", 2);
            Debug.Log("EnemyUp");
        }
        else if (dirWalk == new Vector3(1.0f, 0, 0) || dirWalk == new Vector3(-0.5f, 0.5f, 0.0f))
        {
            anim.SetInteger("WalkCount", 1);
        }
        else if (dirWalk == new Vector3(1.0f, 0, 0) || dirWalk == new Vector3(0.5f, -0.5f, 0.0f))
        {
            anim.SetInteger("WalkCount", 3);
        }
        else if (dirWalk == new Vector3(0.0f, 1f, 0.0f) || dirWalk == new Vector3(-0.5f, -0.5f, 0.0f))
        {
            anim.SetInteger("WalkCount", 4);
        }
        Debug.Log(dirWalk);
    }



    void walk(Vector3 dir, float wSpeed)
    {
        transform.position += dir * wSpeed * Time.deltaTime;
    }
    float ChooseDir()
    {
        random = Random.RandomRange(0, 7);
        return random;
        
    }
    void WalkRandDir(float random)
    {
        if (random == 0)
        {
            dirWalk = transform.up;
        }
        
        if (random == 1)
        {
            dirWalk = (transform.up + transform.right) / 2;
        }
        if (random == 2)
        {
            dirWalk = (transform.up + -transform.right) / 2;
        }
        if (random == 3)
        {
            dirWalk = -transform.up;
        }
        if (random == 4)
        {
            dirWalk = (-transform.up + -transform.right) / 2;
        }
        if (random == 5)
        {
            dirWalk = (-transform.up + transform.right) / 2;
        }
        if (random == 6)
        {
            dirWalk = transform.right;
        }
        if (random == 7)
        {
            dirWalk = -transform.right;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.Play("New State");
        if (collision.gameObject.tag == "bullet")
        {
            health = lastH - 1;
            Debug.Log(health);
            anim.Play("hit");
        }
        if (collision.gameObject.name == "Rock1")
        {
            dirWalk.x = -dirWalk.x;
        }
        if (collision.gameObject.name == "Rock2")
        {
            dirWalk.x = -dirWalk.x;
        }
        if (collision.gameObject.name == "Rock3")
        {
            dirWalk.y = -dirWalk.y;
        }
        if (collision.gameObject.name == "Rock4")
        {
            dirWalk.y = -dirWalk.y;

        }
        if (collision.gameObject.name == "sphere" && collision.gameObject.tag != "bigRock")
        {
            dirNumb = ChooseDir();
            WalkRandDir(dirNumb);
        }
        if (collision.gameObject.name == "rock 1" || collision.gameObject.name == "rock 2" || collision.gameObject.name == "rock 3" || collision.gameObject.name == "rock 4" || collision.gameObject.tag == "bigRock")
        {
            dirWalk = -dirWalk;
        }
    }
}
