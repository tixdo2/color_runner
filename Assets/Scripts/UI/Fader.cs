using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private MMF_Player fadeIn;
        [SerializeField] private MMF_Player fadeOut;

        [SerializeField] private UnityEvent onFadeIn;
        [SerializeField] private UnityEvent onFadeOut;
        
        public void FadeIn(UnityAction onComplete = null)
        {
            if(onComplete != null)
                onFadeIn.AddListener(onComplete);
            
            fadeOut.StopFeedbacks();
            fadeIn.PlayFeedbacks();
        }

        public void OnFadeIn()
        {
            onFadeIn?.Invoke();
            onFadeIn.RemoveAllListeners();
        }

        public void FadeOut(UnityAction onComplete = null)
        {
            if(onComplete != null)
                onFadeOut.AddListener(onComplete);
            
            fadeIn.StopFeedbacks();
            fadeOut.PlayFeedbacks();
        }

        public void OnFadeOut()
        {
            onFadeOut?.Invoke();
            onFadeOut.RemoveAllListeners();
        }
        
    }
}