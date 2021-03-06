using System.Windows.Input;
using Xamarin.Forms;

/// <summary>
/// This custom ViewCell is created in order to hide the highlight effect of ViewCells
/// </summary>
namespace MHR.Extensions
{
    public class CustomViewCell : ViewCell
    {
        public static readonly BindableProperty TappedCommandProperty =
               BindableProperty.Create("TappedCommandProperty", typeof(ICommand), typeof(CustomViewCell), null, propertyChanged: OnTappedCommandChanged);

        public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set { SetValue(TappedCommandProperty, value); }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            OnTappedCommandChanged(this, null, null);
        }

        static void OnTappedCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var viewCell = bindable as CustomViewCell;

            if (viewCell == null)
                return;

            viewCell.View.GestureRecognizers.Clear();
            viewCell.View.GestureRecognizers.Add(new TapGestureRecognizer() { Command = viewCell.TappedCommand });
        }
    }
}
