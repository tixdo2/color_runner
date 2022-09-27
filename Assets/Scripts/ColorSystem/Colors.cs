using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace ColorSystem
{
    [CreateAssetMenu(fileName = "Colors", menuName = "Parameters/Colors", order = 0)]
    public class Colors : ScriptableObject
    {
        [SerializeField] private Color[] colors;

        private Color lastColor = Color.clear;
        private bool isBusy;
        
        public async Task<ColorArgs> GetRandomColor()
        {
            while (isBusy)
                await Task.Yield();
            
            isBusy = true;
            
            var randomCorrectColor = await GetColor(lastColor);
            var randomUnCorrectColor = await GetColor(randomCorrectColor);

            lastColor = randomCorrectColor;
            isBusy = false;
            return new ColorArgs
            {
                correct = randomCorrectColor,
                unCorrect = randomUnCorrectColor
            };
        }

        private async Task<Color> GetColor(Color previousColor)
        {
            var random = new Random();
            var randomCorrectColor = previousColor;
            while (previousColor == randomCorrectColor)
            {
                var index = random.Next(0, colors.Length);

                randomCorrectColor = colors[index];
                await Task.Yield();
            } 
            return  randomCorrectColor;
        }
    }
}