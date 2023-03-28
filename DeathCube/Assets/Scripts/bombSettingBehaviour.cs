using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombSettingBehaviour : MonoBehaviour
{
    public GameObject bomb;

    public GameObject bombToControl;

    public float spawnBombAtThisYPosition;
    public bool canSpawnBombs;

    private void Start()
    {
        canSpawnBombs = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canSpawnBombs)
        {
            bombToControl = Instantiate(bomb);

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f;
            mousePosition.y = spawnBombAtThisYPosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.y += 3.18f;

            bombToControl.transform.position = worldPosition;
        }

        if(bombToControl != null)
        {
            canSpawnBombs = bombToControl.GetComponent<bombBehaviour>().bombHasBeenPlaced;
        }

        /*
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // Set the Z position of the prefab
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            spawnParent.transform.position = worldPosition;
        */
    }
}
