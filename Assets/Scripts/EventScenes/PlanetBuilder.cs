using System.Collections.Generic;
using UnityEngine;

/*
 * @author Chase Franklin
 * Fills planet with user selected variables
 */

public class PlanetBuilder : MonoBehaviour
{
    public PlanetHandler planetHandler;
    public DuckHandler duckHandler;

    [SerializeField] private SpriteRenderer front;
    [SerializeField] private SpriteRenderer middle;
    [SerializeField] private SpriteRenderer back;

    [SerializeField] private List<Sprite> planet1Sprites = new List<Sprite>();
    [SerializeField] private List<Sprite> planet2Sprites = new List<Sprite>();
    [SerializeField] private List<Sprite> planet3Sprites = new List<Sprite>();

    private int planetID;
    private int primaryColorID;
    private int secondaryColorID;
    private Color32 primaryColor;
    private Color32 secondaryColor;

    private void OnEnable()
    {
        planetID = planetHandler.selectedPlanetID;
        primaryColorID = duckHandler.primary;
        secondaryColorID = duckHandler.secondary;

        if (planetID == 1)
        {
            front.sprite = planet1Sprites[0];
            middle.sprite = planet1Sprites[1];
            back.sprite = planet1Sprites[2];

            GetColors();

            front.color = secondaryColor;
            middle.color = primaryColor;
            back.color = secondaryColor;
        }
        else if (planetID == 2)
        {
            front.sprite = planet2Sprites[0];
            middle.sprite = planet2Sprites[1];
            back.sprite = planet2Sprites[2];

            GetColors();

            front.color = primaryColor;
            middle.color = secondaryColor;
            back.color = secondaryColor;
        }
        else if (planetID == 3)
        {
            front.sprite = planet3Sprites[0];
            middle.sprite = planet3Sprites[1];
            back.sprite = planet3Sprites[2];

            GetColors();

            front.color = primaryColor;
            middle.color = secondaryColor;
            back.color = primaryColor;
        }
    }
    
    private void GetColors()
    {
        // primary colors

        if (primaryColorID == 1)
        {
            primaryColor = new Color32(107, 176, 242, 255);
        }
        else if (primaryColorID == 2)
        {
            primaryColor = new Color32(129, 243, 107, 255);
        }
        else if (primaryColorID == 3)
        {
            primaryColor = new Color32(242, 107, 195, 255);
        }
        else if (primaryColorID == 4)
        {
            primaryColor = new Color32(170, 107, 242, 255);
        }

        // secondary colors
        if (secondaryColorID == 1)
        {
            secondaryColor = new Color32(107, 176, 242, 255);
        }
        else if (secondaryColorID == 2)
        {
           secondaryColor = new Color32(129, 243, 107, 255);
        }
        else if (secondaryColorID == 3)
        {
           secondaryColor = new Color32(242, 107, 195, 255);
        }
        else if (secondaryColorID == 4)
        {
           secondaryColor = new Color32(170, 107, 242, 255);
        }
    }
}
