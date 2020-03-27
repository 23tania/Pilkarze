using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dodawanieDanych
{
    /// <summary>
    /// Logika interakcji dla klasy TextBoxWithErrorProvider.xaml
    /// </summary>
    public partial class TextBoxWithErrorProvider : UserControl
    {

        #region Właściwości
        public static Brush BrushForAll { get; set; } = Brushes.Red;

        public Brush TextBoxBorderBrush
        {
            get
            {
                return border.BorderBrush;
            }
            set
            {

                border.BorderBrush = value;
            }
        }

        //ponieważ obiekty składowe (textBox, border, toolTip) zostały ograniczone do ciała
        //tworzonej klasy po stronie kodu dbamy o interfejs publiczny tworzonej klasy

        //pierwszą podstawową sprawą jest brak dostępu z zewnątrz do tekstu zawartego w 
        //textBox. dlatego tworzymy publiczną właściwość o nazwie Text

        public string Text
        {
            get
            {
                return textBox.Text;
            }
            set
            {
                textBox.Text = value;
            }
        }
        #endregion

        public TextBoxWithErrorProvider()
        {
            InitializeComponent();
            border.BorderBrush = BrushForAll;
        }

        public void SetError(string errorText)
        {
            textBlockToolTip.Text = errorText;
            if (errorText != "")
            {
                //nie ma błędu
                border.BorderThickness = new Thickness(1);
                toolTip.Visibility = Visibility.Visible;
            }
            else
            {
                //zgłaszam błąd
                border.BorderThickness = new Thickness(0);
                toolTip.Visibility = Visibility.Hidden;
            }
        }

        public void SetFocus()
        {
            textBox.Focus();
        }
    }
}
