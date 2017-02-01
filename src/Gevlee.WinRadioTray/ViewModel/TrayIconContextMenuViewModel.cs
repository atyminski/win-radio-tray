using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using Gevlee.WinRadioTray.Core;
using Gevlee.WinRadioTray.Core.ViewModel;
using Gevlee.WinRadioTray.LocalStorage.Contract;
using Gevlee.WinRadioTray.LocalStorage.Contract.Services;

namespace Gevlee.WinRadioTray.ViewModel
{
	public class TrayIconContextMenuViewModel : ViewModelBase, ITrayIconContextMenuViewModel
	{
		private readonly ISavedRadiostationsService savedRadiostationsService;
		private readonly ITrayContextMenuItemFactory<Radiostation> radiostarionTrayContextMenuItemFactory;
		private readonly ITrayContextMenuItemFactory<RadiostationsGroup> radiostationsGroupTrayContextMenuItemFactory;
		private IEnumerable<ITrayContextMenuItem> bottomItems;
		private ObservableCollection<ITrayContextMenuItem> middleItems;
		private IEnumerable<ITrayContextMenuItem> topItems;

		public TrayIconContextMenuViewModel(IEnumerable<ITrayContextMenuItem> bottomMenuItems,
			ISavedRadiostationsService savedRadiostationsService,
			ITrayContextMenuItemFactory<Radiostation> radiostarionTrayContextMenuItemFactory,
			ITrayContextMenuItemFactory<RadiostationsGroup> radiostationsGroupTrayContextMenuItemFactory)
		{
			this.savedRadiostationsService = savedRadiostationsService;
			this.radiostarionTrayContextMenuItemFactory = radiostarionTrayContextMenuItemFactory;
			this.radiostationsGroupTrayContextMenuItemFactory = radiostationsGroupTrayContextMenuItemFactory;
			BottomItems = bottomMenuItems;
			ReloadRadiostationsItems();
		}

		private void ReloadRadiostationsItems()
		{
			var savedRadiostations = savedRadiostationsService.Get();

			middleItems =
				new ObservableCollection<ITrayContextMenuItem>(
					savedRadiostations.RadiostationsGroups.Select(r => radiostationsGroupTrayContextMenuItemFactory.GetMenuItem(r))
						.Union(
							savedRadiostations.StandaloneRadiostations.Select(r => radiostarionTrayContextMenuItemFactory.GetMenuItem(r))));
			RaisePropertyChanged(nameof(MiddleItems));
		}

		public IEnumerable<ITrayContextMenuItem> BottomItems
		{
			get { return bottomItems; }
			set
			{
				bottomItems = value; 
				RaisePropertyChanged();
			}
		}

		public IEnumerable<ITrayContextMenuItem> MiddleItems => middleItems;

		public IEnumerable<ITrayContextMenuItem> TopItems
		{
			get { return topItems; }
			set
			{
				topItems = value;
				RaisePropertyChanged();
			}
		}
	}
}