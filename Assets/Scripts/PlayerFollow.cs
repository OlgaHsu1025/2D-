using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    // Start is called before the first frame update
   
    [SerializeField] Transform boytransform;
    [SerializeField] float speedScale= 1;

    Vector3 lastPosition;
    void Start()
    {
        lastPosition = boytransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currPosition = boytransform.position;
        Vector3 delta = currPosition - lastPosition;
        transform.Translate(delta.x *speedScale , 0 , 0);
        lastPosition = currPosition;

    }
   
    
}
