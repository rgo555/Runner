using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.A))
        {
            switch (transform.position.x)
            {
                case 0f:
                    transform.position = new Vector3(-2, transform.position.y, transform.position.z);
                break;
                case 2:
                    transform.position = new Vector3(0, transform.position.y, transform.position.z);
                break;
            }
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            switch (transform.position.x)
            {
                case 0f:
                    transform.position = new Vector3(2, transform.position.y, transform.position.z);
                break;
                case -2:
                    transform.position = new Vector3(0, transform.position.y, transform.position.z);
                break;
            }
        }
    }
}
