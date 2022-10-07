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
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.A))
        {
            switch (transform.position.z)
            {
                case 0f:
                    transform.position = new Vector3(transform.position.x, transform.position.y, -2);
                break;
                case 2:
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                break;
            }
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            switch (transform.position.z)
            {
                case 0f:
                    transform.position = new Vector3(transform.position.x, transform.position.y, 2);
                break;
                case -2:
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                break;
            }
        }
    }
}
