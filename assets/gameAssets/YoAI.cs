using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class YoAI : MonoBehaviour
{
    public Vector2[] camPositions;
    public GameObject clickHandler;
    public Vector2 attackPos;
    public Image yoImage;
    public GameObject yoObj;
    public bool attacking;
    private int difficulty = difficultyController.Instance.difficulty;
    public int currentPos = 0;
    private clickHandler durghus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator movement()
    {
        int delay = Random.Range(2, 7);
        yield return new WaitForSeconds(delay);
        int randomNum = Random.Range(0, 20);
        if (currentPos < 5)
        {
            if (randomNum < difficulty)
            {
                switch (currentPos)
                {
                    case 0:
                        currentPos = 1;
                        break;
                    case 1:
                        currentPos = 2;
                        break;
                    case 2:
                        currentPos = 3;
                        break;
                    case 3:
                        currentPos = 4;
                        break;
                    case 4:
                        currentPos = 5;
                        break;
                }
            }
        }
        else
        {
            if (randomNum < difficulty && !attacking)
            {
                if (durghus.drawState)
                {
                    attacking = false;
                    currentPos = 0;
                }
                else
                {
                    attacking = true;
                }
            }
        }
        StartCoroutine(movement());
    }
    private void Start()
    {
        durghus = clickHandler.GetComponent<clickHandler>();
        StartCoroutine(movement());
    }
    private void FixedUpdate()
    {
        durghus = clickHandler.GetComponent<clickHandler>();
        if (currentPos < 5)
        {
            if (durghus.cameraState)
            {
                switch (currentPos)
                {
                    case 0:
                        if (durghus.currentCam == 0)
                        {
                            yoObj.SetActive(true);
                            yoImage.rectTransform.position = new Vector2(1300, 360);
                        }
                        else
                        {
                            yoObj.SetActive(false);
                        }
                        break;
                    case 1:
                        if (durghus.currentCam == 2)
                        {
                            yoObj.SetActive(true);
                            yoImage.rectTransform.position = new Vector2(1260, 340);
                        }
                        else
                        {
                            yoObj.SetActive(false);
                        }
                        break;
                    case 2:
                        if (durghus.currentCam == 1)
                        {
                            yoObj.SetActive(true);
                            yoImage.rectTransform.position = new Vector2(960, 540);
                            yoImage.rectTransform.localScale = new Vector2(0.6f, 0.6f);
                        }
                        else
                        {
                            yoObj.SetActive(false);
                        }
                        break;
                    case 3:
                        if (durghus.currentCam == 1)
                        {
                            yoObj.SetActive(true);
                            yoImage.rectTransform.position = new Vector2(960, 540);
                            yoImage.rectTransform.localScale = new Vector2(0.8f, 0.8f);
                        }
                        else
                        {
                            yoObj.SetActive(false);
                        }
                        break;
                    case 4:
                        if (durghus.currentCam == 1)
                        {
                            yoObj.SetActive(true);
                            yoImage.rectTransform.position = new Vector2(960, 540);
                            yoImage.rectTransform.localScale = new Vector2(1, 1);
                        }
                        else
                        {
                            yoObj.SetActive(false);
                        }
                        break;
                }
            } else
            {
                yoObj.SetActive(false);
            }
        } else {
            if (durghus.cameraState)
            {
                yoObj.SetActive(false);
            }
            else
            {
                yoObj.SetActive(true);
            }
        }
    }
}
