using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    /* Singleton */
    private static GameManager instance;

    [Tooltip("Referencia al contador de monedas en la interfaz")]
    [SerializeField]
    private Text coinsCounter;

    [Tooltip("Referencia al panel de final de partida")]
    [SerializeField]
    private GameObject gameOverPanel;

    [Tooltip("Referencia al panel de nivel finalizado")]
    [SerializeField]
    private GameObject levelFinishedPanel;

    [Tooltip("Referencia al panel de pausa")]
    [SerializeField]
    private GameObject pausePanel;

    // Propiedad que almacena el número de monedas recolectadas por el jugador
    private int coins;
    public static int Coins {
        get {
            return instance.coins;
        }
        set {
            instance.coins = value;
            instance.coinsCounter.text = value.ToString("00");
        }
    }

    #region Unity Messages

    private void Awake() {
        /* Singleton (se da por hecho que nunca habrá más de una instancia del GameManager) */
        instance = this;
    }

    private void Start() {
        // Se asegura que el juego no comienza pausado
        Time.timeScale = 1;
    }

    private void Update() {
        // Botón de pausa
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseButtonPressed();
        }
    }

    #endregion

    #region Public Static Messages

    public static void GameOver() {
        // Muestra la pantalla de final de partida
        instance.gameOverPanel.SetActive(true);
        instance.Invoke("LoadGame", 3.0f);
    }

    public static void LevelFinished() {
        // Muestra la pantalla de nivel finalizado
        instance.levelFinishedPanel.SetActive(true);
        instance.Invoke("LoadGame", 3.0f);
    }

    #endregion

    private void LoadGame() {
        // Carga la escena del juego
        SceneManager.LoadScene(0);
    }

    private void PauseButtonPressed() {
        // Comprueba si el juego estaba pausado o en ejecución para cambiar su estado
        if (Time.timeScale == 1) {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        } else {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}