Shader "Unlit/ShaderStuff"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		_ColorNormal ("Color Normal", Float) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100
		Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			#include "Utils.cginc"

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
				float3 normal : NORMAL;
				float2 texcoord : TEXCOORD0;
				float3 viewDir : TEXCOORD1;
				float4 infos : TEXCOORD2;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Color;
			float _ColorNormal;
			
			v2f vert (appdata_full v)
			{
				v2f o;
				o.normal = normalize(mul(UNITY_MATRIX_M, v.normal));
				// o.normal = normalize(v.normal);
				// vertex.xyz = 100. / vertex.xyz;
				float4 vertex = v.vertex;
				float4 center = mul(UNITY_MATRIX_M, float4(0,0,0,1));
				float4 vertexWorld = mul(UNITY_MATRIX_M, vertex);
				// vertexWorld.xyz += 5. * o.normal * noiseIQ(2.*rotateY(rotateX(o.normal, _Time.y), _Time.y*0.5));
				//vertexWorld.xyz = center.xyz + rotateY(vertexWorld.xyz - center.xyz, lerp(0., length(vertexWorld-center)*0.02, sin(_Time.y*0.2)*0.5+0.5));
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.viewDir = vertexWorld - _WorldSpaceCameraPos;

				// distance from camera
				o.infos.x = mul(UNITY_MATRIX_V, vertexWorld).z;
				
				float shade = dot(-normalize(o.viewDir), o.normal)*0.5+0.5;
				o.infos.y = shade;

				// o.color = fixed4(1,1,1,1);// lerp(_Color, float4(o.normal*0.5+0.5,1.), shade * o.infos.x);
				o.color = fixed4(1,1,1,1);
				// float gridSize = 0.1;
				// o.color.rgb *= smoothstep(0.5, 0.55, clamp(length(fmod(vertex*0.01,gridSize)-gridSize*0.5),0.,1.));
				o.vertex = mul(UNITY_MATRIX_VP, vertexWorld);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = fixed4(1,0,0,1);
				fixed3 colorful = rotateY(rotateX(i.normal, _Time.y),_Time.y*0.5)*0.5+0.5;
				colorful.rgb = rgb2hsv(colorful);
				colorful.yz = 1.0;
				colorful.rgb = hsv2rgb(colorful);
				col.rgb = lerp(tex2D(_MainTex, i.texcoord) * i.color, colorful, i.infos.y);
				col.rgb *= smoothstep(0.5, 0.6, clamp(i.infos.y + (sin(i.infos.x*0.1)*0.5+0.5), 0., 1.));
				return col;
			}
			ENDCG
		}
	}
}
