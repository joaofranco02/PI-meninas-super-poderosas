using UnityEngine;
using UnityEngine.SceneManagement; // Necess�rio para manipular as cenas

public class TrocaDeCenario : MonoBehaviour
{
    // M�todo para carregar uma cena pelo nome
    public void TrocarCenarioPorNome(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    // M�todo para carregar uma cena pelo �ndice
    public void TrocarCenarioPorIndice(int indiceCena)
    {
        SceneManager.LoadScene(indiceCena);
    }
}
