using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour

{
    private LineRenderer lineRenderer;
    Transform start;
    Transform end;
    Vector3 vStart;
    Vector3 vEnd;

    private void Start()
    {
        vStart = start.position;
        vEnd = end.position;

        lineRenderer = GetComponent<LineRenderer>();
        //lineRenderer.Set

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
