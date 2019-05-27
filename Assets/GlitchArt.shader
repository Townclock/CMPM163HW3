Shader "Custom/GlitchArt"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseTex ("Texture", 2D) = "white" {}
        _ScanLinesTex ("Texture", 2D) = "white" {}
		
		_RandomX ("RandomX", Float) = 0
		_RandomY ("RandomY", Float) = 0
		_RandomY ("RandomY", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

        Pass	//Shadow
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float2 noise_uv : TEXCOORD1;
                float2 scanline_uv : TEXCOORD2;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
				
                float2 noise_uv : TEXCOORD1;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float2 scanline_uv: TEXCOOR2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NoiseTex;
            float4 _NoiseTex_ST;
			
			sampler2D _ScanLinesTex;
            float4 _ScanLinesTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.noise_uv = TRANSFORM_TEX(v.uv, _NoiseTex) + _Time.y;
                o.scanline_uv = TRANSFORM_TEX(v.scanline_uv, _ScanLinesTex) + _Time.y /17;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = 1 - tex2D(_MainTex, i.uv);
				col += tex2D(_NoiseTex, i.noise_uv);
				col /=2;
				
					col += tex2D(_ScanLinesTex, i.scanline_uv);
				
				
                return col;
            }
            ENDCG
        }
    		Pass	//Front
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float2 noise_uv : TEXCOORD01;
                float2 scanline_uv : TEXCOORD02;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
				
                float2 noise_uv : TEXCOORD1;
                float4 vertex : SV_POSITION;
                float2 scanline_uv: TEXCOORD02;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NoiseTex;
            float4 _NoiseTex_ST;
			
			sampler2D _ScanLinesTex;
            float4 _ScanLinesTex_ST;
			
			uniform float _RandomX;
			uniform float _RandomY;
			uniform float _RandomZ;
			

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				
				o.vertex.x += _RandomX;
				o.vertex.y += _RandomY;
				o.vertex.y += _RandomZ;
				
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.noise_uv = TRANSFORM_TEX(v.uv, _NoiseTex) + _Time.y;
                o.scanline_uv = TRANSFORM_TEX(v.scanline_uv, _ScanLinesTex) + _Time.y/17 ;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
				
				if(_RandomX != 0 && _RandomY!= 0)
				{
					col += tex2D(_NoiseTex, i.noise_uv)/3;
                
					col += tex2D(_ScanLinesTex, i.scanline_uv);
					
					col.w = 0.7;
				}
				return col;
            }
            ENDCG
        }
	}
}
