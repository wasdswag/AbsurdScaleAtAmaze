Shader "Unlit/ShaderStuff"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
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
			
			v2f vert (appdata_full v)
			{
				v2f o;
				// o.normal = normalize(mul(UNITY_MATRIX_M, v.normal));
				o.normal = normalize(v.normal);
				float4 vertex = v.vertex;
				vertex.xyz = rotateY(vertex.xyz, lerp(0., length(vertex)*0.02, sin(_Time.y)*0.5+0.5));
				// vertex.xyz = 100. / vertex.xyz;
				vertex.xyz += 5. * o.normal * noiseIQ(2.*rotateY(rotateX(o.normal, _Time.y), _Time.y*0.5));
				float4 vertexWorld = mul(UNITY_MATRIX_M, vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.viewDir = vertexWorld - _WorldSpaceCameraPos;

				float shade = dot(normalize(o.viewDir), o.normal)*0.5+0.5;
				o.color = lerp(_Color, float4(o.normal*0.5+0.5,1.), shade);
				
				// distance from camera
				o.infos.x = mul(UNITY_MATRIX_MV, v.vertex).z;

				o.vertex = mul(UNITY_MATRIX_VP, vertexWorld);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.texcoord) * i.color;
				col.rgb *= smoothstep(0.0, 0.5, sin(i.infos.x*0.5));
				return col;
			}
			ENDCG
		}
	}
}
