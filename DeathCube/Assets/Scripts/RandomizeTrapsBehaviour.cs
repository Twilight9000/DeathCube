using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizeTrapsBehaviour : MonoBehaviour
{

    public List<GameObject> allTrapsButtons = new List<GameObject>();

    public List<Vector3> placements = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 6; i++)
        {         

            GameObject g = Instantiate(allTrapsButtons[Random.Range(0, allTrapsButtons.Count)], transform);


            g.transform.localPosition = placements[i];

            g.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(g));

            int num;

            if (g.name.Contains("Saw"))
            {
                num = 0;
                g.GetComponent<Button>().onClick.AddListener(() => thing(num));
            }
            else if (g.name.Contains("Axe"))
            {
                num = 1;
                g.GetComponent<Button>().onClick.AddListener(() => thing(num));
            }
            else if (g.name.Contains("Spikes"))
            {
                num = 2;
                g.GetComponent<Button>().onClick.AddListener(() => thing(num));
            }
            else if (g.name.Contains("Minion"))
            {
                num = 3;
                g.GetComponent<Button>().onClick.AddListener(() => thing(num));
            }
            else if (g.name.Contains("Hammer"))
            {
                num = 4;
                g.GetComponent<Button>().onClick.AddListener(() => thing(num));
            }
            else if (g.name.Contains("Pitfall"))
            {
                num = 5;
                g.GetComponent<Button>().onClick.AddListener(() => thing(num));
            }
            else if (g.name.Contains("Fly"))
            {
                num = 6;
                g.GetComponent<Button>().onClick.AddListener(() => thing(num));
            }
            else if (g.name.Contains("Gun"))
            {
                num = 7;
                g.GetComponent<Button>().onClick.AddListener(() => thing(num));
            }
        }

    }

    public void ButtonClicked(GameObject g)
    {

        gameObject.SetActive(false);

    }

    public void thing(int num)
    {

        FindObjectOfType<PlacingTrapBehavior>().gameObject.GetComponent<PlacingTrapBehavior>().PlaceTrap(num);
        Debug.Log("tada!");
    }
}
