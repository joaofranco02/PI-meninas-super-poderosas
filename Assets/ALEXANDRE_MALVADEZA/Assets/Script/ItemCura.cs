using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeControl : MonoBehaviour
{
    private int vida;
    private int vidaMaxima = 3;

    [SerializeField] private Image[] vidaOn;  // Imagens de corações ativos
    [SerializeField] private Image[] vidaOff;  // Imagens de corações vazios

    void Start()
    {
        vida = vidaMaxima;
        AtualizarVidaUI();
    }

    // Método para perder vida
    public void PerderVida()
    {
        vida--;
        if (vida < 0) vida = 0; // Garante que a vida não fique negativa
        AtualizarVidaUI();

        if (vida <= 0)
        {
            SceneManager.LoadScene(2); // Carrega a cena de Game Over
        }
    }

    // Método para ganhar vida
    public void GanharVida(int quantidade)
    {
        vida += quantidade;
        if (vida > vidaMaxima) vida = vidaMaxima; // Garante que a vida não ultrapasse o máximo
        AtualizarVidaUI();
    }

    // Atualiza a interface do usuário
    private void AtualizarVidaUI()
    {
        for (int i = 0; i < vidaMaxima; i++)
        {
            vidaOn[i].enabled = (vida > i);
            vidaOff[i].enabled = !vidaOn[i].enabled;
        }
    }
}

