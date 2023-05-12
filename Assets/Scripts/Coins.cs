using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private float speed = 100f;

    public GameObject particleEffect;

    private void OnTriggerEnter(Collider collision)
    {        
        if (collision.gameObject.tag == "Player")
        {
            SFXManager.Instance.CoinSFX();

            GameManager.Instance.AddCoins();

            Instantiate(particleEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
        
    }

    
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 1, 0)* Time.deltaTime * speed;
    }

}