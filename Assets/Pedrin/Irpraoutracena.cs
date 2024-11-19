using UnityEngine;
using UnityEngine.SceneManagement;  // Biblioteca para gerenciar cenas

public class Irpraoutracena : MonoBehaviour
{
    // Nome da cena que ser� carregada
    public string sceneToLoad = "Level2";  // Defina o nome da sua cena aqui

    void Update()
    {
        // Detecta quando a tecla F � pressionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Carrega a cena pelo nome
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
