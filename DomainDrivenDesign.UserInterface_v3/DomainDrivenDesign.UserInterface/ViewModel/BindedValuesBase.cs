using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DomainDrivenDesign.UserInterface
{
    /// <summary>
    /// ViewModelの基底クラス
    /// </summary>

    public abstract class BindedValuesBase : INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChanged
        /// </summary>

        private SynchronizationContext _userInterfaceContext;
        public event PropertyChangedEventHandler PropertyChanged;

        public BindedValuesBase()
        {
            _userInterfaceContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// SetProperty
        /// </summary>

        /// <typeparam name="T">T</typeparam>
        /// <param name="field">field</param>
        /// <param name="value">value</param>
        /// <param name="propertyName">propertyName</param>
        /// <returns>returns</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;

            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                _userInterfaceContext.Post(new SendOrPostCallback(_ =>
                {
                    propertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }), null);
            }

            return true;
        }
    }
}