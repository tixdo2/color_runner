using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace ColorSystem
{
    public class EmissionTick : MonoBehaviour
    {
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private Renderer renderer;

        private Coroutine currentTick;
        
        public void ChangeColor(Color color)
        {
            renderer.sharedMaterial.SetColor("_EmissionColor", color);
        }

        public void Tick()
        {
            if(currentTick != null) StopCoroutine(currentTick);
            currentTick = StartCoroutine(TickRoutine(curve));
        }

        private IEnumerator TickRoutine(AnimationCurve animationCurve)
        {
            var time = 0f;

            while (time < 1f)
            {
                renderer.sharedMaterial.SetFloat("_Multiplier", animationCurve.Evaluate(time));
                time += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
        
    }
}