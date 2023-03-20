using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombSettingBehaviour : MonoBehaviour
{
    public Vector3 mousePos;
    public GameObject bomb;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 2.0f;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(bomb, objectPos, Quaternion.identity);
        }
    }
}
