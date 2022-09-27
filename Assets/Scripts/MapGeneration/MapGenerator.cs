using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace MapGeneration
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private Transform point;
        [SerializeField] private int minCounts;
        [SerializeField] private int maxCounts;
        [SerializeField] private MapPart startPart;
        [SerializeField] private MapPart[] parts;
        [SerializeField] private MapPart endPart;

        private List<MapPart> _currentParts = new();
        
        [ContextMenu("generate")]
        public async Task Generate()
        {
            var random = new Random();

            var start = Instantiate(startPart, transform);
            start.transform.position = point.position - start.StartPointLocal;
            
            _currentParts.Add(start);
            
            var counts = random.Next(minCounts, maxCounts);

            for (var i = 0; i < counts; i++)
            {
                var index = random.Next(0, parts.Length);
                var part = Instantiate(parts[index], transform);
                
                var last = _currentParts.Last();
                
                part.transform.position = last.transform.position + last.EndPointLocal - part.StartPointLocal;
                _currentParts.Add(part);
                while (!part.IsInitialized)
                    await Task.Yield();
            }
            
            
            var endMapPart = Instantiate(endPart, transform);
                
            var lastMapPart = _currentParts.Last();
                
            endMapPart.transform.position = lastMapPart.transform.position + lastMapPart.EndPointLocal - endMapPart.StartPointLocal;
            _currentParts.Add(endMapPart);
        }
    }
}