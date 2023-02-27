using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    void Start()
    {
        _pauseMenu.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
    }

    public void ToMenu()
    {
        Time.timeScale = 1.0f;
        //save
        SceneManager.LoadScene("Main Menu");
    }
}
