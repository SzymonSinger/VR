Shader "UI/AlwaysOnTop"
{
    SubShader
    {
        Tags { "Queue" = "Overlay" }
        Pass
        {
            Cull Off
            ZWrite Off
            ZTest Always
            ColorMask RGBA
        }
    }
}
