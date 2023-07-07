using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public Image fill;
    public GameObject canvasIcon;
    public float currentValue, maxValue;
    private float observedTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            observedTime = Time.time;
            canvasIcon.SetActive(true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            currentValue = Time.time - observedTime;
            fill.fillAmount = Normalize();

            if (currentValue > maxValue)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            currentValue = 0;
            canvasIcon.SetActive(false);
        }
    }

    private float Normalize()
    {
        return currentValue / maxValue;
    }
}
