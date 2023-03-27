using DefaultNamespace.Runner.UI;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AboutView : AbstractView
{
    [SerializeField] private TextMeshProUGUI _aboutText;
    [SerializeField] private Button _menuButton;
    private const string FilePath = "About";

    private void Start()
    {
        Init();
    }

    protected override void OnEnable()
    {
        _menuButton.onClick.AddListener(OnMenuButtonClicked);
    }

    protected override void OnDisable()
    {
        _menuButton.onClick.RemoveListener(OnMenuButtonClicked);
    }

    public override void Init()
    {
        TextAsset file = (TextAsset)Resources.Load(FilePath);

        _aboutText.text = file.text;
    }

    public void Show(bool value)
    {
        gameObject.SetActive(value);
    }

    private void OnMenuButtonClicked()
    {
        Show(false);
    }
}
