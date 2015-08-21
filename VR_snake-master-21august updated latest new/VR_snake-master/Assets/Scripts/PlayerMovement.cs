using UnityEngine;
using System.Collections;



public class PlayerMovement : MonoBehaviour
{

    //Membervariables
    public GameObject pickUp;
    public int pickUpCount =0; // number of collected pickUps
    public GameObject piece; // body of the snake
    public GameObject lastPiece;
	public GameObject newPiece ;
    public GameObject MenuText;
    public GameObject MenuPanel;
    public bool showHighscore =true;
    public bool gameover;
    private bool isMoving = false;
    public int speed = 1;
    public bool lookUp = false;
    public bool lookDown = false;
    public GameObject gameOver;
    public bool showMenu = true;
	public float  acc =  1.5f;
	public GameObject snakeBody;
    //Methods
    // Use this for initialization
    void Start()
    {
        MenuText = GameObject.FindGameObjectWithTag("MenuText");
        MenuPanel = GameObject.FindGameObjectWithTag("Panel");
        gameOver = GameObject.FindGameObjectWithTag("GameOver");
        gameOver.SetActive(false);
        showHighscore = true;
        int i = 0;
        while (i < 25)
        {
            placePickUps();
            i++;
        }
        pickUpCount = 0;
        lastPiece = gameObject;
        Debug.Log(lastPiece.name);
        Debug.Log(piece.name);

        //if (PlayerPrefs.GetInt("pickUpCount") < 1)
        //{
        //    PlayerPrefs.SetInt("pickUpCount", 1);
        //}

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            Application.LoadLevel(Application.loadedLevel);
        if (isMoving)
        {

			if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("buttonY")) && lookDown)
            {
                transform.Rotate(new Vector3(-90, 0, 0));
                lookDown = false;
            }

			else if ((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetButtonDown("buttonY")) && lookUp)
            {

                transform.Rotate(new Vector3(-90, 0, 0));
                transform.Rotate(new Vector3(0, 0, 180));
                lookUp = false;
            }

			else if ((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetButtonDown("buttonY")))
            {

                transform.Rotate(new Vector3(-90, 0, 0));
                lookUp = true;
            };

