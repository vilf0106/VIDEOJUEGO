using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorDelJuego : MonoBehaviour
{
    public GameObject menuPausaUI;
    private bool estaPausado = false;

    void Start()
    {
        Time.timeScale = 1;
        if (menuPausaUI != null)
        {
            menuPausaUI.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AlternarPausa();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarJuego();
        }
    }

    public void AlternarPausa()
    {
        if (estaPausado)
        {
            ReanudarJuego();
        }
        else
        {
            PausarJuego();
        }
    }

    public void PausarJuego()
    {
        Time.timeScale = 0;
        estaPausado = true;
        if (menuPausaUI != null)
        {
            menuPausaUI.SetActive(true);
        }
        Debug.Log("Juego pausado");
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1;
        estaPausado = false;
        if (menuPausaUI != null)
        {
            menuPausaUI.SetActive(false);
        }
        Debug.Log("Juego reanudado");
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Reiniciando juego");
    }
}
