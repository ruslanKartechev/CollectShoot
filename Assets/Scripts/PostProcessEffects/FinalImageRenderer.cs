using GameCore.Utils;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PostProcessEffects
{
    public class FinalImageRenderer  : PostProcessEffectRenderer<FinalImage>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var beldnWith = SilhouetteRenderer.RenderTexture;
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/FinalImage"));
            if(beldnWith != null)
                sheet.properties.SetTexture("_SilhouetteTexture" ,beldnWith);
            else
                Dbg.Red("BLEND WITH TEXTURE IS NULL");

            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}