using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 29, 46) * Time.deltaTime);
    }
}