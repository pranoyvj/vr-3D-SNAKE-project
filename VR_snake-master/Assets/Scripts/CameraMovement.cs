using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public bool easyMode;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!easyMode)
        {
            if (Input.GetKeyUp(KeyCode.W)) transform.Rotate(new Vector3(-90, 0, 0));
            if (Input.GetKeyUp(KeyCode.S)) transform.Rotate(new Vector3(90, 0, 0));
            if (Input.GetKeyUp(KeyCode.A)) transform.Rotate(new Vector3(0, -90, 0));
            if (Input.GetKeyUp(KeyCode.D)) transform.Rotate(new Vector3(0, 90, 0));
        }
        // if you want to navigate wrt users input , for simple mode..in this no need for separate navigation for external cube

        else
        {
            if (Input.GetKeyUp(KeyCode.UpArrow)) transform.Rotate(new Vector3(90, 0, 0));
            if (Input.GetKeyUp(KeyCode.DownArrow)) transform.Rotate(new Vector3(-90, 0, 0));
            if (Input.GetKeyUp(KeyCode.LeftArrow)) transform.Rotate(new Vector3(0, 90, 0));
            if (Input.GetKeyUp(KeyCode.RightArrow)) transform.Rotate(new Vector3(0, -90, 0));
        }
    }


    //todo:
    //task1, control by a velocity of cube, and long push button to keep on totation
    //task2, find the bug condition, display and solve it.
    //task3, simple mode and expert mode game play
    //task4, import some kind other control devices like game controller or yoyo or space mouse


}
