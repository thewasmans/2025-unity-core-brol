using UnityEngine;

public class InputManager : BGSManager
{
    [field: SerializeField] public MonoBehaviour[] InputInterractions { get; private set; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var entry in InputInterractions)
            {
                if(entry is IInputInterraction interraction)
                {
                    interraction.InterractionPressed();
                }
            }
        }
    }
}
