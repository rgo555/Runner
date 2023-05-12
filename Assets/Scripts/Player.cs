using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    CharacterController controller;
	Animator anim;
	Vector3 dir=Vector3.forward;
	[SerializeField]Vector3 playervelocity;
	bool canmove=true;
	int line=1;
	int targetLine=1;
	[SerializeField]private float speed = 10;
	
    [SerializeField]private float jumpheight = 1;
    [SerializeField]private float gravity = -9.81f;
	[SerializeField]private Transform groundSensor;
    [SerializeField]private LayerMask ground;
	[SerializeField]private float sensorRadius = 0.1f;
	[SerializeField]private bool isGrounded;

	public GameObject particleEffect;

	void Start() 
	{
		controller = gameObject.GetComponent<CharacterController> ();
		anim = GetComponentInChildren<Animator>();
	}

	void Update() 
	{
		if(GameManager.Instance.isPlaying)
		{
			Movement();
			Gravity();
			anim.SetBool("Correr",true);
		}
	}

	void Movement()
	{
		Vector3 pos=gameObject.transform.position;
		if(!line.Equals(targetLine))
		{
			if(targetLine==0 && pos.x<-2)
			{
				gameObject.transform.position = new Vector3 (-2f,pos.y,pos.z);
				line = targetLine;
				dir.x = 0;
				canmove = true;
			}
			else if(targetLine==1 &&  (pos.x>0 ||  pos.x<0))
			{
				if(line==0 && pos.x>0)
				{
					gameObject.transform.position = new Vector3 (0,pos.y,pos.z);
					line = targetLine;
					dir.x = 0;
					canmove = true;
				}
				else if(line==2 && pos.x<0)
				{
					gameObject.transform.position = new Vector3 (0,pos.y,pos.z);
					line = targetLine;
					dir.x = 0;
					canmove = true;
				}
			}
			else if(targetLine==2 &&  pos.x>2)
			{
				gameObject.transform.position = new Vector3 (-2,pos.y,pos.z);
				line = targetLine;
				dir.x = 0;
				canmove = true;
			}
		}
		checkInputs ();
		if (!controller.isGrounded) 
		{
			dir.y = -4;
		}
		controller.Move (new Vector3(dir.x, 0, dir.z * speed) * Time.deltaTime);
	}

	void checkInputs()
	{

		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			
			MoveLeft();
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){

			MoveRight();
		}	
	}

    public void MoveLeft()
	{
		if(canmove && line>0)
		{
			targetLine--;
			canmove = false;
			dir.x = -4f;
		}
	}

	public void MoveRight()
	{
		if(canmove && line<2)
		{
			targetLine++;
			canmove = false;
			dir.x = 4f;
		}
	}

	void Gravity()
	{
		isGrounded = Physics.CheckSphere(groundSensor.position, sensorRadius, ground);

        if(isGrounded && dir.y < 0)
		{
           playervelocity.y = 0;	
		   anim.SetBool("Jump",false);	   
        }

		

        if(Input.GetButtonDown("Jump"))
		{
            Jump();
        }


		if(!isGrounded)
		{
			playervelocity.y += gravity * Time.deltaTime;
		}
		
        controller.Move(playervelocity* Time.deltaTime);
	}

	public void Jump()
	{
		if(isGrounded)
		{
			playervelocity.y += Mathf.Sqrt(jumpheight * -2.0f * gravity);
			anim.SetBool("Jump", true);
			Debug.Log("You have clicked the button!");
			controller.Move(playervelocity* Time.deltaTime);
		}
	}

    private void OnTriggerEnter(Collider other) 
    {
        //Layer de obstaculos
        if(other.gameObject.layer == 7)
        {
            GameManager.Instance.Choque();
			//SFXManager.Instance.HitSFX();
			Instantiate(particleEffect, transform.position, Quaternion.identity);
			if(Global.vidas == 0)
			{
				anim.SetTrigger("Dead");
			}
        }
		if(other.gameObject.CompareTag("Finish"))
        {
			GameManager.Instance.isPlaying = false;
		
			
				
			GameManager.Instance.LevelFinisher();
		


        }
    }

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(groundSensor.position, sensorRadius);
	}
}
