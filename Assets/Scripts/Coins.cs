using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private float speed = 100f;

    private void OnTriggerEnter(Collider collision)
    {        
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.AddCoins();

            Destroy(gameObject);
        }
        
    }

    
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 1, 0)* Time.deltaTime * speed;
    }

}
