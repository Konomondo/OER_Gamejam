using System;
using System.Collections;
using System.Collections.Generic;
using CCC;
using CCC.Utility;
using UnityEngine;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    private UIDocument _confirmationUIDoc;

    private Button _confirmButton;

    [SerializeField] private GameEvent SubmitChoice;

    private void Awake()
    {
        _confirmationUIDoc = GetComponent<UIDocument>();
        _confirmButton = _confirmationUIDoc.rootVisualElement.Q<Button>();
        _confirmButton.clicked += OnPressConfirm;
    }

    private void OnDestroy()
    {
        _confirmButton.clicked -= OnPressConfirm;
    }

    private void OnPressConfirm()
    {
        SubmitChoice.Raise();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryTogglePatternSelection();
        }
    }

    private void TryTogglePatternSelection()
    {
        var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.TryGetComponent(out PatternSelector ps))
                ps.ClickedPattern();
        }
    }
}