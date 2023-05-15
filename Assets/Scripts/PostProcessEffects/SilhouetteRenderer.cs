using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PostProcessEffects
{
    public class SilhouetteRenderer  : PostProcessEffectRenderer<Silhouette>
    {
        public static RenderTexture RenderTexture;
        public override void Render(PostProcessRenderContext context)
        {
            if (RenderTexture == null 
                || RenderTexture.width != Screen.width 
                || RenderTexture.height != Screen.height) 
            {
                RenderTexture = new RenderTexture(Screen.width, Screen.height, 24);
                context.camera.targetTexture = RenderTexture;
                // Dbg.Red("Created a render texture");
            }
            // context.camera.targetTexture = RenderTexture;
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Silhouette"));
            sheet.properties.SetVector("_MainColor", settings.color);
            sheet.properties.SetFloat("_Step", settings.step);
            sheet.properties.SetFloat("_MinBrightness", settings.minBrightness);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}