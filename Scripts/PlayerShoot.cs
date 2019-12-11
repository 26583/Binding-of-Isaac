using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private float timer = 2;
    private float curTime;
    [SerializeField]
    private GameObject bullet;
    private bool noShoot = false;
    private Vector3 bulletDir = new Vector3(0, 1, 0);

    private void Start()
    {
        curTime = timer;
    }


    void Update()
    {
        /*if(Input.GetKey(KeyCode.W)&& !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            bulletDir = new Vector3(0, 1, 0);
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            bulletDir = new Vector3(1, 0, 0);
        }
        if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            bulletDir = new Vector3(-1, 0, 0);
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            bulletDir = new Vector3(0, -1, 0);
        }*/
        if (Input.GetKey(KeyCode.UpArrow))
        {
            bulletDir = new Vector3(0, 1, 0);
            Shoot();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            bulletDir = new Vector3(1, 0, 0);
            Shoot();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            bulletDir = new Vector3(-1, 0, 0);
            Shoot();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            bulletDir = new Vector3(0, -1, 0);
            Shoot();
        }
        if (curTime >= timer)
        {
            curTime = timer;
        }
        else if(curTime < timer)
        {
            curTime += 1 * Time.deltaTime;
        }
        /*private void Shoot (Input.GetKeyDown(KeyCode.Space) && curTime >= timer)
        {
            GameObject obj = Instantiate(bullet, transform.position, Quaternion.identity);
            obj.GetComponent<Bullet>().setDir(bulletDir);
            curTime = 0;
        }*/
        void Shoot() {
            if (curTime >= timer)
            {
                GameObject obj = Instantiate(bullet, transform.position, Quaternion.identity);
                obj.GetComponent<Bullet>().setDir(bulletDir);
                curTime = 0;
            }
        }
    }
}
