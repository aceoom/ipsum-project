using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject container;

    [Header("Textes")]
    [SerializeField]
    private TextMeshProUGUI headerText;

    [SerializeField]
    private TextMeshProUGUI contentText;

    [Header("Buttons")]
    [SerializeField]
    private Button confirmButton;

    [SerializeField]
    private Button cancelButton;

    [SerializeField]
    private Button closeButton;

    public delegate void EventHandler();
    public event EventHandler OnConfirm;
    public event EventHandler OnCancel;

    private void Awake()
    {
        container.SetActive(false);
    }

    private void Start()
    {
        confirmButton.onClick.AddListener(HandleConfirm);
        cancelButton.onClick.AddListener(HandleCancel);
        closeButton.onClick.AddListener(HandleCancel);
    }

    public void Setup(string header, string content)
    {
        headerText.text = header;
        contentText.text = content;
    }

    public void Open() {
        container.SetActive(true);
    }
    public void Close() {
        container.SetActive(false);
    }

    public void ToggleOpened() {
        container.SetActive(!container.activeInHierarchy);
    }

    private void HandleConfirm()
    {
        OnConfirm?.Invoke();
    }
    private void HandleCancel()
    {
        OnCancel?.Invoke();
    }
}
