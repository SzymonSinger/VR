using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPositionRetriever : MonoBehaviour
{
    public Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPosition;
    }
    
}
