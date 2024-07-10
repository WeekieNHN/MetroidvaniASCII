//Made By Stefan Jovanović
//Twitter: https://twitter.com/SJovGD
//Reddit: https://www.reddit.com/user/sjovanovic3107
//Unity Asset Store: https://assetstore.unity.com/publishers/32235
//Itch.io: https://stefanjo.itch.io/

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

namespace UnityStandardAssets.ImageEffects
{
    [ExecuteInEditMode]
    public class ASCIIRendering : MonoBehaviour
    {
        public Camera ourCamera;
        public RenderTexture source;
        public RenderTexture destination;

        //Variables required for the ImageEffect
        public Shader ASCIIShader;
        private Material m_ASCII;

        //Values for the Shader
        public Texture2D CharTex;
        public int tilesX = 96;
        public int tilesY = 54;
        public int charWidth = 20;
        public int charHeight = 20;
        public int charCount = 8;
        public float brightness = .8f;
        public bool monochromatic = false;

        // Add your callback to the delegate's invocation list
        private void Start()
        {
            RenderPipelineManager.beginCameraRendering += PreRender;
        }

        private void OnDestroy()
        {
            RenderPipelineManager.beginCameraRendering -= PreRender;
        }

        private void PreRender(ScriptableRenderContext context, Camera cam)
        {
            if (cam != ourCamera) return;

            m_ASCII = new Material(ASCIIShader);
            m_ASCII.SetTexture("_CharTex", CharTex);

            m_ASCII.SetFloat("_tilesX", tilesX);
            m_ASCII.SetFloat("_tilesY", tilesY);
            m_ASCII.SetFloat("_tilesW", charWidth);
            m_ASCII.SetFloat("_tilesH", charHeight);
            m_ASCII.SetFloat("_charCount", charCount);
            m_ASCII.SetFloat("_monochromatic", (float)Convert.ToDouble(monochromatic));
            m_ASCII.SetFloat("_brightness", brightness);
            
            Graphics.Blit(source, destination, m_ASCII);
        }
    }
}
