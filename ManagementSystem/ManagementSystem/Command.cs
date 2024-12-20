﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ManagementSystem
{
    internal class Command : ICommand
    {
        Action<object> ExecuteMehod;
        Func<object, bool> CanExecuteMehod;

        public Command(Action<object> executeMehod, Func<object, bool> canExecuteMehod)
        {
            this.ExecuteMehod = executeMehod;
            this.CanExecuteMehod = canExecuteMehod;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ExecuteMehod(parameter);
        }
    }
}
