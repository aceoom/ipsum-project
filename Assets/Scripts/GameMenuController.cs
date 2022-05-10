using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject container;

    [SerializeField]
    private ConfirmWindow exitConfirm;

    [Header("Buttons")]
    [SerializeField]
    private Button resumeButton;
    [SerializeField]
    private Button exitButton;

    private bool isVisible;

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
        resumeButton.onClick.AddListener(HandleResume);
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
        container.SetActive(!container.activeInHierarchy);
    }

    private void HandleResume()
    {
        container.SetActive(false);
    }

    private void HandleExit()
    {
        exitConfirm.Open();
    }

    private void HandleExitConfirm()
    {
        exitConfirm.Close();
        LoadMainMenu();
    }

    private void HandleExitCancel()
    {
        exitConfirm.Close();
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }
}
