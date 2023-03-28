using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombBehaviour : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float zMovementMultiplier = 0.5f;
    public float zMovementMin;
    public float zMovementMax;

    public bool bombHasBeenPlaced;

    public float timeUntilExplosion;

    public GameObject explosionItself;

    private Vector3 lastMousePosition;

    private void Start()
    {
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

        if(Input.GetMouseButtonDown(1))
        {
            bombHasBeenPlaced = true;
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