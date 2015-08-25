using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	public bool easyMode;
	public double RotationSensitivity = 50;
	public float CurrentX;
	public float CurrentY;
	public float CurrentZ;
	public bool rotateX;
	public bool rotateZ;
	public bool rotateY;
	
	public float X360;
	public float Y360;
	private float movementSpeed = 1000;
	
	// Use this for initialization
	void Start()
	{
		
	}
	IEnumerator wait(){
		yield return new WaitForSeconds(3);}
	// Update is called once per frame
	void Update()
	{	
		CurrentX = SpaceNavigator.Rotation.x   ;
		CurrentY = SpaceNavigator.Rotation.y   ;
		CurrentZ = SpaceNavigator.Rotation.z   ;
		
		
		X360 = Input.GetAxis("joyx") ;
		Y360 = Input.GetAxis("joyy") ;
		
		if (!easyMode)// mode integrated!
		{	//for kezboard
			if (Input.GetKeyUp(KeyCode.UpArrow)) transform.Rotate(new Vector3(-90, 0, 0));
			if (Input.GetKeyUp(KeyCode.DownArrow)) transform.Rotate(new Vector3(90, 0, 0));
			if (Input.GetKeyUp(KeyCode.LeftArrow)) transform.Rotate(new Vector3(0, -90, 0));
			if (Input.GetKeyUp(KeyCode.RightArrow)) transform.Rotate(new Vector3(0, 90, 0));
			//for xbox
			if(Input.GetButtonDown("buttonY" )) transform.Rotate(new Vector3(-90, 0, 0));
			if(Input.GetButtonDown("buttonA"))  transform.Rotate(new Vector3(90, 0, 0));
			if(Input.GetButtonDown("buttonX")) transform.Rotate(new Vector3(0, -90, 0));
			if(Input.GetButtonDown("buttonB")) transform.Rotate(new Vector3(0, 90, 0));
			
			
			//the problem with spacenavigator was the rotation keeps happening if condition is satisfied. due to this flickering effect takes place!
			// if you want to navigate wrt users input , for simple mode..in this no need for separate navigation for external cube
			
		}else // differential mode   
		{  
			if (Input.GetKeyDown(KeyCode.Keypad8))
			{transform.Rotate(new Vector3(90, 0, 0));
			}
			if (Input.GetKeyUp(KeyCode.Keypad8))
			{transform.Rotate(new Vector3(-90, 0, 0));
			}
			
			if (Input.GetKeyDown(KeyCode.Keypad2)) 
			{transform.Rotate(new Vector3(-90, 0, 0));
			}
			if (Input.GetKeyUp(KeyCode.Keypad2)) 
			{transform.Rotate(new Vector3(90, 0, 0));
			}
			
			if (Input.GetKeyDown(KeyCode.Keypad4)) {
				transform.Rotate(new Vector3(0, 90, 0));
			}
			if (Input.GetKeyUp(KeyCode.Keypad4)) {
				transform.Rotate(new Vector3(0, -90, 0));}
			
			if (Input.GetKeyDown(KeyCode.Keypad6)) 
			{transform.Rotate(new Vector3(0, -90, 0));
			}
			if (Input.GetKeyUp(KeyCode.Keypad6)) 
			{transform.Rotate(new Vector3(0, 90, 0));}
			
			//for spacemouse
			
			//			if (CurrentX > 400 && CurrentX < 460 )
			//			{	transform.Rotate(new Vector3(90, 0, 0));
			//				wait();
			//			} 
			//			// to do if you can implement roll back action like in the case of keyboard input.
			//			if (CurrentX < -400 && CurrentX > -460 )
			//			{	transform.Rotate(new Vector3(-90, 0, 0));
			//				wait();	}
			//			
			//			if (CurrentY > 400 && CurrentY < 460 )
			//			{	transform.Rotate(new Vector3(0, 90, 0));
			//				wait();
			//			} 
			//			// to do if you can implement roll back action like in the case of keyboard input.
			//			if (CurrentY < -400 && CurrentY > -460 )
			//			{	transform.Rotate(new Vector3(0, -90, 0));
			//				wait();	}
			if( CurrentX != 0 ||  CurrentY != 0  )
				transform.eulerAngles = new Vector3(CurrentX*90,CurrentY*90,0);
			
			//			if (X360 > 500 && X360 < 660)
			//			{transform.Rotate(new Vector3(0, -90, 0));
			//				wait();
			//			}
			//			if (X360 < -500 && X360 > -660 )
			//			{	transform.Rotate(new Vector3(0, 90, 0));
			//				wait();	}
			//
			//			if (Y360 > 500 && Y360 < 660)
			//			{transform.Rotate(new Vector3(-90, 0, 0));
			//				wait();
			//			}
			//			if (Y360 < -500 && Y360 > -660)
			//			{transform.Rotate(new Vector3(90, 0, 0));
			//				wait();
			//			}
			// new for xbox controller
			if( X360 != 0 ||  Y360 != 0  )
				transform.eulerAngles = new Vector3(-Y360*90,-X360*90,0);
		}
		
	}
}
//todo:
//task1, control by a velocity of cube, and long push button to keep on totation
//task2, find the bug condition, display and solve it.
//task3, simple mode and expert mode game play
//task4, import some kind other control devices like game controller or yoyo or space mouse

