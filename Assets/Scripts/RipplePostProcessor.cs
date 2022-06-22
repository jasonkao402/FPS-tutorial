using UnityEngine;
 
public class RipplePostProcessor : MonoBehaviour
{
    public Material RippleMaterial;
    public float MaxAmount = 50f;
    [Range(0,1)]
    public float Friction = .9f;
    private float Amount = 0f;
    public static RipplePostProcessor Instance{get; private set;}
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        RippleMaterial.SetFloat("_Amount", Amount);
        Amount *= Friction;
    }
    public void makeRipple(Vector3 pos)
    {
        Amount = MaxAmount;
        pos = Camera.main.WorldToScreenPoint(pos);
        RippleMaterial.SetFloat("_CenterX", pos.x);
        RippleMaterial.SetFloat("_CenterY", pos.y);
    }
    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, this.RippleMaterial);
    }
}