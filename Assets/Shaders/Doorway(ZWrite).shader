Shader "Custom/Portal(ZWrite)" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags {"Queue"="Background" "RenderType"="Opaque" }
		LOD 200
		
		ZWrite On
		ColorMask 0
		Pass{
			Stencil {
				Ref 1
				Comp always
				Pass replace
				ZFail Zero
			}
		}
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
