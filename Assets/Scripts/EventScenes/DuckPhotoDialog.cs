using UnityEngine;
using UnityEngine.UI;

/*
 *  @author Chase Franklin
 *  Activates dialog sequence after race concludes and modifies dialog based on the results of the race.
 */

public class DuckPhotoDialog : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private DuckHandler duckHandler;
    private string losingColor;
    private void OnEnable()
    {
        if(duckHandler.secondary == 1)
        {
            losingColor = "blue";
        }
        else if(duckHandler.secondary == 2)
        {
            losingColor = "green";
        }
        else if(duckHandler.secondary == 3)
        {
            losingColor = "pink";
        }
        else if(duckHandler.secondary == 4)
        {
            losingColor = "purple";
        }
        text.text = "Darn! my money was on " + losingColor + ", you must have some strong quantum ties";
    }
}
