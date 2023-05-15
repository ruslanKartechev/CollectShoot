using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PostProcessEffects
{
    [Serializable]
    [PostProcess(typeof(GrayscaleRenderer), PostProcessEvent.AfterStack, "Custom/Grayscale")]
    public sealed class Grayscale : PostProcessEffectSettings
    {
        [Range(0f, 1f), Tooltip("Grayscale effect intensity.")]
        public FloatParameter blend = new FloatParameter { value = 0.5f };
        public FloatParameter grayR = new FloatParameter { value = 0.5f };
        public FloatParameter grayG = new FloatParameter { value = 0.5f };
        public FloatParameter grayB = new FloatParameter { value = 0.5f };
        public FloatParameter brightness = new FloatParameter { value = 0.5f };

        
    }
}
