using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] hookBases;

    public int ballCount;
    public int goalObjectCount;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {

                if (hit.collider.CompareTag("base_1"))
                {
                    setRopes(hit, "base_1");
                }
                else if (hit.collider.CompareTag("base_2"))
                {
                    setRopes(hit, "base_2");
                }
                else if (hit.collider.CompareTag("base_3"))
                {
                    setRopes(hit, "base_3");
                }
                else if (hit.collider.CompareTag("base_4"))
                {
                    setRopes(hit, "base_4");
                }
                else if (hit.collider.CompareTag("base_5"))
                {
                    setRopes(hit, "base_5");
                }
            }
        }
    }

    void setRopes(RaycastHit2D hit,string hingeName)
    {

        hit.collider.gameObject.SetActive(false);
        foreach(var item in hookBases)
        {
            if(item.GetComponent<ropeController>().hingeName == hingeName)
            {
                foreach(var item2 in item.GetComponent<ropeController>().ropePool)
                {
                    item2.SetActive(false);
                }
            }
        }
    }

    public void MinusBall()
    {
        ballCount--;
        if(ballCount == 0)
        {
            if(goalObjectCount > 0)
            {

            }else if (goalObjectCount == 0)
            {

            }
        }
        else
        {
            if(goalObjectCount == 0)
            {

            }
        }
    }
    public void MinusObject()
    {
        goalObjectCount--;
        if (ballCount == 0 && goalObjectCount == 0)
        {

        }
        else if (ballCount == 0 && goalObjectCount > 0)
        {

        }
    }

}
