using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para manipular as cenas

public class TrocaDeCenario : MonoBehaviour
{
    // Método para carregar uma cena pelo nome
    public void TrocarCenarioPorNome(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    // Método para carregar uma cena pelo índice
    public void TrocarCenarioPorIndice(int indiceCena)
    {
        SceneManager.LoadScene(indiceCena);
    }
}
