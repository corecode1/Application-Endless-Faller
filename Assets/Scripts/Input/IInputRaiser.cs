using System;
using UnityEngine;

namespace EndlessFaller.Input
{
    public interface IInputRaiser
    {
        event Action<Vector2> OnMoveCommand;
        void Update();
    }
}