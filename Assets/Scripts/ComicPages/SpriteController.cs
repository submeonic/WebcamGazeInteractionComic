using DlibFaceLandmarkDetectorExample;
using UnityEngine;

/*
 *  @author Chase Franklin
 *  Controls comic sprites based on gaze interaction
 */

public class SpriteController : MonoBehaviour
{
    public HeadPose HeadPose;
    public FrameUtility frameUtility;

    private SpriteRenderer sprite;
    private Animator anim;
    private Color color1 = Color.cyan;
    private Color color2 = Color.magenta;
    private bool blinkActive = false;
    private bool observedState = false;
    private bool previousState;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        // Selects between two sprite colors everytime a frame is observed
        // unobserved frames have black circle as a placeholder
        if (frameUtility.activelyObserved)
        {
            observedState = true;
        }
        else
        {
            observedState = false;
        }

        //anim change to observedAnim
        if (observedState && !previousState)
        {
            anim.SetBool("Observed", true);
            int colorChoice = Random.Range(0, 2);
            if (colorChoice == 1)
            {
                sprite.color = color2;
            }
            else
            {
                sprite.color = color1;
            }
        }
        //anim change to unobserved
        else if (!observedState)
        {
            anim.SetBool("Observed", false);
            sprite.color = Color.black;
        }
        previousState = observedState;
        

        // Uses pose controller blink bool to change sprite color
        // under conditions that blink state was true but is now false
        if (!blinkActive && HeadPose.blink && frameUtility.activelyObserved)
        {
            
            if (sprite.color == color2)
            {
                sprite.color = color1;
            }
            else
            {
                sprite.color = color2;
            }
        }

        blinkActive = HeadPose.blink;
    }
}
