using UnityEngine;
using UnityEngine.UI;

public class menuOperator : MonoBehaviour
{
    public GameObject playButton;
    public GameObject difficultySelector;

    public void playButtonSelected()
    {
        playButton.SetActive(false);
        difficultySelector.SetActive(true);    
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
