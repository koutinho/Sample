using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Common.Controls
{
    public class DecimalTextBox : TextBox
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(DecimalTextBox), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnValueChanged)));

        // При задании типа decimal возникает исключение при использовании new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnValueChanged)), поменял на object все ОК
        // https://social.msdn.microsoft.com/Forums/vstudio/en-US/6fd4de5d-e6e3-4ce3-bc42-b9ad0c71f240/xamlparseexception-when-doing-data-binding-with-dependencyproperty?forum=wpf
        public object Value
        {
            get
            {
                return GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        public DecimalTextBox()
        {
            TextChanged += DecimalTextBox_TextChanged;
            LostFocus += DecimalTextBox_LostFocus;
        }

        private void DecimalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal value;

            if (uncompleteRegEx.IsMatch(Text.Trim()))
            {
                ResetError();
                return;
            }

            if (!fractionalBeginRegEx.IsMatch(Text.Trim()) && decimal.TryParse(Text, out value))
            {
                Value = value;
            }
            else
            {
                SetError("Не является числом");
            }
        }

        private void DecimalTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal value;

            if (decimal.TryParse(Text, out value))
            {
                Value = value;
            }
            else
            {
                SetError("Не является числом");
            }
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DecimalTextBox)d).Text = e.NewValue.ToString();
        }

        private void SetError(string errorText)
        {
            BindingExpression bindingExpression = BindingOperations.GetBindingExpression(this, ValueProperty);
            BindingExpressionBase bindingExpressionBase = BindingOperations.GetBindingExpressionBase(this, ValueProperty);
            ValidationError validationError = new ValidationError(new ExceptionValidationRule(), bindingExpression);
            validationError.ErrorContent = errorText;
            Validation.MarkInvalid(bindingExpressionBase, validationError);
        }

        private void ResetError()
        {
            BindingExpressionBase bindingExpressionBase = BindingOperations.GetBindingExpressionBase(this, ValueProperty);
            Validation.ClearInvalid(bindingExpressionBase);
        }

        private static Regex fractionalBeginRegEx = new Regex(@"^-*\d+[.,]$");
        private static Regex uncompleteRegEx = new Regex(@"^-*\d+[.,]\d*[0]+$|^-*[.,]\d*$");
        // Незавершенный ввод:
        // ^-*\d+[.,]\d*[0]+$ - например "12,300", последний символ ноль, не парсим (иначе ноль исчезнет), даем возможность продолжить ввод после '0'
        // или
        // ^-*[.,]\d*$ - например ",1", не парсим (иначе получим значение 0,1), даем возможность ввести целую часть
    }
}