			if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetButtonDown("buttonA")) && lookUp)
            {
                transform.Rotate(new Vector3(90, 0, 0));
                lookUp = false;
            }
			else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetButtonDown("buttonA")) && lookDown)
            {

                transform.Rotate(new Vector3(90, 0, 0));
                transform.Rotate(new Vector3(0, 0, 180));
                lookUp = false;
            }
			else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetButtonDown("buttonA")))
            {
                transform.Rotate(new Vector3(90, 0, 0));
                lookDown = true;
            };

			if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("buttonX")) && lookUp)
            {
                transform.Rotate(new Vector3(90, 0, 0));
                transform.Rotate(new Vector3(0, -90, 0));
                lookUp = false;
            }
			else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("buttonX")) && lookDown)
            {
                transform.Rotate(new Vector3(-90, 0, 0));
                transform.Rotate(new Vector3(0, -90, 0));
                lookDown = false;
            }
			else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("buttonX")))
            {
                transform.Rotate(new Vector3(0, -90, 0));
            }

			if ((Input.GetKeyDown(KeyCode.RightArrow) ||Input.GetButtonDown("buttonB"))  && lookUp)
            {
                transform.Rotate(new Vector3(90, 0, 0));
                transform.Rotate(new Vector3(0, 90, 0));
                lookUp = false;
            }
			else if ((Input.GetKeyDown(KeyCode.RightArrow) ||Input.GetButtonDown("buttonB")) && lookDown)
            {
                transform.Rotate(new Vector3(-90, 0, 0));
                transform.Rotate(new Vector3(0, 90, 0));
                lookDown = false;
            }
			else if ((Input.GetKeyDown(KeyCode.RightArrow) ||Input.GetButtonDown("buttonB")))
            {
                transform.Rotate(new Vector3(0, 90, 0));
            }

        }
    }
    // Update is called once per frame
    void FixedUpdate()
	{
		//start
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("buttonStart")) && !isMoving)
        {
            isMoving = true;
        }
		//pause
		if ((Input.GetKeyDown(KeyCode.N) || Input.GetButtonDown("buttonBack"))&& isMoving){
			isMoving = false;
		}
        if (isMoving)
		{
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
			if (Input.GetKeyDown(KeyCode.P))
			{	acc +=2.0f;
				transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * acc*2.0f);

			}		
		}

    }


    void placePickUps()
    {
        Vector3 position = new Vector3(Random.Range(-29, 29), Random.Range(-29, 29), Random.Range(-29, 29));
        GameObject PickUp = Instantiate(pickUp, position, Quaternion.identity) as GameObject;
        PickUp.name = "pickUp";
    }

	void OnCollisionEnter(Collision coll)
	{ 
		 	
		if (coll.gameObject.name == "Piece" || coll.gameObject.name == "Wall") {
			Debug.Log ("Collision111 with pick up detected");
		}
		 // how to acces non gameobjects here??
	}

    void OnTriggerEnter(Collider col)
	{	//function OnCollisionEnter(collision : Collision) { if(collision.transform.tag == "Enemy" && !transform.collider.isTrigger){ transform.collider.isTrigger = true; } }

        if (col.gameObject.name == "pickUp")
        {
            Debug.Log("Collision with pick up detected");
            Destroy(col.gameObject);
            pickUpCount++;
            addPiece();

        }
        if (col.gameObject.name == "Piece" || col.gameObject.name == "Wall" || col.gameObject.name == "Cube" || col.gameObject.name == "Cube 1" || col.gameObject.name == "Cube 2")
        {

            Debug.Log("Collision with wall or piece detected");
            //Application.LoadLevel(Application.loadedLevel);

            gameover = true;
            isMoving = false;

        }
		if (col.gameObject.name == "Pieceandwall") {
			
		}
		//add collision condition for snake added objects/parts with the boundry wall of cube

	

    }
    void addPiece()
    {
        Vector3 pos = transform.position - (GetComponent<Rigidbody>().velocity * 500);
        newPiece = (GameObject)Instantiate(piece, pos, Quaternion.identity);
        newPiece.name = "Piece";

        Debug.Log("Last piece is:" + lastPiece);
        newPiece.GetComponent<SmoothFollow>().target = lastPiece.transform;
        lastPiece = newPiece;


    }
    void OnGUI()
    {
        GUI.color = Color.white;
        GUIStyle customButton = new GUIStyle("button");
        customButton.fontSize = 25;
        if (showMenu)
        {
            // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
            if (GUI.Button(new Rect(840, 450, 400, 50), "Integrated Control Mode",customButton))
            {
                GameObject.FindGameObjectWithTag("CameraInput").GetComponent<CameraMovement>().easyMode = false;
                showMenu = false;
                MenuText.SetActive(false);
                MenuPanel.SetActive(false);
            }

            // Make the second button.
            if (GUI.Button(new Rect(840, 530, 400, 50), "Differential Control Mode",customButton))
            {
                GameObject.FindGameObjectWithTag("CameraInput").GetComponent<CameraMovement>().easyMode = true;
                showMenu = false;
                MenuText.SetActive(false);
                MenuPanel.SetActive(false);
            }
            //GameObject.FindGameObjectWithTag("MenuText")
        }
        //}

        if (!isMoving && gameover == false)
        {
            if (!showMenu)
            {
                GUI.Label(new Rect(800, 200, 300, 600), "Press Space to Start");
                //GUILayout.Label("Press Space to Start".ToString());
            }

        }
        if (!isMoving && gameover == true)
        {
            //Time.timeScale = 0; 
            pickUpCount = 0;
            gameOver.SetActive(true);
        }
        // if (showHighscore && GUILayout.Button("Hide Highscore"))
        //{
          //  showHighscore = false;
			//GUILayout.Label(" " + (double)SpaceNavigator.Rotation.x*1000);
			//GUILayout.Label(" " + (double)SpaceNavigator.Rotation.y*1000);
			//GUILayout.Label(" " + (double)SpaceNavigator.Rotation.z*1000);
        //}

		if (isMoving) { //if user gets all the food points!
			if (pickUpCount==25)
			{
				GUI.Label(new Rect(600, 200, 300, 600), "Congratulations !! you won !!");
				gameover = true;
			}
		}
        if (showHighscore)
		{	//GUILayout.Label("Pick Ups: " + PlayerPrefs.GetInt("pickUp"));


			GUILayout.Label("Pick Ups: " + pickUpCount);
			GUILayout.Label(" " + (double)SpaceNavigator.Rotation.x*1000);
			GUILayout.Label(" " + (double)SpaceNavigator.Rotation.y*1000);
			GUILayout.Label(" " + (double)SpaceNavigator.Rotation.z*1000);

			//
			GUILayout.Label(" " + Input.GetAxis("joyx")*1000);
			GUILayout.Label(" " + Input.GetAxis("joyy")*1000);
        }

    }

}
