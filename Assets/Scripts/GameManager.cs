using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject mob;
    [SerializeField] private float mobNumber;
    private float currentMobNumber;
    private bool sceneIsLoading;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        currentMobNumber = mobNumber;
    }

    public void IsWinning()
    {
        currentMobNumber--;
        if (currentMobNumber <= 0 && !sceneIsLoading)
            NextLevel();

    }

    private void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            sceneIsLoading = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
