using UnityEngine;

public class LoadingComplete : MonoBehaviour
{
    [SerializeField] private GameObject loadingAnim;
    void Start()
    {
        loadingAnim.SetActive(false);
    }
}
