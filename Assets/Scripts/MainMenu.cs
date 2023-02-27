using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _textOnPlayButton;
    [SerializeField] private GameObject _newGameButton;
    void Start()
    {
        _textOnPlayButton.text = "New Game";
        _newGameButton.SetActive(false);
    }

    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
