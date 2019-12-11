using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField]
    private float timer = 6;
    private float curTime =0;
    [SerializeField]
    private GameObject bullet;
    private bool noShoot = false;
    private Vector3 bulletDir = new Vector3(0, 1, 0);
    private GameObject player;
    private int rand;
    private Transform target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        rand = Random.Range(0, 100);
        if (curTime >= timer)
        {
            curTime = timer;
        }
        if (curTime < timer)
        {
            curTime += 1 * Time.deltaTime;
        }
        if (curTime >= timer)
        {

            Debug.Log(rand);
            if (rand == 5)
            {
                GameObject obj = Instantiate(bullet, transform.position, Quaternion.identity);
                curTime = 0;
                targetPos = player.transform.position;
                thisPos = transform.position;
                targetPos.x = targetPos.x - thisPos.x;
                targetPos.y = targetPos.y - thisPos.y;
                angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
                obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                
            }
        }
    }
}
