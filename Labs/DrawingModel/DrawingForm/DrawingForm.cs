using DrawingModel;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class DrawingForm : Form
    {
        Model _model;
        DrawingFormHelper _formHelper;
        Panel _canvas = new DoubleBufferedPanel();

        public DrawingForm()
        {
            InitializeComponent();
            // Initialize canvas
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
            // Initialize clear button
            Button clear = new Button();
            clear.Text = "Clear";
            clear.Dock = DockStyle.Top;
            clear.AutoSize = true;
            clear.AutoSizeMode =
            System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clear.Click += HandleClearButtonClick;
            Controls.Add(clear);
            // Initialize model and form helper
            _model = new DrawingModel.Model();
            _formHelper = new DrawingFormHelper(_model);
            _model._modelChanged += HandleModelChanged;
        }

        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
        }

        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.HandlePointerPressed(e.X, e.Y);
        }
        public void HandleCanvasReleased(object sender,
        System.Windows.Forms.MouseEventArgs e)
        {
            _model.HandlePointerReleased(e.X, e.Y);
        }
        public void HandleCanvasMoved(object sender,
        System.Windows.Forms.MouseEventArgs e)
        {
            _model.HandlePointerMoved(e.X, e.Y);
        }
        public void HandleCanvasPaint(object sender,
        System.Windows.Forms.PaintEventArgs e)
        {
            _formHelper.Draw(e.Graphics);
        }
        public void HandleModelChanged()
        {
            Invalidate(true);
        }
    }
}
