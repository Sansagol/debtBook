using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DebtBook
{
    class RelationCommand : ICommand
    {
        Action<object> _ExecuteAction = null;
        Func<object, bool> _CanExecute = null;

        public event EventHandler CanExecuteChanged;

        public RelationCommand(Action<object> executeAction) :
            this(executeAction, (d) => { return true; })
        {
        }

        public RelationCommand(
            Action<object> executeAction,
            Func<object, bool> canExecute)
        {
            _ExecuteAction = executeAction;
            _CanExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return _CanExecute != null ? _CanExecute(parameter) : true;
        }

        /// <summary>Evecute a command method.</summary>
        /// <param name="parameter">Parameter passed to method.</param>
        /// <exception cref="NotImplementedException">
        /// Execute method is null.
        /// </exception>
        public void Execute(object parameter)
        {
            if (_ExecuteAction != null)
                _ExecuteAction(parameter);
            else
                throw new NotImplementedException("Execute method not implemented.");
        }

        public void FourceUpdeteCanExecute()
        {
            CanExecuteChanged?.Invoke(this, null);
        }
    }
}
