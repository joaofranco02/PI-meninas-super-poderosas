using UnityEngine;
using UnityEngine.SceneManagement;  // Corrigido de "unityEngine.ScaneManagement" para "UnityEngine.SceneManagement"

public class CameraSeguir : MonoBehaviour
{
    // M�todo para carregar uma cena pelo �ndice
    public void LoadScene(int cenaIndex)
    {
        SceneManager.LoadScene(cenaIndex);
    }

    // M�todo para reiniciar a cena atual
    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // M�todo para sair do jogo
    public void ExitGame()
    {
        Application.Quit();
        // Para o editor, voc� pode usar a seguinte linha para simular a sa�da do jogo:
        // UnityEditor.EditorApplication.isPlaying = false;
    }
}
