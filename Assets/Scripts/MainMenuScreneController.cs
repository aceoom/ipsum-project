using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScreneController : MonoBehaviour
{
    [SerializeField]
    private ConfirmWindow exitConfirm;

    [Header("Buttons")]
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button exitButton;

    private PlayerInput playerInput;
    private InputAction toggleOpenedInputAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        toggleOpenedInputAction = playerInput.actions["Exit"];
    }

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(HandlePlay);
        exitButton.onClick.AddListener(HandleExit);

        exitConfirm.Setup("Confirm exit", "Are you sure to exit?");
        exitConfirm.OnConfirm += HandleExitConfirm;
        exitConfirm.OnCancel += HandleExitCancel;

        toggleOpenedInputAction.performed += HandleToggleOpened;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        toggleOpenedInputAction.performed -= HandleToggleOpened;
    }

    private void HandleToggleOpened(InputAction.CallbackContext context)
    {
        exitConfirm.ToggleOpened();
    }

    private void HandlePlay()
    {
        SceneManager.LoadScene(SceneName.Gameplay.ToString());
    }

    private void HandleExit()
    {
        exitConfirm.Open();
    }

    private void HandleExitConfirm()
    {
        exitConfirm.Close();
        Exit();
    }

    private void HandleExitCancel()
    {
        exitConfirm.Close();
    }

    private void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
