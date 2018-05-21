using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//空白頁項目範本收錄在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;

        public MainPage()
        {
            this.InitializeComponent();
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _ellipse.Click += HandleEllipseButtonClick;
            _rectangle.Click += HandleRectangleButtonClick;
            _line.Click += HandleLineButtonClick;
            _arrow.Click += HandleArrowButtonClick;
            _delete.Click += HandleDeleteButtonClick;
            _clear.Click += HandleClearButtonClick;
            _undo.Click += HandleUndoButtonClick;
            _redo.Click += HandleRedoButtonClick;
            _model._modelChanged += HandleModelChanged;
            RefreshControl();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        // Refresh button control
        private void RefreshControl()
        {
            _ellipse.IsEnabled = _presentationModel.IsEllipseEnabled();
            _rectangle.IsEnabled = _presentationModel.IsRectangleEnabled();
            _line.IsEnabled = _presentationModel.IsLineEnabled();
            _arrow.IsEnabled = _presentationModel.IsArrowEnabled();
            _delete.IsEnabled = _presentationModel.IsDeleteEnabled();
            _redo.IsEnabled = _model.IsRedoEnabled;
            _undo.IsEnabled = _model.IsUndoEnabled;
        }

        // Click ellipse button
        private void HandleEllipseButtonClick(object sender, RoutedEventArgs e)
        {
            _model.GetEllipse();
            RefreshControl();
        }

        // Click rectangle button
        private void HandleRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            _model.GetRectangle();
            RefreshControl();
        }

        // Click line button
        private void HandleLineButtonClick(object sender, RoutedEventArgs e)
        {
            _model.GetLine();
            RefreshControl();
        }

        // Click arrow button
        private void HandleArrowButtonClick(object sender, RoutedEventArgs e)
        {
            _model.GetArrow();
            RefreshControl();
        }

        // Click delete botton
        private void HandleDeleteButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Delete();
            RefreshControl();
        }

        // Click clear botton
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
        }

        // Click undo botton
        private void HandleUndoButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Undo();
            RefreshControl();
        }

        // Click redo botton
        private void HandleRedoButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Redo();
            RefreshControl();
        }

        // Press the mouse on canvas
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.GetPointerPressed(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            RefreshControl();
        }

        // Release the mouse on canvas
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.GetPointerReleased(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            RefreshControl();
        }

        // Move the mouse on canvas
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.GetPointerMoved(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            RefreshControl();
        }

        // Draw the shape on canvas
        public void HandleModelChanged()
        {
            _presentationModel.Draw();
        }
    }
}
