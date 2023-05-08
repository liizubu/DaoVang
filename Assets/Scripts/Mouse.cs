using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : Rod
{
    // 
    Vector3 start;
    Vector3 end;
    [SerializeField]private int _speed;
     void Start()
    {   
        //start lech trai 4dv
        //end lech phai 4dv
        start = transform.position;
        start += Vector3.left *3;
        end = transform.position;
        end += Vector3.right *3;
    }


    // Update is called once per frame
    void Update()
    {
        if(check(start) ||  check(end))
        
            _speed *= -1;
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        
    }
    private bool check(Vector3 point)
    {
        return Mathf.Round(point.x) == Mathf.Round(transform.position.x);
    }
}
