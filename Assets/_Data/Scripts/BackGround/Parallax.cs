using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Material material;
    [SerializeField] private float parallaxFactor = 0.5f;
    private float offset;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        ParallaxScroll();
    }

    private void ParallaxScroll()
    {
        //float speed = parallaxFactor;
        offset += Time.deltaTime * parallaxFactor;
        material.SetTextureOffset("_MainTex", Vector2.down * offset);
    }
}
