using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInput")]
public class PlayerInput : ScriptableObject, InputActions.IGameplayActions
{
    public event UnityAction<Vector2> onMove;

    public event UnityAction onStopMove;

    public event UnityAction onDodge;

    public event UnityAction onMeleeAttack;

    InputActions inputActions;

    private void OnEnable()
    {
        inputActions = new InputActions();

        //PlayerInput继承了这个接口,所以传入this，将playinput注册为回调函数的接收者。
        inputActions.Gameplay.SetCallbacks(this);
    }
    public void EnableGameplayInput()
    {
        SwitchActionMap(inputActions.Gameplay);//启用Gameplay动作表
    }

    //切换动作表
    void SwitchActionMap(InputActionMap actionMap)
    {
        inputActions.Disable();
        actionMap.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)//持续按下
        {
            onMove?.Invoke(context.ReadValue<Vector2>());
        }
        if (context.canceled)//松开
        {
            onStopMove?.Invoke();
        }

        //switch (context.phase)
        //{
        //    case InputActionPhase.Started://按下的那一刻
        //        Debug.Log("Started");
        //        break;
        //    case InputActionPhase.Performed://持续按下
        //        Debug.Log("Performed");
        //        break;
        //    case InputActionPhase.Canceled://松开
        //        Debug.Log("Canceled");
        //        break;
        //}
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.started)//按下的那一刻
        {
            onDodge?.Invoke();
        }
    }

    public void OnMeleeAttack(InputAction.CallbackContext context)
    {
        if (context.started)//按下的那一刻
        {
            onMeleeAttack?.Invoke();
        }
    }

}
