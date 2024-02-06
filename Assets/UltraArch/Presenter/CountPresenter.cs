using MessagePipe;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace UnityCleanArchitectureExample
{
    public interface ICountPresenter
    {
        void Initialize(ICountUsecase usecase);
        void IncrementCount(CountType type);
        int GetCount(CountType type);
    }
    public interface ICountUsecase
    {
        void IncrementCount(CountType type);
        Dictionary<CountType, Count> GetCounts();
        int GetCount(CountType type);
    }
    public class CountPresenter : ICountPresenter
    {
        private ICountUsecase _usecase;
        private ISubscriber<CountUpdatedMessage> _subscriber;
        private IDisposable _disposable;

        public CountPresenter(ISubscriber<CountUpdatedMessage> subscriber,ICountUsecase countUsecase)
        {
            _subscriber = subscriber;
            _usecase = countUsecase;
        }
        public void Initialize(ICountUsecase usecase)
        {
            _usecase = usecase;
            _disposable = _subscriber.Subscribe(msg =>
            {
                UpdateCount(msg.Counts);
            }
           );
            UpdateCount(_usecase.GetCounts());
        }
        private void UpdateCount(Dictionary<CountType, Count> dict)
        {  
        }

        public void IncrementCount(CountType type)
        {
            _usecase.IncrementCount(type);
        }
        public void Dispose()
        {
            _disposable?.Dispose();
        }
        public int GetCount(CountType type)
        {
            return _usecase.GetCount(type);
            
        }

    }

}

