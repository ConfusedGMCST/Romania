using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class difficultyController : MonoBehaviour
{
    public static difficultyController Instance { get; private set; }

    public TextMeshProUGUI[] difficultyDisplays;
    public int difficulty = 0;
    public string mainGame = "mainGame";
    public GameObject playButton;
    public GameObject difficultySelector;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // prevent duplicate controllers
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persist across scenes
        }
    }

    public void toggleDown()
    {
        if (difficulty > 0)
        {
            difficulty--;
        }
    }

    public void toggleUp()
    {
        if (difficulty < 20)
        {
            difficulty++;
        }
    }

    public void startMainGame()
    {
        difficultySelector.SetActive(false);
        playButton.SetActive(true);
        SceneManager.LoadScene(mainGame);
    }

    void Update()
    {
        for (int i = 0; i < difficultyDisplays.Length; i++)
        {
            difficultyDisplays[i].text = "" + difficulty;
        }
    }
}
