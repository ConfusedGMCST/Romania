using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GurtAI : MonoBehaviour
{
    public Vector2[] camPositions;
    public GameObject clickHandler;
    public Vector2 attackPos;
    public Image gurtImage;
    public AudioSource gurtMove;
    public GameObject gurtObj;
    public bool attacking;
    private int difficulty = 1;
    public int currentPos = 0;
    private clickHandler durghus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator movement()
    {
        int delay = Random.Range(3, 8);
        //Debug.Log("movement starting (gurt)" + " " + currentPos);
        yield return new WaitForSeconds(delay);
        int randomNum = Random.Range(0, 20);
        if (currentPos < 4)
        {
            if (randomNum < difficulty)
            {
                gurtMove.Play();
                Debug.Log("Movement Success!");
                switch (currentPos)
                {
                    case 0:
                        currentPos = 2;
                        break;
                    case 2:
                        currentPos = 3;
                        break;
                    case 3:
                        currentPos = 4;
                        break;
                }
            }
        } else {
            if (randomNum < difficulty && !attacking)
            {
                if (durghus.darkObj.activeSelf)
                {
                    attacking = true;
                } else
                {
                    attacking = false;
                    currentPos = 0;
                }
            }
        }
        StartCoroutine(movement());
    }
    private void Start()
    {
        durghus = clickHandler.GetComponent<clickHandler>();
        StartCoroutine(movement());
        if (durghus != null)
        {
            difficulty = difficultyController.Instance.difficulty;
        }
    }
    private void FixedUpdate()
    {
        durghus = clickHandler.GetComponent<clickHandler>();
        if (currentPos < 4) {
            if (durghus.currentCam == currentPos && durghus.cameraState)
            {
                gurtObj.SetActive(true);
                gurtObj.transform.position = camPositions[currentPos];
            } else
            {
                gurtObj.SetActive(false);
            }
        } else {
            if (durghus.cameraState)
            {
                gurtObj.SetActive(false);
            } else
            {
                gurtObj.SetActive(true);
            }
        }
    }
}
