using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;
	Vector3 dir=Vector3.forward;
	Vector3 playervelocity;
	bool canmove=true;
	int line=1;
	int targetLine=1;
	public float speed = 10;
	public float sensorradius = 0.1f;
	
	public float jumpforce = 20;
    public float jumpheight = 1;
    public float gravity = -9.81f;
	public Transform groundSensor;
    public LayerMask ground;
	public bool isGrounded;

	void Start() 
	{
		controller = gameObject.GetComponent<CharacterController> ();
	}

	void Update() 
	{
		Movement();
		Jump();
	}

	void Movement()
	{
		Vector3 pos=gameObject.transform.position;
		if(!line.Equals(targetLine)){
			if(targetLine==0 && pos.x<-2){
				gameObject.transform.position = new Vector3 (-2f,pos.y,pos.z);
				line = targetLine;
				dir.x = 0;
				canmove = true;
			}else if(targetLine==1 &&  (pos.x>0 ||  pos.x<0)){
				if(line==0 && pos.x>0){
					gameObject.transform.position = new Vector3 (0,pos.y,pos.z);
					line = targetLine;
					dir.x = 0;
					canmove = true;
				}else if(line==2 && pos.x<0){
					gameObject.transform.position = new Vector3 (0,pos.y,pos.z);
					line = targetLine;
					dir.x = 0;
					canmove = true;
				}
			}else if(targetLine==2 &&  pos.x>2){
				gameObject.transform.position = new Vector3 (-2,pos.y,pos.z);
				line = targetLine;
				dir.x = 0;
				canmove = true;
			}
		}
		checkInputs ();
		if (!controller.isGrounded) {
			dir.y = -4;
		}
		controller.Move (new Vector3(dir.x, 0, dir.z * speed) * Time.deltaTime);
	}

	void checkInputs()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow) && canmove && line>0 ){
			
			MoveLeft();
		}
		if(Input.GetKeyDown(KeyCode.RightArrow) && canmove && line<2){

			MoveRight();
		}	
	}

    void MoveLeft()
	{
		targetLine--;
		canmove = false;
		dir.x = -4f;
	}

	void MoveRight()
	{
		targetLine++;
		canmove = false;
		dir.x = 4f;
	}

	void Jump()
	{
		isGrounded = Physics.CheckSphere(groundSensor.position, sensorradius, ground);
        if(isGrounded && dir.y < 0){
            playervelocity.y = 0;

        }

        if(Input.GetButtonDown("Jump") && isGrounded)
		{
            playervelocity.y += Mathf.Sqrt(jumpheight * -2.0f * gravity);

        }
        playervelocity.y += gravity * Time.deltaTime;
        controller.Move(playervelocity* Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("FinishLine"))
        {
            GameManager.Instance.LevelFinisher();
        }

        //Layer de obstaculos
        if(other.gameObject.layer == 7)
        {
            
            GameManager.Instance.Choque();
        }
    }
}
