Shader "Unlit/MovementViaShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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
            uint division=0;
            v2f vert (appdata v)
            {
                
                v2f o;
                float a=_Time.y%10;
                a/=10.0;
                division=_Time.y/10;
                if(division%2==0){
                     v.vertex*=(a);
                }else{
                     v.vertex*=(1-a);
                }
               v.vertex.x+=sin(_Time.y)/15.0;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}
