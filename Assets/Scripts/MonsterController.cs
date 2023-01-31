using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MonsterController : MonoBehaviour
{
    private Vector3 side1;
    private Vector3 side2;
    private Vector3 pos;
    private float time;
    private float maxTime;
    private float lengthF;
    private bool dirA;
    private bool dirB;
    void Start()
    {
        maxTime = Random.Range(3, 5);
        lengthF = 2;
        side1 = transform.position + new Vector3(lengthF, 0, lengthF);
        side2 = transform.position + new Vector3(-lengthF, 0 - lengthF);
        dirA = true;
        dirB = true;
    }
 
    void Update()
    {
        Move();
    }
    Vector3 RandV3(Vector3 a,Vector3 b)
    {
        return new Vector3(Random.Range(a.x,b.x),a.y,Random.Range(a.z,b.z));
    }

    void Move()
    {
        if (dirA)
        {
            if (dirB)
            {
                dirB = false;
                pos = RandV3(side1, side2);
                transform.LookAt(pos);
            }
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime);
            if (transform.position == pos)
            {
                dirA = false;
                maxTime = Random.Range(3, 5);
            }
        }
        else
        {
            time += Time.deltaTime;
        }
 
        if (time >= maxTime)
        {
            time = 0;
            dirA = true;
            dirB = true;
        }
    }
}
