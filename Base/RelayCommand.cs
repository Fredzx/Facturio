using System;
using System.Windows.Input;

namespace Facturio.Base
{
    /// <summary>
    /// Permet de créer des commandes
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Champs privés

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        #endregion

        #region Constructeurs

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new NullReferenceException(nameof(execute));
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }

        #endregion

        #region Événement CanExecuteChanged

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #endregion

        #region Méthodes Execute et CanExecute

        public void Execute(object parameter) => _execute(parameter);

        public bool CanExecute(object parameter) =>
            _canExecute == null ? true : _canExecute(parameter);

        #endregion
    }
}
