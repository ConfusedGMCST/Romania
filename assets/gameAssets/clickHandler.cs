using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class clickHandler : MonoBehaviour
{
    public Sprite[] switchFrames = { };
    public Sprite[] drawFrames = { };
    public Sprite[] curtainFrames = { };
    public Sprite[] cameraBackgrounds = { };
    public GameObject[] prodUses = { };
    public Button drawString;
    public Button lightSwitchObj;
    public Button cattleProdButton;
    public Button curtain;
    public AudioSource camSwitchEffect;
    public AudioSource curtainEffect;
    public AudioSource hallwayBuzz;
    public AudioSource lightSwitchEffect;
    public AudioSource prodSound;
    public Image cameraBkg;
    public GameObject darkObj;
    public GameObject ventObj;
    public GameObject cameraObj;
    public GameObject office;
    public GameObject YoAI;
    public bool drawState = false;
    public bool recharging = false;
    public bool drawAnim = false;
    public bool hallLight = false;
    public bool switchState = false;
    public bool cameraState = false;
    public float drawAnimLen = 0.6f;
    public int currentCam = 0;
    private int prodsUsed = 0;
    public void lightSwitch()
    {
        lightSwitchEffect.Play();
        if (hallLight)
        {
            darkObj.SetActive(true);
            lightSwitchObj.image.sprite = switchFrames[0];
            hallLight = false;
        }
        else
        {
            darkObj.SetActive(false);
            lightSwitchObj.image.sprite = switchFrames[1];
            hallLight = true;
        }
    }
    IEnumerator zapRecharge()
    {
        yield return new WaitForSeconds(12.5f);
        switch (prodsUsed)
        {
            case 0:
                break;
            case 1:
                prodsUsed--;
                prodUses[0].SetActive(true);
                recharging = false;
                break;
            case 2:
                prodsUsed--;
                prodUses[1].SetActive(true);
                StartCoroutine(zapRecharge());
                break;
        }
    }
    IEnumerator drawGoDown()
    {
        curtainEffect.Play();
        for (int i = 0; i < drawFrames.Length; i++)
        {
            drawString.image.sprite = drawFrames[i];
            yield return new WaitForSeconds(drawAnimLen / drawFrames.Length);
        }
        drawAnim = false;
    }
    IEnumerator drawGoUp()
    {
        curtainEffect.Play();
        for (int i = drawFrames.Length - 1; i > 0; i--)
        {
            drawString.image.sprite = drawFrames[i];
            yield return new WaitForSeconds(drawAnimLen / drawFrames.Length);
        }
        drawAnim = false;
    }
    IEnumerator curtainGoDown()
    {
        for (int i = 0; i < curtainFrames.Length; i++)
        {
            curtain.image.sprite = curtainFrames[i];
            yield return new WaitForSeconds(drawAnimLen / curtainFrames.Length);
        }
    }
    IEnumerator curtainGoUp()
    {
        for (int i = curtainFrames.Length - 1; i > 0; i--)
        {
            curtain.image.sprite = curtainFrames[i];
            yield return new WaitForSeconds(drawAnimLen / curtainFrames.Length);
        }
    }
    public void drawStrings()
    {
        if (!drawAnim)
        {
            drawAnim = true;
            if (!drawState)
            {
                drawState = true;
                StartCoroutine(drawGoUp());
                StartCoroutine(curtainGoDown());
            } else
            {
                drawState = false;
                StartCoroutine(drawGoDown());
                StartCoroutine(curtainGoUp());
            }
        }
    }

    public void cameras()
    {
        if (!cameraState)
        {
            cameraObj.SetActive(true);
            office.SetActive(false);
            darkObj.SetActive(true);
            hallLight = false;
            ventObj.SetActive(false);
            cameraState = true;
        } else
        {
            cameraObj.SetActive(false);
            office.SetActive(true);
            ventObj.SetActive(true);
            cameraState = false;
        }
    }

    public void camSwitch()
    {
        bool foundUnderscore = false;
        foreach (char c in EventSystem.current.currentSelectedGameObject.name)
        {
            if (foundUnderscore)
            {
                currentCam = int.Parse(c + "") - 1;
            }
            if (!foundUnderscore && c.Equals('_'))
            {
                foundUnderscore = true;
            }
        }
        cameraBkg.sprite = cameraBackgrounds[currentCam];
        camSwitchEffect.Play();
    }

    public void cattleProd()
    {
        if (prodsUsed < 2 && YoAI.GetComponent<YoAI>().currentPos > 2)
        {
            prodSound.Play();
            prodUses[prodsUsed].SetActive(false);
            prodsUsed++;
            YoAI.GetComponent<YoAI>().currentPos = 2;
        }
        if (!recharging)
        {
            StartCoroutine(zapRecharge());
        }
        recharging = true;
    }

    private void FixedUpdate()
    {
        if (office.GetComponent<Transform>().position.x > 100 && drawState)
        {
            drawState = false;
            StartCoroutine(drawGoDown());
            StartCoroutine(curtainGoUp());
        }
        if (office.GetComponent<Transform>().position.x < 480 && hallLight)
        {
            darkObj.SetActive(true);
            lightSwitchObj.image.sprite = switchFrames[0];
            hallLight = false;
        }
    }
}
