using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeHandler : MonoBehaviour
{
    public TextMeshProUGUI clock;
    int time = 0;
    public bool win = false;
    public bool lose = false;
    public GameObject winObj;

    IEnumerator clockTick()
    {
        for (int i = 0; i < 600; i++)
        {
            if (time < 100)
            {
                clock.text = "12 AM";
            } else
            {
                clock.text = (i / 100).ToString() + " AM";
            }
            time = i;
            yield return new WaitForSeconds(0.5f);
        }
        win = true;
        StartCoroutine(winScreen());
    }
    IEnumerator winScreen()
    {
        winObj.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("mainMenu");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winObj.SetActive(false);
        StartCoroutine(clockTick());   
    }
}
