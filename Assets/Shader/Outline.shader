Shader "Custom/Outline"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex("Main Texture", 2D) = "white"{}
        _Outline("Outline", Float) = 0.1
        _OutlineColor("Outline Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags{
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
            "IgnoreProjector" = "True"
            }
                

            Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Cull front
            Zwrite off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            uniform half _Outline;
            uniform half4 _OutlineColor;

            struct VertexInput
            {
                float4 vertex: POSITION;
            };

            struct VertexOutput
            {
                float4 pos: SV_POSITION;
            };

            float4 outline(float4 pos, float outline)
            {
                fixed4x4 scale = 0.0;
                scale[0][0] = 1.0 + _Outline;
                scale[1][1] = 1.0 + _Outline;
                scale[2][2] = 1.0 + _Outline;
                scale[3][3] = 1.0;
                return mul(scale, pos);
            }

            VertexOutput vert(VertexInput v)
            {
                VertexOutput o;
                o.pos = UnityObjectToClipPos(outline(v.vertex, _Outline));
                return o;
            }

            half4 frag(VertexOutput i) : COLOR   //half4 will be treated as a color
            {
                return _OutlineColor;
            }

            ENDCG
        }
            
    }
}
