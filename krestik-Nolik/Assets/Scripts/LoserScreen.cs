using UnityEngine.SceneManagement;

namespace Client {
    public class LoserScreen : Screen 
    {
        public void OnRestertClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}