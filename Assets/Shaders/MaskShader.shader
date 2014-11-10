Shader "Custom/MaskShader" {
	SubShader {
	ColorMask 0
		Pass{
			Blend SrcAlpha OneMinusSrcAlpha
			Lighting On
			ZWrite On
			Material{
				Diffuse(0, 0, 0, 0)
			}
		}	
	} 
}
