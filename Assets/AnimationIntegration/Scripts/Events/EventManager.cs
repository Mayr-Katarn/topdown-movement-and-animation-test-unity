using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent<UiMessageType> OnShowUiMessage = new UnityEvent<UiMessageType>();
    public static UnityEvent OnFinishAnimationEnd = new UnityEvent();
    public static UnityEvent OnFinishAnimationHitEnemy = new UnityEvent();

    public static void SendShowUiMessage(UiMessageType msgType) => OnShowUiMessage.Invoke(msgType);
    public static void SendFinishAnimationHitEnemy() => OnFinishAnimationHitEnemy.Invoke();
    public static void SendFinishAnimationEnd() => OnFinishAnimationEnd.Invoke();
}
