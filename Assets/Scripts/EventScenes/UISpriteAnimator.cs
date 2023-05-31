using UnityEngine;
using UnityEngine.UI;

/*
 *  @author Chase Franklin
 *  Animates sprites in UI.
 */

[RequireComponent(typeof(Image))]
public class UISpriteAnimator : MonoBehaviour
{
    public float duration;

    [SerializeField] private Sprite[] sprites;

    private Image image;
    private int index = 0;
    private float timer = 0;

    void Start()
    {
        image = GetComponent<Image>();
    }
    private void Update()
    {
        if ((timer += Time.deltaTime) >= (duration / sprites.Length))
        {
            timer = 0;
            image.sprite = sprites[index];
            index = (index + 1) % sprites.Length;
        }
    }
}
