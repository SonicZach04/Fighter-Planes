using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    private int lives = 3;
    private int score = 0;
    private float horizontalInput;

    public GameObject bullet;

    private float screenHalfHeight;
    private float screenHalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;

        // Check if the camera exists
        if (Camera.main != null)
        {
            // Calculate the half height and half width of the screen in world units
            screenHalfHeight = Camera.main.orthographicSize; // Height of the camera in orthographic mode
            screenHalfWidth = Camera.main.aspect * screenHalfHeight; // Width based on the aspect ratio
        }
        else
        {
            Debug.LogError("Main Camera not found. Please ensure there is a camera tagged as 'MainCamera' in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Move the player
        transform.Translate(new Vector3(horizontalInput, 0, 0) * Time.deltaTime * speed);

        // Restrict the player's vertical position to the bottom half of the screen
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Clamp(newPosition.y, -screenHalfHeight - 1f, -0.5f); // Limit to slightly lower than the bottom half
        transform.position = newPosition;

        // Wrap around the screen horizontally
        if (transform.position.x > screenHalfWidth)
        {
            transform.position = new Vector3(-screenHalfWidth, transform.position.y, 0);
        }
        else if (transform.position.x < -screenHalfWidth)
        {
            transform.position = new Vector3(screenHalfWidth, transform.position.y, 0);
        }
    }

    void Shooting()
    {
        // If I press SPACE, create a bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a bullet
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
