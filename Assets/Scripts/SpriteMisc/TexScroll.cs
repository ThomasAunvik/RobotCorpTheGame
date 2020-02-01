using UnityEngine;

public class TexScroll : MonoBehaviour
{
    // Scroll main texture based on time

    [SerializeField]
    public float scrollSpeed = 0.5f;
    [SerializeField]
    public float robotSpeed = 0.01f;
    [SerializeField]
    public Vector2 scrollDirection;
    [SerializeField]
    private float lerp = 0.1f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", scrollDirection * offset);
        //rend.material.mainTextureOffset = Vector2.Lerp(rend.material.mainTextureOffset, scrollDirection * offset, lerp);
    }
}