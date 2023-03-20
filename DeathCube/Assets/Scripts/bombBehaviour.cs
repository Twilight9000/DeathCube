using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombBehaviour : MonoBehaviour
{
    public bool isBombUnderMouseControl;
    public Vector3 bombPos;
    public float mouseWheelScrollSpeed;

    private void Awake()
    {
        //bombPos.x = transform.position.x;
        //bombPos.y = transform.position.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        isBombUnderMouseControl = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBombUnderMouseControl)
        {
            bombPos.z += Input.mouseScrollDelta.y * mouseWheelScrollSpeed;
            transform.position = bombPos;
        }

        if(Input.GetMouseButtonDown(1))
        {
            isBombUnderMouseControl = false;
        }
    }
}
