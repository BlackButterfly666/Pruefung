Shader "Unlit/FarbfrontShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}

		_RedDrops ("RedDrops", Range(0.0, 1.0)) = 0.0
		_GreenDrops ("GreenDrops", Range(0.0, 1.0)) = 0.0
		_BlueDrops ("BlueDrops", Range(0.0, 1.0)) = 0.0
		_MinValue ("MinValue", Range(0.0, 0.2)) = 0.0
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

			float _RedDrops;
			float _GreenDrops;
			float _BlueDrops;
			float _MinValue;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			// type wie struct in C#
			struct hsv {
				float h;
				float s;
				float v;
			};
			hsv toHsv(float3 c)
			{
				float minimum, maximum, delta;
				minimum = min(min(c.r, c.g), c.b);
				maximum = max(max(c.r, c.g), c.b);

				hsv hsv;
				hsv.v = maximum;

				delta = maximum - minimum;

				if (delta < 0.000001)
				{
					hsv.h = 0.0;
					hsv.s = 0.0;
					return hsv;
				}

				if (maximum <= c.r)
				{
					hsv.h = (c.g - c.b) / delta;
				}
				else if (maximum <= c.g)
				{
					hsv.h = 2 + (c.b - c.r) / delta;
				}
				else if (maximum <= c.b)
				{
					hsv.h = 4 + (c.r - c.g) / delta;
				}
				hsv.h *= 60.0;

				if (hsv.h < 0)
					hsv.h += 360.0;

				hsv.s = delta / maximum;

				return hsv;
			}

			float3 toRgb(hsv hsv)
			{
				float3 rgb;

				float chroma = hsv.v * hsv.s;
				float h_ = hsv.h / 60.0;

				float x = chroma * (1.0 - abs(fmod(h_ , 2.0) - 1));
				if (h_ < 0.0)
				{
					rgb = float3(0.0,0.0,0.0);
					return rgb;
				}
				else if (h_ <= 1.0)
				{
					rgb = float3(chroma, x, 0.0);
				}
				else if (h_ <= 2.0)
				{
					rgb = float3(x, chroma, 0.0);
				}
				else if (h_ <= 3.0)
				{
					rgb = float3(0.0, chroma, x);
				}
				else if (h_ <= 4.0)
				{
					rgb = float3(0.0, x, chroma);
				}
				else if (h_ <= 5.0)
				{
					rgb = float3(x, 0.0, chroma);
				}
				else if (h_ <= 6.0)
				{
					rgb = float3(chroma, 0.0, x);
				}

				float m = hsv.v - chroma;

				rgb += float3(m, m, m);


				return rgb;
			}
			float shortestAngle(float diff)
			{
				if (diff < 0)
				{
					diff = 360.0 + diff;
				}
				if (diff > 180.0)
				{
					diff = 360.0 - diff;
				}

				return diff;
			}
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);

				//col.rgb = float3(0.0, 0.0, 1.0);

				hsv hsv = toHsv(col.rgb);

				float diffBlue = 1.0-clamp(abs(shortestAngle(hsv.h - 240.0) / 120.0),0,1);
				float diffRed = 1.0-clamp(abs(shortestAngle(hsv.h - 0.0) / 120.0),0,1);
				float diffGreen = 1.0-clamp(abs(shortestAngle(hsv.h - 120.0) / 120.0),0,1);

				float sat = (diffBlue * _BlueDrops + diffRed * _RedDrops + diffGreen * _GreenDrops);

				hsv.s *= sat;

				float minValue = _MinValue;

				float value = minValue + ((1.0 - minValue) * (_RedDrops + _GreenDrops + _BlueDrops) / 3.0);

				hsv.v *= value;
				
				col.rgb = toRgb(hsv);

				return col;
			}
			ENDCG
		}
	}
}
