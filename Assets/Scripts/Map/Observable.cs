using System.Collections.Generic;
using UnityEngine;

namespace Map {
    public abstract class Observable : MonoBehaviour {
        private List<ISubscriber> subscribers = new List<ISubscriber>();

        public void Subscribe(ISubscriber subscriber) {
            subscribers.Add(subscriber);
        }

        protected void InvokeAllSubscribers() {
            foreach (var subscriber in subscribers) {
                subscriber.Invoke();
            }
        }
    }
}