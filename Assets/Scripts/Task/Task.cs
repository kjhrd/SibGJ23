using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public int targetCount;
    public bool isPlayerControllable;
    public bool isPoinntNClick;
    public bool isClicker;
    public bool active = true;
    public GameObject cam;
    public GameObject player;
    public List<GameObject> targets = new List<GameObject>();

    void Update()
    {
        if (active)
        {
            if (isPlayerControllable) 
            {

            }
            else if (isPoinntNClick)
            {

            }
            else if (isClicker)
            {

            }
        }
    }
}
