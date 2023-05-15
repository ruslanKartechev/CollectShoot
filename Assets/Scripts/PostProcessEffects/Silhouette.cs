using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PostProcessEffects
{
    [Serializable]
    [PostProcess(typeof(SilhouetteRenderer), PostProcessEvent.AfterStack, "Custom/Silhouette")]
    public sealed class Silhouette : PostProcessEffectSettings
    {
        public ColorParameter color = new ColorParameter {value = Color.white};
        public FloatParameter step = new FloatParameter {value = 0.02f};
        public FloatParameter minBrightness = new FloatParameter {value = 0.3f};
        

    }
}