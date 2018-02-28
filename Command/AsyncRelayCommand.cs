using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HZBot
{
    /// <summary>Provides an async implementation of the <see cref="ICommand"/> interface.
    /// The command is inactive when the command's task is running. </summary>
    public class AsyncRelayCommand : CommandBase
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="AsyncRelayCommand"/> class. </summary>
        /// <param name="execute">The function to execute. </param>
        public AsyncRelayCommand(Func<Task> execute)
            : this(execute, null) { }

        /// <summary>Initializes a new instance of the <see cref="AsyncRelayCommand"/> class. </summary>
        /// <param name="execute">The function. </param>
        /// <param name="canExecute">The predicate to check whether the function can be executed. </param>
        public AsyncRelayCommand(Func<Task> execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        #endregion Constructors

        #region Properties

        /// <summary>Gets a value indicating whether the command can execute in its current state. </summary>
        public override bool CanExecute
        {
            get { return !IsRunning && (_canExecute == null || _canExecute()); }
        }

        /// <summary>Gets a value indicating whether the command is currently running. </summary>
        public bool IsRunning { get; set; } = false;

        #endregion Properties

        #region Methods

        public async Task<bool> TryExecuteAsync()
        {
            if (!CanExecute)
                return false;

            await PrivatExecuteAsync();
            return true;
        }

        /// <summary>Defines the method to be called when the command is invoked. </summary>
        protected override async void Execute()
        {
            await PrivatExecuteAsync();
        }

        #endregion Methods

        #region Fields

        private readonly Func<bool> _canExecute;

        private readonly Func<Task> _execute;

        #endregion Fields

        private async Task PrivatExecuteAsync()
        {
            var task = _execute();
            if (task != null)
            {
                IsRunning = true;
                await task;
                IsRunning = false;
            }
        }
    }

    /// <summary>Provides an implementation of the <see cref="ICommand"/> interface. </summary>
    /// <typeparam name="TParameter">The type of the command parameter. </typeparam>
    public class AsyncRelayCommand<TParameter> : CommandBase<TParameter>
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="AsyncRelayCommand"/> class. </summary>
        /// <param name="execute">The function. </param>
        public AsyncRelayCommand(Func<TParameter, Task> execute)
            : this(execute, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AsyncRelayCommand"/> class. </summary>
        /// <param name="execute">The function. </param>
        /// <param name="canExecute">The predicate to check whether the function can be executed. </param>
        public AsyncRelayCommand(Func<TParameter, Task> execute, Predicate<TParameter> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        #endregion Constructors

        #region Properties

        /// <summary>Gets a value indicating whether the command is currently running. </summary>
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            private set
            {
                _isRunning = value;
                RaiseCanExecuteChanged();
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>Gets a value indicating whether the command can execute in its current state. </summary>
        /// <param name="parameter">todo: describe parameter parameter on CanExecute</param>
        [DebuggerStepThrough]
        public override bool CanExecute(TParameter parameter)
        {
            return !IsRunning && (_canExecute == null || _canExecute(parameter));
        }

        public async Task<bool> TryExecuteAsync(TParameter parameter)
        {
            if (!CanExecute(parameter))
                return false;
            await PrivateExecuteAsync(parameter);
            return true;
        }

        /// <summary>Defines the method to be called when the command is invoked. </summary>
        /// <param name="parameter">todo: describe parameter parameter on Execute</param>
        protected override async void Execute(TParameter parameter)
        {
            await PrivateExecuteAsync(parameter);
        }

        #endregion Methods

        #region Fields

        private readonly Predicate<TParameter> _canExecute;

        private readonly Func<TParameter, Task> _execute;

        private bool _isRunning;

        #endregion Fields

        private async Task PrivateExecuteAsync(TParameter parameter)
        {
            var task = _execute(parameter);
            if (task != null)
            {
                IsRunning = true;
                await task;
                IsRunning = false;
            }
        }
    }
}