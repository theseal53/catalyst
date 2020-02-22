Shader "Unlit/Crayon"
{
    Properties
    {
        [Header(Texture)]
        _MainTex("Texture", 2D) = "white" {}
        _Rotation("Rotation", Float) = 0

    }
        SubShader
        {
            Tags { "Queue" = "Geometry" "RenderType" = "Opaque" }

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                float4 _MainTex_ST;

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata_base v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = o.vertex.xy;
                    return o;
                }

                sampler2D _MainTex;
                float _Rotation;


                fixed4 frag(v2f i) : SV_Target
                {
                    // Screen space texture
                    float sinX = sin(_Rotation);
                    float cosX = cos(_Rotation);
                    float sinY = sin(_Rotation);
                    float2x2 rotationMatrix = float2x2(cosX, -sinX, sinY, cosX);
                    //v.texcoord.xy = mul(v.texcoord.xy, rotationMatrix);
                    return tex2D(_MainTex, ((mul(i.vertex, rotationMatrix).xy * _MainTex_ST.xy / _ScreenParams.xy)));
                }

                ENDCG
            }

            Pass
            {
            Tags {"LightMode" = "ShadowCaster"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_shadowcaster
            #include "UnityCG.cginc"

            struct v2f {
                V2F_SHADOW_CASTER;
            };

            v2f vert(appdata_base v)
            {
                v2f o;
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
            }

        }
}