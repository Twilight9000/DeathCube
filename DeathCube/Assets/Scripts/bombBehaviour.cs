using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombBehaviour : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float xMovementMin;
    public float xMovementMax;

    public float zMovementMultiplier = 0.5f;
    public float zMovementMin;
    public float zMovementMax;

    public bool bombHasBeenPlaced;

    public float timeUntilExplosion;

    public GameObject explosionItself;

    private Vector3 lastMousePosition;
    private GameplayGameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameplayGameController>();

        lastMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        if(!bombHasBeenPlaced)
        {
            // Get the current mouse position and the scroll wheel value
            Vector3 mousePosition = Input.mousePosition;

            // Calculate the movement in each axis based on the change in mouse position and scroll wheel value
            float xMovement = (mousePosition.x - lastMousePosition.x) * moveSpeed * Time.deltaTime;
            float zMovement = (mousePosition.y / Screen.height - 0.5f) * zMovementMultiplier; //This is the line that is causing problems

            // Update the position of the object with the calculated movement
            Vector3 position = transform.position;
            position.x += xMovement;
            if(position.x <= xMovementMin)
            {
                position.x = xMovementMin;
            } else if (position.x >= xMovementMax)
            {
                position.x = xMovementMax;
            }

            position.z += zMovement;
            if (position.z <= zMovementMin)
            {
                position.z = zMovementMin;
            }
            else if (position.z >= zMovementMax)
            {
                position.z = zMovementMax;
            }
            transform.position = position;

            // Record the current mouse position for the next frame
            lastMousePosition = mousePosition;
        }

        if(Input.GetMouseButtonDown(0))
        {
            bombHasBeenPlaced = true;
            if(gc.currentRunner == 1)
            {
                PlayerPrefs.SetInt("Player2Points", PlayerPrefs.GetInt("Player2Points") - 1);
            } else
            {
                PlayerPrefs.SetInt("Player1Points", PlayerPrefs.GetInt("Player1Points") - 1);
            }
        }

        if(bombHasBeenPlaced)
        {
            timeUntilExplosion -= Time.deltaTime;
            if(timeUntilExplosion <= 0)
            {
                Instantiate(explosionItself, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}