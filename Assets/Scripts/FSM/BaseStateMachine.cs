using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] private BaseState _initialState;
        private Dictionary<Type, Component> _cachedComponents = new Dictionary<Type, Component>();

        private void Awake()
        {
            CurrentState = _initialState;

            Component[] components = gameObject.GetComponents(typeof(Component));
            foreach (Component component in components)
            {
                _cachedComponents.Add(component.GetType(), component);
            }
        }

        public BaseState CurrentState { get; set; }

        private void Update()
        {
            CurrentState.Execute(this);
        }

        
        public new T GetComponent<T>() where T : Component
        {
            if (_cachedComponents.ContainsKey(typeof(T)))
                return _cachedComponents[typeof(T)] as T;


            var component = base.GetComponent<T>();
            if (component != null)
            {
                _cachedComponents.Add(typeof(T), component);
            }
            return component;
        }
    }
}
