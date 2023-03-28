using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombSettingBehaviour : MonoBehaviour
{
    public GameObject bomb;

    public GameObject bombToControl;

    public float spawnBombAtThisYPosition;
    public bool canSpawnBombs;
    public bool toggleBombs;

    private GameplayGameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameplayGameController>();

        if (gc.currentRunner == 1)
        {
            if (PlayerPrefs.GetInt("Player2Points") > 0)
            {
                canSpawnBombs = true;
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("Player1Points") > 0)
            {
                canSpawnBombs = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && canSpawnBombs)
        {
            bombToControl = Instantiate(bomb);

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mousePosition.y / Screen.height - 0.5f;
            mousePosition.y = spawnBombAtThisYPosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.y = 0f;

            bombToControl.transform.position = worldPosition;
        }

        if (gc.currentRunner == 1)
        {
            if (PlayerPrefs.GetInt("Player2Points") > 0 && bombToControl != null)
            {
                canSpawnBombs = bombToControl.GetComponent<bombBehaviour>().bombHasBeenPlaced;
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("Player1Points") > 0 && bombToControl != null)
            {
                canSpawnBombs = bombToControl.GetComponent<bombBehaviour>().bombHasBeenPlaced;
            }
        }
    }
}
