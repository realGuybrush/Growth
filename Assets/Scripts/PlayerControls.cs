using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{    
    [SerializeField]
    private PlayerInput playerInputActions;
    private InputAction move, action, attack;

    [SerializeField]
    private Rigidbody2D body;
    
    [SerializeField]
    private float speed;

    [SerializeField]
    private List<bool> instruments = new List<bool>(6){false, false, false, false, false, false};

    private int damage = 1;

    private List<Malignance> workTiles = new List<Malignance>();

    private void OnEnable()
    {
        InitInputActions();
        EnableInputActions();
        SetEvents();
    }

    private void InitInputActions()
    {
        move = playerInputActions.actions.FindAction("Move");
        action = playerInputActions.actions.FindAction("Action");
        attack = playerInputActions.actions.FindAction("Attack");
    }

    private void EnableInputActions()
    {
        move?.Enable();
        action?.Enable();
        attack?.Enable();
    }

    private void SetEvents()
    {
        attack.performed += HandleAttack;
    }

    private void OnDisable()
    {
        DisableInputActions();
        RemoveEvents();
    }

    private void DisableInputActions()
    {
        move?.Disable();
        action?.Disable();
        attack?.Disable();
    }

    private void RemoveEvents()
    {
        attack.performed -= HandleAttack;
    }

    void Update()
    {
        HandleMoveCommand(move.ReadValue<Vector2>());
        if(action.inProgress)
            HandleAction();
    }

    private void HandleMoveCommand(Vector2 direction)
    {
        body.linearVelocity = direction * speed;
    }

    private void HandleAction()
    {
        for (int i = workTiles.Count-1; i >= 0; i--)
        {
            workTiles[i].UpdateWork(Time.deltaTime * (instruments[(int)workTiles[i].InstrumentToWorkThis] ? 50f : 10f));
        }
    }

    private void HandleAttack(InputAction.CallbackContext context)
    {
    }

    public void EquipItem(ItemType type)
    {
        if (type != ItemType.Machete)
            instruments[(int) type] = true;
        else
            damage = 5;
    }

    public void IncludeWorkTile(Malignance mal)
    {
        workTiles.Add(mal);
    }

    public void ExcludeWorkTile(Malignance mal)
    {
        workTiles.Remove(mal);
    }
}
