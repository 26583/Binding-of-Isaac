using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private float timer = 1;
    private Vector3 direction = new Vector3(1, 0, 0);
    [SerializeField]
    private GameObject bulletExplode;

    void Update()
    {
        
        transform.position += transform.right * 8 * Time.deltaTime;
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void setDir(Vector3 dir)
    {
        direction = dir;
        direction.Normalize();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == /*"Player"*/Constants.playerTag.ToString())
        {
            Debug.Log("hitPlayer");
            collision.gameObject.GetComponent<PlayerDamage>().Damage();
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
        bullet.transform.position = transform.position + new Vector3(0.2f, 0.1f, 0);
        Destroy(gameObject);
    }
}
