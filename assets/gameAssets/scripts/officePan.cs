using UnityEngine;
using UnityEngine.UI;

public class officePan : MonoBehaviour
{
    private Vector2 leftMax = new Vector2(1980, -136);
    private Vector2 rightMax = new Vector2(-250, -136);
    private float rightFrame;
    private float leftFrame;
    private float posChange;
    public float maxSpeed = 15;
    public Transform officeTransform;
    public GameObject ventHolder;
    public GameObject dark;
    public GameObject gurt;
    public GameObject gurtAI;
    public Image yo;

    void FixedUpdate()
    {
        if (officeTransform.position.x < leftMax.x && Input.mousePosition.x < Screen.width/8) {
            if (leftFrame < 0.5)
            {
                leftFrame += 0.02f;
            }
        } else if (leftFrame > 0)
        {
            leftFrame -= 0.02f;
        }
        if (officeTransform.position.x > rightMax.x && Input.mousePosition.x > (Screen.width / 8) * 7)
        {
            if (rightFrame < 0.5)
            {
                rightFrame += 0.02f;
            }
        }
        else if (rightFrame > 0)
        {
            rightFrame -= 0.02f;
        }
        if (officeTransform.position.x < rightMax.x)
        {
            rightFrame = 0;
        }
        if (officeTransform.position.x > leftMax.x)
        {
            leftFrame = 0;
        }
        posChange = (Mathf.Sin(Mathf.PI * leftFrame) * maxSpeed) - (Mathf.Sin(Mathf.PI * rightFrame) * maxSpeed);
        officeTransform.position = new Vector2(officeTransform.position.x + posChange, officeTransform.position.y);
        dark.transform.position = new Vector2(officeTransform.position.x + 99.3139f, dark.transform.position.y);
        ventHolder.transform.position = new Vector2(officeTransform.position.x + 99.3139f, ventHolder.transform.position.y);
        if (gurtAI.GetComponent<GurtAI>().currentPos == 4)
        {
            gurt.transform.position = new Vector2(officeTransform.position.x - 1650, 350);
        }
        if (gurtAI.GetComponent<YoAI>().currentPos == 5)
        {
            yo.rectTransform.position = new Vector2(officeTransform.position.x + 2050, 450);
        }
    }
}
