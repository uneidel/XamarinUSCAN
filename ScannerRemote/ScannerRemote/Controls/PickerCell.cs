using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScannerRemote.Controls
{
    internal class PickerCell : ViewCell
    {

        private Label _label { get; set; }
        private View _picker { get; set; }
        private StackLayout _layout { get; set; }

        internal string Label
        {
            get
            {
                return _label.Text;
            }
            set
            {
                _label.Text = value;
            }
        }

        internal View Picker
        {
            set
            {
                //Remove picker if it exists
                if (_picker != null)
                {
                    _layout.Children.Remove(_picker);
                }

                //Set its value
                _picker = value;
                //Add to layout
                _picker.HorizontalOptions = LayoutOptions.EndAndExpand;
                _layout.Children.Add(_picker);

            }
        }

        internal PickerCell()
        {

            _label = new Label()
            {
                VerticalOptions = LayoutOptions.Center
            };
            _layout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(20, 0),
                Children =
            {
                _label
            }
            };

            this.View = _layout;

        }

    }
}
