using System;
using UnityEngine;

namespace EndlessFaller.Input
{
    public class UserInputRaiser : IInputRaiser
    {
        public event Action<Vector2> OnMoveCommand;
        private const string InputAxisName = "Horizontal";

        public void Update()
        {
            float input = UnityEngine.Input.GetAxis(InputAxisName);

            if (input != 0)
            {
                OnMoveCommand?.Invoke(new Vector2(input, 0));
            }
        }
    }
}