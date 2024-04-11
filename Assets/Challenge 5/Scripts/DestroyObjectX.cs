using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        Destroy(gameObject, 5 * Time.deltaTime); // destroy particle after 2 seconds
    }

}
