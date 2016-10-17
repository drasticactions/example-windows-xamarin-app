using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;
using Foundation;
using CoreGraphics;
using windows_central_client.Managers;
using windows_central_client.Models.News;

namespace example_xamarin_ios_app
{
    public partial class MasterViewController : UITableViewController
    {
        public DetailViewController DetailViewController { get; set; }

        DataSource dataSource;

        public MasterViewController(IntPtr handle) : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Master", "Articles");

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                PreferredContentSize = new CGSize(320f, 600f);
                ClearsSelectionOnViewWillAppear = false;
            }
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            //NavigationItem.LeftBarButtonItem = EditButtonItem;

            //var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddNewItem);
            //addButton.AccessibilityLabel = "addButton";
            //NavigationItem.RightBarButtonItem = addButton;

            DetailViewController = (DetailViewController)((UINavigationController)SplitViewController.ViewControllers[1]).TopViewController;
            TableView.Source = dataSource = new DataSource(this);
            TableView.RowHeight = 300;
            await dataSource.LoadMore();
            TableView.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "showDetail")
            {
                //var indexPath = TableView.IndexPathForSelectedRow;
                //var item = dataSource.Objects[indexPath.Row];
                //var controller = (DetailViewController)((UINavigationController)segue.DestinationViewController).TopViewController;
                //controller.SetDetailItem(item);
                //controller.NavigationItem.LeftBarButtonItem = SplitViewController.DisplayModeButtonItem;
                //controller.NavigationItem.LeftItemsSupplementBackButton = true;
            }
        }

        class DataSource : UITableViewSource
        {
            static readonly NSString CellIdentifier = new NSString("Cell");
            bool _isFetching;
            readonly MasterViewController _controller;

            public DataSource(MasterViewController controller)
            {
                this._controller = controller;
            }

            private int _pageIndex { get; set; } = 0;

            public IList<Article> Objects { get; set; } = new List<Article>();

            // Customize the number of sections in the table view.
            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return Objects.Count;
            }

            // Customize the appearance of table view cells.
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath) as ArticleViewCell;

                var article = Objects[indexPath.Row];

                cell.Update(article);

                if (!_isFetching && indexPath.Row > Objects.Count * 0.8)
                {
                    _isFetching = true;
                    Task.Factory.StartNew(LoadMore);
                }

                return cell;
            }

            public async Task LoadMore()
            {
                var result = await NewsManager.GetNewsResult(_pageIndex);
                foreach (var item in result.Articles)
                {
                    Objects.Add(item);
                }
                _pageIndex++;
            }

            public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
            {
                // Return false if you do not want the specified item to be editable.
                return false;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    _controller.DetailViewController.SetDetailItem(Objects[indexPath.Row]);
            }
        }
    }
}


