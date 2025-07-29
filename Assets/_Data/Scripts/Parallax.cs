using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Material material;
    [SerializeField] private float parallaxFactor = 0.5f;
    private float offset;
    //public float gameSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
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
