﻿Shader "NR/2dShader"
{
    Properties
    {
        //_MainTex ("Texture", 2D) = "white" {}
        _MainTex2 ("Texture", 2D) = "white" {}
        _Add ("Add", Range(0,1)) = 0
        _Shader ("Shader", Range(0,0.1)) = 0
        _Speed ("Speed", Range(0,1)) = 0
    }
    SubShader
    {
        //透明適応
        Tags{
            "Queue"      = "Transparent"
            "RenderType" = "Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha 
        //--

        //しらん
        Cull Off ZWrite Off ZTest Always
        //--

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            //しらん
            struct appdata{
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;};
            //--    

            //しらん
            struct v2f{
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;};
            //--

            //しらん
            v2f vert (appdata v){
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;}
            //--

            //変数定義?
            sampler2D _MainTex;
            sampler2D _MainTex2;
            float2 pos;
            float2 posShader;
            Float _Add;
            fixed4 color;
            Float _Shader;
            Float _Speed;

            //メインっぽい
            fixed4 frag (v2f i) : SV_Target
            {
                pos.x+=i.uv.x+1*_Time*_Speed;//UVいじれる
                pos.y+=i.uv.y+2.5*_Time*_Speed;
                posShader.x=pos.x-_Shader;
                posShader.y=pos.y+_Shader;


                fixed4 col = tex2D(_MainTex,i.uv);//もともとのスプライトを描画
                if(tex2D(_MainTex2, posShader).a>0.5&&tex2D(_MainTex2, pos).a<0.5)col -= tex2D(_MainTex2, posShader)*_Add/4;//テクスチャ決める
                if(tex2D(_MainTex2, pos).a>0.5)col += tex2D(_MainTex2, pos)*_Add;//テクスチャ決める
                col.a=1;
                //col.rgb = 1-col.rgb;//色反転
                return col;
            }
            ENDCG
        }
    }
}
