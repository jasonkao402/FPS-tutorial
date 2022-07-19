Shader "PostEffects/Mask"
{
    SubShader
    {
        Tags{ "Queue" = "Transparent+5" }
        Pass
        {
            Blend Zero One
        }
    }
}