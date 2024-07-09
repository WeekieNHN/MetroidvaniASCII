using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ASCIIFeature : ScriptableRendererFeature
{
    public Material fullscreenMaterial;

    class FullscreenPass : ScriptableRenderPass
    {
        private Material fullscreenMaterial;

        public FullscreenPass(Material material)
        {
            fullscreenMaterial = material;
            renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get("Fullscreen Pass");

            // Set up a temporary RenderTexture for intermediate rendering
            int tempRT = Shader.PropertyToID("_TempRT");

            cmd.GetTemporaryRT(tempRT, renderingData.cameraData.cameraTargetDescriptor);
            cmd.Blit(renderingData.cameraData.renderer.cameraColorTargetHandle, tempRT);

            // Set the global shader properties
            cmd.SetGlobalTexture("_MainTex", tempRT);

            // Blit the temporary RenderTexture to the final camera target using the fullscreen material
            cmd.Blit(tempRT, renderingData.cameraData.renderer.cameraColorTargetHandle, fullscreenMaterial);

            // Release temporary resources
            cmd.ReleaseTemporaryRT(tempRT);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }

    FullscreenPass fullscreenPass;

    public override void Create()
    {
        fullscreenPass = new FullscreenPass(fullscreenMaterial);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(fullscreenPass);
    }
}
