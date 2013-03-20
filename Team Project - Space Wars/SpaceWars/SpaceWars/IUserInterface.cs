using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars
{
    public interface IUserInterface
    {


        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnActionPressed;

        event EventHandler OnEnterPressed;

        event EventHandler OnZPressed;

        event EventHandler OnXPressed;

        event EventHandler OnRPressed;

        void ProcessInput();
    }
}
