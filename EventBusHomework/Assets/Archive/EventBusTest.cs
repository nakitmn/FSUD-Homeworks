// using System;
// using Atomic.Events;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class EventBusTest : MonoBehaviour
//     {
//         [SerializeField]
//         private SceneEventBus _eventBus;
//         
//         private void Awake()
//         {
//             _eventBus.SubscribeHello(this.OnHelloWorld);
//             // subscription.Dispose();
//             
//             // _eventBus.Subscribe("HelloWorld", this.OnHelloWorld);
//         }
//
//         private void OnDestroy()
//         {
//             // _eventBus.Dispose("HelloWorld") //TODO:
//             
//             
//             // _eventBus.UnsubscribeHello(this.OnHelloWorld);
//             // _eventBus.Unsubscribe("HelloWorld", this.OnHelloWorld);
//         }
//
//         [Button]
//         public void HelloWorld()
//         {
//             _eventBus.InvokeHello();
//             // _eventBus.Invoke("HelloWorld");
//         }
//
//         private void OnHelloWorld()
//         {
//             Debug.Log("HELLO WORLD TRIGGERED");
//         }
//     }
// }