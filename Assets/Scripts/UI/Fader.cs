using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace UI
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private MMF_Player fadeIn;
        [SerializeField] private MMF_Player fadeOut;
        

        public void FadeIn()
        {
            fadeOut.StopFeedbacks();
            fadeIn.PlayFeedbacks();
        }

        public void FadeOut()
        {
            fadeIn.StopFeedbacks();
            fadeOut.PlayFeedbacks();
        }
        
    }
}