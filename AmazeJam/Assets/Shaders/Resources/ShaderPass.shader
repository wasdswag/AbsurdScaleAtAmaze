Shader "Hidden/ShaderPass"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			#include "Utils.cginc"
			
			sampler2D _MainTex;
			sampler2D _CameraTexture;

			fixed4 frag (v2f_img i) : SV_Target
			{
				float2 uv = i.uv;
				float unit = 2.0 / _ScreenParams.xy;
				float2 offset = float2(0.5,0.5)-i.uv;
				float angle = rgb2hsv(tex2D(_MainTex, i.uv)).x * PI2;
				offset.xy += float2(cos(angle),sin(angle));
				uv += offset * unit;
				fixed4 buffer = tex2D(_MainTex, uv);
				fixed4 camera = tex2D(_CameraTexture, i.uv);
				//fixed4 color = lerp(buffer, camera, step(0.1,camera.a*100.));
				float lum = Luminance(camera);
				fixed4 color = lerp(buffer, camera, lerp(0.,step(0.3,colorDistance(camera, buffer)), clamp(lum*10.,0.,1.)));
				return color;
			}
			ENDCG
		}
	}
}
