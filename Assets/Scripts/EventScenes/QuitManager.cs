using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * @author Chase Franklin
 * Quits the application when user selects "Wake Up" button.
 */

public class QuitManager : MonoBehaviour
{
    public void QuitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
