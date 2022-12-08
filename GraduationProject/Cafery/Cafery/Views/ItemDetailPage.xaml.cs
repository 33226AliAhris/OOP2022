using Cafery.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Cafery.Views {
    public partial class ItemDetailPage : ContentPage {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}