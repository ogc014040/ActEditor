using System.Windows;
using System.Windows.Controls;
using ActEditor.ApplicationConfiguration;

namespace ActEditor.Core.WPF.EditorControls {
	/// <summary>
	/// Interaction logic for SubFrameControl.xaml
	/// </summary>
	public partial class LayerControlHeader : UserControl {
		public LayerControlHeader() {
			InitializeComponent();
			ApplyLocalization();

			SizeChanged += delegate {
				for (int i = 0; i < _grid.ColumnDefinitions.Count; i++) {
					double width = _grid.ColumnDefinitions[i].ActualWidth;
					_grid.ColumnDefinitions[i].MaxWidth = width;
					_grid.ColumnDefinitions[i].MinWidth = width;
				}
			};
		}

		public Grid Grid {
			get { return _grid; }
		}

		/// <summary>
		/// Hides the ID and Sprite fields.
		/// </summary>
		public void HideIdAndSprite() {
			_grid.ColumnDefinitions[0].MinWidth = 0;
			_grid.ColumnDefinitions[0].Width = new GridLength(0);

			_grid.ColumnDefinitions[1].MinWidth = 0;
			_grid.ColumnDefinitions[1].Width = new GridLength(0);

			_lab0.Visibility = Visibility.Hidden;
			_lab1.Visibility = Visibility.Hidden;
		}

		private void ApplyLocalization() {
			_lab0.Content = LocalizationManager.S("Layer_Id");
			_lab1.Content = LocalizationManager.S("Layer_Sprite");
			_lab2.Content = LocalizationManager.S("Layer_X");
			_lab3.Content = LocalizationManager.S("Layer_Y");
			_lab4.Content = LocalizationManager.S("Layer_Mirror");
			_lab5.Content = LocalizationManager.S("Layer_Color");
			_lab6.Content = LocalizationManager.S("Layer_ScaleX");
			_lab7.Content = LocalizationManager.S("Layer_ScaleY");
			_lab8.Content = LocalizationManager.S("Layer_Angle");
		}
	}
}