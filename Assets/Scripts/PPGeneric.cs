using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPGeneric : MonoBehaviour
{
    PostProcessVolume p_volume;
    AmbientOcclusion p_ambientOcclusion;
    ChromaticAberration p_chromaticAberation;
    Bloom p_bloom;
    ColorGrading p_colorGrading;
    MotionBlur p_motionBlur;
    ScreenSpaceReflections p_screenSpaceReflections;
    Vignette p_vignette;

 

    // Start is called before the first frame update
    void Start()
    {
        p_ambientOcclusion = ScriptableObject.CreateInstance<AmbientOcclusion>();
        p_chromaticAberation = ScriptableObject.CreateInstance<ChromaticAberration>();
        p_bloom = ScriptableObject.CreateInstance<Bloom>();
        p_colorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        p_motionBlur = ScriptableObject.CreateInstance<MotionBlur>();
        p_screenSpaceReflections = ScriptableObject.CreateInstance<ScreenSpaceReflections>();
        p_vignette = ScriptableObject.CreateInstance<Vignette>();
        p_volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, p_ambientOcclusion, p_chromaticAberation, p_bloom, 
                                                            p_colorGrading, p_motionBlur, p_screenSpaceReflections, p_vignette);
        p_ambientOcclusion.enabled.Override(true);
        p_chromaticAberation.enabled.Override(true);
        p_bloom.enabled.Override(true);
        p_colorGrading.enabled.Override(true);
        p_motionBlur.enabled.Override(true);
        p_screenSpaceReflections.enabled.Override(true);
        p_vignette.enabled.Override(true); 

        p_chromaticAberation.intensity.Override(1f);
        

       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
