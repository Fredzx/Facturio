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

        private Predicate<object> _canExecute;
        private Action<object> _execute;

        #endregion

        #region Constructeur

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        #endregion

        #region Événement CanExecuteChanged

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #endregion

        #region Méthodes CanExecute et Execute

        public bool CanExecute(object parameter) => _canExecute(parameter);
        public void Execute(object parameter) => _execute(parameter);

        #endregion
    }
}
