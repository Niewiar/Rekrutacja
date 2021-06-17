using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [Space(10)]
    public InputAction openClosePanel;
    public InputAction selectOption;
    public InputAction acceptOption;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI[] _options;
    [SerializeField] private TextMeshProUGUI title;

    private int _currentOption;
    private bool _panelActive;

    [HideInInspector] public bool playerDead;

    private void Awake()
    {
        _panelActive = false;
        _panel.SetActive(false);
        _currentOption = 0;

        selectOption.performed += _ => SwitchOption();
        openClosePanel.performed += _ => OpenClosePanel();
        acceptOption.performed += _ => AcceptOption();
    }

    void OnEnable()
    {
        openClosePanel.Enable();
        selectOption.Enable();
        acceptOption.Enable();
    }

    void OnDisable()
    {
        openClosePanel.Disable();
        selectOption.Disable();
        acceptOption.Disable();
    }

    public void ShowActiveOption()
    {
        if (_currentOption == 0)
        {
            _options[0].fontSize = 120;
            _options[1].fontSize = 100;
        }
        else
        {
            _options[1].fontSize = 120;
            _options[0].fontSize = 100;
        }
    }

    public void OpenClosePanel()
    {
        if (!playerDead)
        {
            title.SetText("PAUSE");
            if (!_panelActive)
            {
                _panelActive = true;
                _panel.SetActive(true);
                ShowActiveOption();
                Time.timeScale = 0;
            }
            else
            {
                _panelActive = false;
                _panel.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else
        {
            title.SetText("LOSE");
            _panelActive = true;
            _panel.SetActive(true);
            ShowActiveOption();
            Time.timeScale = 0;
        }
    }

    public void SwitchOption()
    {
        if (_currentOption + 1 == _options.Length)
        {
            _currentOption = 0;
            ShowActiveOption();
        }
        else
        {
            _currentOption++;
            ShowActiveOption();
        }
    }

    public void AcceptOption()
    {
        if (_panelActive)
        {
            if (_currentOption == 0)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            }
        }
    }
}
