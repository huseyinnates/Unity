Shader "Unlit/ShaderTime"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "red" {}
        _OffsetDistance("Offset Distance",float)=0
        _RangeEx("Range",Range(0,50))=0
      
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
        
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _OffsetDistance;
            float _RangeEx;
            v2f vert (appdata v)
            {
                
                v2f o;
                v.vertex.y+=sin(v.vertex.y*_RangeEx+v.vertex.x*_Time.y);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                float a=frac(2.34223);
                return col;
            }
            ENDCG
        }
    }
}
