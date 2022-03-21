// Thanks to Kunal Tandon for giving the base code for this concept.
using UnityEngine;

// Scales sprites based on given screen size.
public class SpriteScaler : MonoBehaviour
{
    [SerializeField] private float scale = .01f;

    void Start()
    {
        float width = FetchScreenSize.GetScreenToWorldWidth;
        transform.localScale = new Vector3(1, 1, 0) * (width * scale);
    }
}
