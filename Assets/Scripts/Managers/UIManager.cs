using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            return instance == null ? null : instance;
        }
    }

    public TextMeshProUGUI brickLeftText;

    public GameObject optionBtn;

    public GameObject gameOverWindow;
    public Text gameOverText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ViewLeft();
    }

    public void ViewLeft()
    {
        if (brickLeftText != null) brickLeftText.text = GameManager.Instance.Brick.ToString();
    }
}
