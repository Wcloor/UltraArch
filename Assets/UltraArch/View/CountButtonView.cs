using UnityCleanArchitectureExample;
using UnityEngine;
using VContainer;
using UnityEngine.UI;

public class CountButtonView : MonoBehaviour
{
    public CountType Type;

    [Inject]
    private ICountPresenter _presenter;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => {_presenter.IncrementCount(Type); });
    }
}
