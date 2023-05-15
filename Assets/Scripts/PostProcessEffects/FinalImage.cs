using System;
using UnityEngine.Rendering.PostProcessing;

namespace PostProcessEffects
{
    [Serializable]
    [PostProcess(typeof(FinalImageRenderer), PostProcessEvent.AfterStack, "Custom/FinalImage")]
    public sealed class FinalImage : PostProcessEffectSettings
    {
    }
}