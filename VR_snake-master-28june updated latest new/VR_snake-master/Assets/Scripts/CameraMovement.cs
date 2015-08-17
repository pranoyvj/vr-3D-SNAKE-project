using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public bool easyMode;
	public double RotationSensitivity = 50;
	public float CurrentX;
	public float CurrentY;
	public float CurrentZ;
	public float unity =1.0f;
	public bool rotateX;
	public bool rotateZ;
	public bool rotateY;

    // Use this for initialization
    void Start()
    {

    }
	IEnumerator wait(){
		yield return new WaitForSeconds(3);}
    // Update is called once per frame
	void Update()
    {	
		CurrentX = SpaceNavigator.Rotation.x * 1000 * unity;
		CurrentY = SpaceNavigator.Rotation.y * 1000 * unity;
		CurrentZ = SpaceNavigator.Rotation.z * 1000 * unity;

		if (!easyMode)//hard mode integrated!
		{	//for kezboard
			if (Input.GetKeyUp(KeyCode.UpArrow)) transform.Rotate(new Vector3(90, 0, 0));
			if (Input.GetKeyUp(KeyCode.DownArrow)) transform.Rotate(new Vector3(-90, 0, 0));
			if (Input.GetKeyUp(KeyCode.LeftArrow)) transform.Rotate(new Vector3(0, -90, 0));
			if (Input.GetKeyUp(KeyCode.RightArrow)) transform.Rotate(new Vector3(0, 90, 0));
			
			
			//the problem with spacenavigator was the rotation keeps happening if condition is satisfied. due to this flickering effect takes place!
			// if you want to navigate wrt users input , for simple mode..in this no need for separate navigation for external cube
			
		}else //easy mode
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
			//if (CurrentX > 480 && CurrentX < 480 + RotationSensitivity )
			if (CurrentX > 400 && CurrentX < 460 )
			{	transform.Rotate(new Vector3(90, 0, 0));
				wait();
			} 
			// to do if you can implement roll back action like in the case of keyboard input.
			if (CurrentX < -400 && CurrentX > -460 )
			{	transform.Rotate(new Vector3(-90, 0, 0));
				wait();	}
			
			if (CurrentY > 400 && CurrentY < 460 )
			{	transform.Rotate(new Vector3(0, 90, 0));
				wait();
			} 
			// to do if you can implement roll back action like in the case of keyboard input.
			if (CurrentY < -400 && CurrentY > -460 )
			{	transform.Rotate(new Vector3(0, -90, 0));
				wait();	}
			
			
		}

	}
}
    //todo:
    //task1, control by a velocity of cube, and long push button to keep on totation
    //task2, find the bug condition, display and solve it.
    //task3, simple mode and expert mode game play
    //task4, import some kind other control devices like game controller or yoyo or space mouse


