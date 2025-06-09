using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scareHandler : MonoBehaviour
{
    public GameObject aiObj;
    public GameObject timeObj;
    public GameObject scareObj;
    public Image scareImage;
    public Sprite[] scareSprites = { };
    private bool attacking = false;
    public AudioSource meow1;
    private GurtAI gurtAI;
    private YoAI yoAI;
    public string mainMenu = "mainMenu";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scareObj.SetActive(false);
    }
    IEnumerator gurtScare()
    {
        scareImage.sprite = scareSprites[1];
        meow1.Play();
        scareObj.SetActive(true);
        yield return new WaitForSeconds(1f);
        timeObj.GetComponent<timeHandler>().lose = true;
        SceneManager.LoadScene(mainMenu);
    }
    IEnumerator yoScare()
    {
        meow1.Play();
        scareImage.sprite = scareSprites[0];
        scareObj.SetActive(true);
        yield return new WaitForSeconds(1f);
        timeObj.GetComponent<timeHandler>().lose = true;
        SceneManager.LoadScene(mainMenu);
    }
    // Update is called once per frame
    void Update()
    {
        gurtAI = aiObj.GetComponent<GurtAI>();
        yoAI = aiObj.GetComponent<YoAI>();
        if (!attacking)
        {
            if (yoAI.attacking)
            {
                attacking = true;
                StartCoroutine(yoScare());
            }
            if (gurtAI.attacking)
            {
                attacking = true;
                StartCoroutine(gurtScare());
            }
        }
    }
}
