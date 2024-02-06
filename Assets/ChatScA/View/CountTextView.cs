using UnityCleanArchitectureExample;
using UnityEngine;
using VContainer;
using UnityEngine.UI;
using MessagePipe;
using System;

public class CountTextView : MonoBehaviour
{
    public CountType Type;

    [Inject]
    private ICountPresenter _presenter;
    [Inject]
    private ISubscriber<CountUpdatedMessage> _subscriber;
    private IDisposable _disposable;
    private Text _text;
    private void Start()
    {
        _text = GetComponent<Text>();
        UpdateText(_presenter.GetCount(Type));

        _disposable = _subscriber.Subscribe(msg =>
        {
            UpdateText(msg.Counts[0].Num);
        });

    }
    private void UpdateText(int count)
    {
        _text.text = string.Format("Count {0} = {1}", Type.ToString(), count);
    }
    public void Dispose()
    {
        _disposable?.Dispose();
    }
}
