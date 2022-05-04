using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;

    public float speed = 10.0f;

    public Vector2 turn;

    private float mapRangeX = 245.0f;
    private float mapRangeZ = 245.0f;
    private float lookRangeY = 45.0f;

    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.gameActive)
        {
            //basic movement input, wasd
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

            //mouse input for rotation
            turn.x += Input.GetAxis("Mouse X");
            turn.y += Input.GetAxis("Mouse Y");
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

            //making sure player can't move through the ground
            transform.position = new Vector3(transform.position.x, 3, transform.position.z);


            //invisable barriers to keep player in bounds
            if (transform.position.x < -mapRangeX)
            {
                transform.position = new Vector3(-mapRangeX, transform.position.y, transform.position.z);
            }
            if (transform.position.x > mapRangeX)
            {
                transform.position = new Vector3(mapRangeX, transform.position.y, transform.position.z);
            }
            if (transform.position.z < -mapRangeZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -mapRangeZ);
            }
            if (transform.position.z > mapRangeZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, mapRangeZ);
            }

            //Make sure player can't look through themselves
            if (turn.y < -lookRangeY)
            {
                transform.localRotation = Quaternion.Euler(lookRangeY, turn.x, 0);
            }
            if (turn.y > lookRangeY)
            {
                transform.localRotation = Quaternion.Euler(-lookRangeY, turn.x, 0);
            }
        }
    }

}
