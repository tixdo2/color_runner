using ColorSystem;
using UnityEngine;

namespace MapGeneration
{
    public class MapPart : MonoBehaviour
    {
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform endPoint;

        [SerializeField] private DecorateZone zone;
        

        public Vector3 StartPointLocal => startPoint.localPosition;
        public Vector3 EndPointLocal => endPoint.localPosition;

        public bool IsInitialized => zone.IsInitialized;
    }
}