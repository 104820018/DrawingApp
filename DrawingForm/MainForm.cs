using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class MainForm : Form
    {
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        ToolStripButton _undo;
        ToolStripButton _redo;

        public MainForm()
        {
            InitializeComponent();
            //
            // prepare canvas
            //
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
            //
            // ToolStrip for Redo and Undo buttons
            //
            ToolStrip toolStrip = new ToolStrip();
            //Controls.Add(ts);
            toolStrip.Parent = this;
            _undo = new ToolStripButton("Undo", null, UndoHandler);
            _undo.Enabled = false;
            toolStrip.Items.Add(_undo);
            _redo = new ToolStripButton("Redo", null, RedoHandler);
            _redo.Enabled = false;
            toolStrip.Items.Add(_redo);
            //
            // prepare presentation model and model
            //
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _model._modelChanged += HandleModelChanged;
            _presentationModel.DownloadFile();
            RefreshControl();
        }

        // Refresh enabled control
        private void RefreshControl()
        {
            _rectangle.Enabled = _presentationModel.IsRectangleEnabled();
            _ellipse.Enabled = _presentationModel.IsEllipseEnabled();
            _line.Enabled = _presentationModel.IsLineEnabled();
            _arrow.Enabled = _presentationModel.IsArrowEnabled();
            _delete.Enabled = _presentationModel.IsDeleteEnabled();
            _saveToGoogleDrive.Enabled = _presentationModel.IsSaveToGoogleDriveEnabled();
            _redo.Enabled = _model.IsRedoEnabled;
            _undo.Enabled = _model.IsUndoEnabled;
            Invalidate();
        }

        // Click rectangle button
        public void HandleRectangleButtonClick(object sender, System.EventArgs e)
        {
            _model.GetRectangle();
            RefreshControl();
        }

        // Click rectangle button
        public void HandleEllipseButtonClick(object sender, System.EventArgs e)
        {
            _model.GetEllipse();
            RefreshControl();
        }

        // Click line button
        public void HandleLineButtonClick(object sender, System.EventArgs e)
        {
            _model.GetLine();
            RefreshControl();
        }

        // Click arrow button
        private void HandleArrowButtonClick(object sender, EventArgs e)
        {
            _model.GetArrow();
            RefreshControl();
        }

        // Click delete button
        private void HandleDeleteButtonClick(object sender, EventArgs e)
        {
            _model.Delete();
            RefreshControl();
        }

        // Click clear botton
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
        }

        // Click save to google drive button
        private void HandleSaveToGoogleDriveButtonClick(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(_canvas.Width, _canvas.Height);
            _canvas.DrawToBitmap(bitmap, _canvas.ClientRectangle);
            bitmap.Save("My Drawing.jpg");
            _presentationModel.SaveFile();
            System.IO.File.Delete(@"My Drawing.jpg");
        }

        // Click undo
        void UndoHandler(object sender, EventArgs e)
        {
            _model.Undo();
            RefreshControl();
        }

        // Click redo
        void RedoHandler(object sender, EventArgs e)
        {
            _model.Redo();
            RefreshControl();
        }

        // Press the mouse on canvas
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.GetPointerPressed(e.X, e.Y);
            RefreshControl();
        }

        // Release the mouse on canvas
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.GetPointerReleased(e.X, e.Y);
            RefreshControl();
        }

        // Move the mouse on canvas
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.GetPointerMoved(e.X, e.Y);
            RefreshControl();
        }

        // Draw the shape on canvas
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
            RefreshControl();
        }

        // Check if the model has changed or not
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

    }
}
