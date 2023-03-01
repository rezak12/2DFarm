using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    [SerializeField] private Player _player;
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
        SaveSceneInfo(_player);
        SceneManager.LoadScene("Main Menu");
    }

    private void SaveSceneInfo(Player ply)
    {
        SaveSystem.SaveSceneInfo(ply);
    }

    private void LoadSystemInfo()
    {
        SceneData data = SaveSystem.LoadSceneInfo();
        _player.AddStaminaPoints(data.maxStamina - 20f);
        _player.GetComponent<ExperinceSystem>().TakeXP(data.XP);
        _player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
    }
}
