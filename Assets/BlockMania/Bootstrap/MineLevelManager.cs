using UnityEngine.SceneManagement;

namespace BlockMania.Bootstrap
{
    public class MineLevelManager
    {
        public int CurrentMineLevel { get; private set; }

        public void MineLevelUp()
        {
            CurrentMineLevel++;
            SceneManager.LoadScene("Mine");
        }

        public void MineLevelDown()
        {
            CurrentMineLevel--;
            SceneManager.LoadScene("Mine");
        }

        public void SetCurrentMineLevel(int value)
        {
            CurrentMineLevel = value;
        }
    }
}