using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIToolkitControls : MonoBehaviour
{
    [SerializeField]
    private UIDocument _uiDocument;
    private VisualElement _uiTree;
    private Button _button;
    private VisualElement _hiddenBox;

    private void OnEnable()
    {
       _uiTree = _uiDocument.rootVisualElement as VisualElement;
        if(_uiTree != null)
        {
            _hiddenBox = _uiTree.Q<VisualElement>("box");
            _button = _uiTree.Q<Button>("open-button");
            _button.clickable.clicked += () =>
            {
                _hiddenBox.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.Flex);
            };
        }
    }
}
