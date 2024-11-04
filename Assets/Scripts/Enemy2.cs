using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(5*direction,-1,0) * Time.deltaTime * 3f);

        if (transform.position.x >= 11.5f || transform.position.x <= -11.5f)
        {
            direction *= -1;
        }
    }
}
