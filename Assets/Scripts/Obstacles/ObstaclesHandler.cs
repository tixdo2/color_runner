using System.Collections.Generic;
using System.Threading.Tasks;
using ColorSystem;
using UnityEngine;

namespace Obstacles
{
    public class ObstaclesHandler : MonoBehaviour
    {
        [SerializeField] private Transform[] unCorrectPoints;
        [SerializeField] private Transform[] correctPoints;
        [SerializeField] private DecorateZone zone;

        [SerializeField] private Obstacle obstaclePrefab;

        private List<Obstacle> unCorrectObstacles = new();
        private List<Obstacle> correctObstacles = new();
        private void Start()
        {
            unCorrectObstacles = CreateObstacle(unCorrectPoints);    
            correctObstacles = CreateObstacle(correctPoints);    
        }
        
        private List<Obstacle> CreateObstacle(Transform[] points)
        {
            var list = new List<Obstacle>();
            foreach (var point in points)
            {
                var obstacle = Instantiate(obstaclePrefab, point.position, Quaternion.identity, transform);
                list.Add(obstacle);
            }

            return list;
        }

        public async void UpdateColors(ColorArgs colorArgs)
        {
            while (unCorrectObstacles.Count != unCorrectPoints.Length
                   || correctObstacles.Count != correctPoints.Length)
                await Task.Yield();

            foreach (var obstacle in unCorrectObstacles)
            {
                obstacle.Initialize(colorArgs.unCorrect);
            }
            
            foreach (var obstacle in correctObstacles)
            {
                obstacle.Initialize(colorArgs.correct);
            }
        }
        
    }
}