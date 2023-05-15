using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PostProcessEffects
{
    public sealed class GrayscaleRenderer : PostProcessEffectRenderer<Grayscale>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Grayscale"));
            sheet.properties.SetFloat("_Blend", settings.blend);
            sheet.properties.SetFloat("_GrayR", settings.grayR);
            sheet.properties.SetFloat("_GrayG", settings.grayG);
            sheet.properties.SetFloat("_GrayB", settings.grayB);
            sheet.properties.SetFloat("_Brightness", settings.brightness);

            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}