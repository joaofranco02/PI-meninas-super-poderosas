using UnityEngine;
using UnityEngine.SceneManagement;  // Corrigido de "unityEngine.ScaneManagement" para "UnityEngine.SceneManagement"

public class CameraSeguir : MonoBehaviour
{
    // Método para carregar uma cena pelo índice
    public void LoadScene(int cenaIndex)
    {
        SceneManager.LoadScene(cenaIndex);
    }

    // Método para reiniciar a cena atual
    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Método para sair do jogo
    public void ExitGame()
    {
        Application.Quit();
        // Para o editor, você pode usar a seguinte linha para simular a saída do jogo:
        // UnityEditor.EditorApplication.isPlaying = false;
    }
}
