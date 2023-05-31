using UnityEngine;

/*
 * @author Chase Franklin
 * Scales planet as a transition within the planet reveal sequence.
 */

public class PlanetScale : MonoBehaviour
{
    [SerializeField] private GameObject planetAssembly;
    [SerializeField] private float scaleSize;
    [SerializeField] private float scaleTime;
    private float startTime;
    private Vector3 startScale;
    private void Start()
    {
        startScale = planetAssembly.transform.localScale;
    }
    private void OnEnable()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        float t = (Time.time - startTime) / scaleTime;
        if (Time.time - startTime < scaleTime)
        {
            planetAssembly.transform.localScale = Vector3.Lerp(startScale, new Vector3(scaleSize, scaleSize, scaleSize), t);
        }
    }
}
