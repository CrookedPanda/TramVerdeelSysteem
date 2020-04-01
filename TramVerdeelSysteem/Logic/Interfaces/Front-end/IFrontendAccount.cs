using System;
using System.Collections.Generic;
using System.Text;
using Model.ViewModels;

namespace Logic.Interfaces.Front_end
{
    public interface IFrontendAccount
    {
        LoginViewModel LogIn();

        bool LogOut();

        RegisterViewModel AddAccount();
    }
}
