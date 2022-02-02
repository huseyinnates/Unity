Shader "Unlit/Zwritee"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent"
                "Queue"="Transparent"
             }
        LOD 200
        //ZTest LEqual //Depth testing
        //AlphaToMask On //Off reduce surplus MSAA use with aliasing
        //Blend Off //SrcColor DstColor
        //Determine Gpu how should combine fragment shader
        //Early-Z hidden surface remove off when blend on 
        //Use with Blendop to access Advanced Opengl Blending operitons  
        //ColorMask GB
        //Cull Front //Front Off to manage gpu which part will be render
        
        Pass
        {
           // Zwrite On Off set depth buffer during render 
           //ZTest Less passes or not z-depth
           // ZClip False near far object fragment handling
           // Stencil{ //mirror portal 
           //     ref 1
           //     Comp Always
           //     Pass Keep
           // }
            //Offset 1,1 //-1,-1 z-fighting
            //Conservative True //In rasterization proccess 
            //if this true partially inside the pixel will draw color
            
           // ZTest Always//Less Equal **GEqual NotEqual Always
          
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
           
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                return float4(i.uv,0,0);
            }
            ENDCG
        }
    }
}
