
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        
    }



    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
