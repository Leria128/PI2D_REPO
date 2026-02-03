using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
  public void LoadScene(int sceneToLoad) => SceneManager.LoadScene(sceneToLoad);
  

  public void ExitGame()
    {
        Debug.Log("Hascerrado el juego");
        Application.Quit();
    }


}
