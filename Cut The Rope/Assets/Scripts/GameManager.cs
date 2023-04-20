using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] hookBases;
    public GameObject cutEffect;

    public int ballCount;
    public int goalObjectCount;

    [SerializeField] private GameObject winPanel, losePanel; 

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
        Instantiate(cutEffect, hit.collider.gameObject.transform.position, Quaternion.identity);
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
                StartCoroutine(GameControl());
            }
            else if (goalObjectCount == 0)
            {

                StartCoroutine(GameResult(true, 0));
            }
        }
        else
        {
            if(goalObjectCount == 0)
            {
                StartCoroutine(GameResult(true, 0));
            }
        }
    }
    public void MinusObject()
    {
        goalObjectCount--;
        if (ballCount == 0 && goalObjectCount == 0)
        {
            StartCoroutine(GameResult(true, 0));
        }
        else if (ballCount == 0 && goalObjectCount > 0)
        {
            StartCoroutine(GameControl());
        }else if (goalObjectCount == 0)
        {
            StartCoroutine(GameResult(true, 0));
        }
    }

    IEnumerator GameControl()
    {
        yield return new WaitForSeconds(3);

        if(goalObjectCount >= 0)
        {
            StartCoroutine(GameResult(false, 0));
        }
        else
        {

            StartCoroutine(GameResult(true, 0));
        }

    }

    IEnumerator GameResult(bool win, float time = 3)
    {
        yield return new WaitForSeconds(time);
        if (win)
        {
            winPanel.SetActive(true);
        }
        else
        {
            losePanel.SetActive(true);
        }
    }


    public void Buttons(bool next)
    {
        if (next)
        {
            if(SceneManager.GetActiveScene().buildIndex == 4)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
