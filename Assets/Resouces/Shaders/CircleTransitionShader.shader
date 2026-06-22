Shader "URP/CircleTransition"
{
    Properties
    {
        _Color ("Transition Color", Color) = (0, 0, 0, 1)
        _Radius ("Radius", Range(0, 2)) = 1.5
    }

    SubShader
    {
        Tags 
        { 
            "RenderType" = "Transparent" 
            "Queue" = "Transparent" 
            "RenderPipeline" = "UniversalPipeline" 
        }

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv           : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS   : SV_POSITION;
                float2 uv           : TEXCOORD0;
            };

            float4 _Color;
            float _Radius;

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = input.uv;
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                float2 centeredUV = input.uv - float2(0.5, 0.5);

                float aspect = _ScreenParams.x / _ScreenParams.y;
                centeredUV.x *= aspect;

                float dist = length(centeredUV);

                float alpha = smoothstep(_Radius - 0.01, _Radius, dist);

                return half4(_Color.rgb, _Color.a * alpha);
            }
            ENDHLSL
        }
    }
}