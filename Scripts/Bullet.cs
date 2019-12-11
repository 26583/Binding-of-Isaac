using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timer = 1;
    private Vector3 direction = new Vector3(0,1,0);
    private Vector3 mov;
    [SerializeField]
    private GameObject bulletExplode;

    private void Start()
    {
        mov = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);

        direction += mov /2;
    }

    void Update()
    {

        transform.position += direction * 8 * Time.deltaTime;
        //transform.position += mov * 3 * Time.deltaTime;
        timer -= 1 * Time.deltaTime;
        if(timer <= 0)
        {
            bulletDestroy();
        }
    }
    
    public void setDir(Vector3 dir)
    {

        direction = dir;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            bulletDestroy();
        }
        if (collision.gameObject.tag == "bigRock" || collision.gameObject.tag == "wall")
        {
            bulletDestroy();
        }
    }
    private void bulletDestroy()
    {
        GameObject bullet = Instantiate(bulletExplode);
        bullet.transform.position = transform.position + new Vector3(0.1f, 0.1f, 0);
        Destroy(gameObject);
    }
}
