namespace OrderAndStorageManagementSystem.Views
{
    partial class ProductManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._productManagementFormLayout = new System.Windows.Forms.TableLayoutPanel();
            this._windowTitle = new System.Windows.Forms.Label();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._productsManagementTabPage = new System.Windows.Forms.TabPage();
            this._productsManagementTabPageLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productInfoGroupBox = new System.Windows.Forms.GroupBox();
            this._productInfoGroupBoxLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productNameLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productNameLabel = new System.Windows.Forms.Label();
            this._productNameField = new InputInspectingElements.InputInspectingControls.InputInspectingTextBox();
            this._productPriceAndTypeLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productTypeLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productTypeLabel = new System.Windows.Forms.Label();
            this._productTypeField = new System.Windows.Forms.ComboBox();
            this._productPriceLayout = new System.Windows.Forms.TableLayoutPanel();
            this._unitLabel = new System.Windows.Forms.Label();
            this._productPriceLabel = new System.Windows.Forms.Label();
            this._productPriceField = new System.Windows.Forms.TextBox();
            this._productDescriptionLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productDescriptionLabel = new System.Windows.Forms.Label();
            this._productDescriptionField = new System.Windows.Forms.RichTextBox();
            this._productInfoGroupBoxLastRowLayout = new System.Windows.Forms.TableLayoutPanel();
            this._saveButton = new System.Windows.Forms.Button();
            this._productImagePathLayout = new System.Windows.Forms.TableLayoutPanel();
            this._productImagePathLabel = new System.Windows.Forms.Label();
            this._productImagePathField = new System.Windows.Forms.TextBox();
            this._productImageBrowseButton = new System.Windows.Forms.Button();
            this._productsManagementTabPageLeftSectionLayout = new System.Windows.Forms.TableLayoutPanel();
            this._addProductButton = new System.Windows.Forms.Button();
            this._productsListBox = new System.Windows.Forms.ListBox();
            this._productTypesManagementTabPage = new System.Windows.Forms.TabPage();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._productManagementFormLayout.SuspendLayout();
            this._tabControl.SuspendLayout();
            this._productsManagementTabPage.SuspendLayout();
            this._productsManagementTabPageLayout.SuspendLayout();
            this._productInfoGroupBox.SuspendLayout();
            this._productInfoGroupBoxLayout.SuspendLayout();
            this._productNameLayout.SuspendLayout();
            this._productPriceAndTypeLayout.SuspendLayout();
            this._productTypeLayout.SuspendLayout();
            this._productPriceLayout.SuspendLayout();
            this._productDescriptionLayout.SuspendLayout();
            this._productInfoGroupBoxLastRowLayout.SuspendLayout();
            this._productImagePathLayout.SuspendLayout();
            this._productsManagementTabPageLeftSectionLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _productManagementFormLayout
            // 
            this._productManagementFormLayout.ColumnCount = 1;
            this._productManagementFormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productManagementFormLayout.Controls.Add(this._windowTitle, 0, 0);
            this._productManagementFormLayout.Controls.Add(this._tabControl, 0, 1);
            this._productManagementFormLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productManagementFormLayout.Location = new System.Drawing.Point(0, 0);
            this._productManagementFormLayout.Name = "_productManagementFormLayout";
            this._productManagementFormLayout.RowCount = 2;
            this._productManagementFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.77041F));
            this._productManagementFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.22959F));
            this._productManagementFormLayout.Size = new System.Drawing.Size(837, 570);
            this._productManagementFormLayout.TabIndex = 0;
            // 
            // _windowTitle
            // 
            this._windowTitle.AutoSize = true;
            this._windowTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._windowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this._windowTitle.Location = new System.Drawing.Point(3, 0);
            this._windowTitle.Name = "_windowTitle";
            this._windowTitle.Size = new System.Drawing.Size(831, 72);
            this._windowTitle.TabIndex = 0;
            this._windowTitle.Text = "商品管理系統";
            this._windowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._productsManagementTabPage);
            this._tabControl.Controls.Add(this._productTypesManagementTabPage);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(3, 75);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(831, 492);
            this._tabControl.TabIndex = 1;
            // 
            // _productsManagementTabPage
            // 
            this._productsManagementTabPage.Controls.Add(this._productsManagementTabPageLayout);
            this._productsManagementTabPage.Location = new System.Drawing.Point(4, 22);
            this._productsManagementTabPage.Name = "_productsManagementTabPage";
            this._productsManagementTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._productsManagementTabPage.Size = new System.Drawing.Size(823, 466);
            this._productsManagementTabPage.TabIndex = 0;
            this._productsManagementTabPage.Text = "商品管理";
            this._productsManagementTabPage.UseVisualStyleBackColor = true;
            // 
            // _productsManagementTabPageLayout
            // 
            this._productsManagementTabPageLayout.ColumnCount = 2;
            this._productsManagementTabPageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this._productsManagementTabPageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this._productsManagementTabPageLayout.Controls.Add(this._productInfoGroupBox, 1, 0);
            this._productsManagementTabPageLayout.Controls.Add(this._productsManagementTabPageLeftSectionLayout, 0, 0);
            this._productsManagementTabPageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productsManagementTabPageLayout.Location = new System.Drawing.Point(3, 3);
            this._productsManagementTabPageLayout.Name = "_productsManagementTabPageLayout";
            this._productsManagementTabPageLayout.RowCount = 1;
            this._productsManagementTabPageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productsManagementTabPageLayout.Size = new System.Drawing.Size(817, 460);
            this._productsManagementTabPageLayout.TabIndex = 0;
            // 
            // _productInfoGroupBox
            // 
            this._productInfoGroupBox.Controls.Add(this._productInfoGroupBoxLayout);
            this._productInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productInfoGroupBox.Location = new System.Drawing.Point(288, 3);
            this._productInfoGroupBox.Name = "_productInfoGroupBox";
            this._productInfoGroupBox.Size = new System.Drawing.Size(526, 454);
            this._productInfoGroupBox.TabIndex = 1;
            this._productInfoGroupBox.TabStop = false;
            this._productInfoGroupBox.Text = "編輯商品";
            // 
            // _productInfoGroupBoxLayout
            // 
            this._productInfoGroupBoxLayout.ColumnCount = 1;
            this._productInfoGroupBoxLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productInfoGroupBoxLayout.Controls.Add(this._productNameLayout, 0, 0);
            this._productInfoGroupBoxLayout.Controls.Add(this._productPriceAndTypeLayout, 0, 1);
            this._productInfoGroupBoxLayout.Controls.Add(this._productDescriptionLayout, 0, 3);
            this._productInfoGroupBoxLayout.Controls.Add(this._productInfoGroupBoxLastRowLayout, 0, 4);
            this._productInfoGroupBoxLayout.Controls.Add(this._productImagePathLayout, 0, 2);
            this._productInfoGroupBoxLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productInfoGroupBoxLayout.Location = new System.Drawing.Point(3, 16);
            this._productInfoGroupBoxLayout.Name = "_productInfoGroupBoxLayout";
            this._productInfoGroupBoxLayout.RowCount = 5;
            this._productInfoGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this._productInfoGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this._productInfoGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this._productInfoGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this._productInfoGroupBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this._productInfoGroupBoxLayout.Size = new System.Drawing.Size(520, 435);
            this._productInfoGroupBoxLayout.TabIndex = 2;
            // 
            // _productNameLayout
            // 
            this._productNameLayout.ColumnCount = 2;
            this._productNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.25424F));
            this._productNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.74577F));
            this._productNameLayout.Controls.Add(this._productNameLabel, 0, 0);
            this._productNameLayout.Controls.Add(this._productNameField, 1, 0);
            this._productNameLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productNameLayout.Location = new System.Drawing.Point(3, 3);
            this._productNameLayout.Name = "_productNameLayout";
            this._productNameLayout.RowCount = 1;
            this._productNameLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productNameLayout.Size = new System.Drawing.Size(514, 46);
            this._productNameLayout.TabIndex = 0;
            // 
            // _productNameLabel
            // 
            this._productNameLabel.AutoSize = true;
            this._productNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productNameLabel.Location = new System.Drawing.Point(3, 0);
            this._productNameLabel.Name = "_productNameLabel";
            this._productNameLabel.Size = new System.Drawing.Size(72, 46);
            this._productNameLabel.TabIndex = 0;
            this._productNameLabel.Text = "商品名稱(*)";
            // 
            // _productNameField
            // 
            this._productNameField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productNameField.Location = new System.Drawing.Point(81, 3);
            this._productNameField.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this._productNameField.Name = "_productNameField";
            this._productNameField.Size = new System.Drawing.Size(413, 20);
            this._productNameField.TabIndex = 1;
            this._productNameField.TextBoxInspectorsCollectionChanged = null;
            // 
            // _productPriceAndTypeLayout
            // 
            this._productPriceAndTypeLayout.ColumnCount = 2;
            this._productPriceAndTypeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._productPriceAndTypeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._productPriceAndTypeLayout.Controls.Add(this._productTypeLayout, 1, 0);
            this._productPriceAndTypeLayout.Controls.Add(this._productPriceLayout, 0, 0);
            this._productPriceAndTypeLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productPriceAndTypeLayout.Location = new System.Drawing.Point(3, 55);
            this._productPriceAndTypeLayout.Name = "_productPriceAndTypeLayout";
            this._productPriceAndTypeLayout.RowCount = 1;
            this._productPriceAndTypeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productPriceAndTypeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this._productPriceAndTypeLayout.Size = new System.Drawing.Size(514, 46);
            this._productPriceAndTypeLayout.TabIndex = 1;
            // 
            // _productTypeLayout
            // 
            this._productTypeLayout.ColumnCount = 2;
            this._productTypeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._productTypeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._productTypeLayout.Controls.Add(this._productTypeLabel, 0, 0);
            this._productTypeLayout.Controls.Add(this._productTypeField, 1, 0);
            this._productTypeLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productTypeLayout.Location = new System.Drawing.Point(260, 3);
            this._productTypeLayout.Name = "_productTypeLayout";
            this._productTypeLayout.RowCount = 1;
            this._productTypeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productTypeLayout.Size = new System.Drawing.Size(251, 40);
            this._productTypeLayout.TabIndex = 1;
            // 
            // _productTypeLabel
            // 
            this._productTypeLabel.AutoSize = true;
            this._productTypeLabel.Location = new System.Drawing.Point(3, 0);
            this._productTypeLabel.Name = "_productTypeLabel";
            this._productTypeLabel.Size = new System.Drawing.Size(68, 13);
            this._productTypeLabel.TabIndex = 0;
            this._productTypeLabel.Text = "商品類別 (*)";
            // 
            // _productTypeField
            // 
            this._productTypeField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productTypeField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._productTypeField.FormattingEnabled = true;
            this._productTypeField.Location = new System.Drawing.Point(78, 3);
            this._productTypeField.Name = "_productTypeField";
            this._productTypeField.Size = new System.Drawing.Size(170, 21);
            this._productTypeField.TabIndex = 1;
            // 
            // _productPriceLayout
            // 
            this._productPriceLayout.ColumnCount = 3;
            this._productPriceLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._productPriceLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._productPriceLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._productPriceLayout.Controls.Add(this._unitLabel, 2, 0);
            this._productPriceLayout.Controls.Add(this._productPriceLabel, 0, 0);
            this._productPriceLayout.Controls.Add(this._productPriceField, 1, 0);
            this._productPriceLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productPriceLayout.Location = new System.Drawing.Point(3, 3);
            this._productPriceLayout.Name = "_productPriceLayout";
            this._productPriceLayout.RowCount = 1;
            this._productPriceLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productPriceLayout.Size = new System.Drawing.Size(251, 40);
            this._productPriceLayout.TabIndex = 2;
            // 
            // _unitLabel
            // 
            this._unitLabel.AutoSize = true;
            this._unitLabel.Location = new System.Drawing.Point(203, 0);
            this._unitLabel.Name = "_unitLabel";
            this._unitLabel.Size = new System.Drawing.Size(30, 13);
            this._unitLabel.TabIndex = 0;
            this._unitLabel.Text = "NTD";
            // 
            // _productPriceLabel
            // 
            this._productPriceLabel.AutoSize = true;
            this._productPriceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productPriceLabel.Location = new System.Drawing.Point(3, 0);
            this._productPriceLabel.Name = "_productPriceLabel";
            this._productPriceLabel.Size = new System.Drawing.Size(69, 40);
            this._productPriceLabel.TabIndex = 1;
            this._productPriceLabel.Text = "商品價格 (*)";
            // 
            // _productPriceField
            // 
            this._productPriceField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productPriceField.Location = new System.Drawing.Point(78, 3);
            this._productPriceField.Name = "_productPriceField";
            this._productPriceField.Size = new System.Drawing.Size(119, 20);
            this._productPriceField.TabIndex = 2;
            // 
            // _productDescriptionLayout
            // 
            this._productDescriptionLayout.ColumnCount = 1;
            this._productDescriptionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productDescriptionLayout.Controls.Add(this._productDescriptionLabel, 0, 0);
            this._productDescriptionLayout.Controls.Add(this._productDescriptionField, 0, 1);
            this._productDescriptionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productDescriptionLayout.Location = new System.Drawing.Point(3, 159);
            this._productDescriptionLayout.Name = "_productDescriptionLayout";
            this._productDescriptionLayout.RowCount = 2;
            this._productDescriptionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._productDescriptionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this._productDescriptionLayout.Size = new System.Drawing.Size(514, 220);
            this._productDescriptionLayout.TabIndex = 3;
            // 
            // _productDescriptionLabel
            // 
            this._productDescriptionLabel.AutoSize = true;
            this._productDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productDescriptionLabel.Location = new System.Drawing.Point(3, 0);
            this._productDescriptionLabel.Name = "_productDescriptionLabel";
            this._productDescriptionLabel.Size = new System.Drawing.Size(508, 33);
            this._productDescriptionLabel.TabIndex = 0;
            this._productDescriptionLabel.Text = "商品介紹";
            // 
            // _productDescriptionField
            // 
            this._productDescriptionField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productDescriptionField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._productDescriptionField.Location = new System.Drawing.Point(3, 36);
            this._productDescriptionField.Name = "_productDescriptionField";
            this._productDescriptionField.Size = new System.Drawing.Size(508, 181);
            this._productDescriptionField.TabIndex = 1;
            this._productDescriptionField.Text = "";
            // 
            // _productInfoGroupBoxLastRowLayout
            // 
            this._productInfoGroupBoxLastRowLayout.ColumnCount = 2;
            this._productInfoGroupBoxLastRowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this._productInfoGroupBoxLastRowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._productInfoGroupBoxLastRowLayout.Controls.Add(this._saveButton, 1, 0);
            this._productInfoGroupBoxLastRowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productInfoGroupBoxLastRowLayout.Location = new System.Drawing.Point(3, 385);
            this._productInfoGroupBoxLastRowLayout.Name = "_productInfoGroupBoxLastRowLayout";
            this._productInfoGroupBoxLastRowLayout.RowCount = 1;
            this._productInfoGroupBoxLastRowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productInfoGroupBoxLastRowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this._productInfoGroupBoxLastRowLayout.Size = new System.Drawing.Size(514, 47);
            this._productInfoGroupBoxLastRowLayout.TabIndex = 4;
            // 
            // _saveButton
            // 
            this._saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._saveButton.Location = new System.Drawing.Point(414, 3);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(97, 41);
            this._saveButton.TabIndex = 0;
            this._saveButton.Text = "儲存";
            this._saveButton.UseVisualStyleBackColor = true;
            // 
            // _productImagePathLayout
            // 
            this._productImagePathLayout.ColumnCount = 3;
            this._productImagePathLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._productImagePathLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._productImagePathLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._productImagePathLayout.Controls.Add(this._productImagePathLabel, 0, 0);
            this._productImagePathLayout.Controls.Add(this._productImagePathField, 1, 0);
            this._productImagePathLayout.Controls.Add(this._productImageBrowseButton, 2, 0);
            this._productImagePathLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productImagePathLayout.Location = new System.Drawing.Point(3, 107);
            this._productImagePathLayout.Name = "_productImagePathLayout";
            this._productImagePathLayout.RowCount = 1;
            this._productImagePathLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productImagePathLayout.Size = new System.Drawing.Size(514, 46);
            this._productImagePathLayout.TabIndex = 5;
            // 
            // _productImagePathLabel
            // 
            this._productImagePathLabel.AutoSize = true;
            this._productImagePathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productImagePathLabel.Location = new System.Drawing.Point(3, 0);
            this._productImagePathLabel.Name = "_productImagePathLabel";
            this._productImagePathLabel.Size = new System.Drawing.Size(96, 46);
            this._productImagePathLabel.TabIndex = 0;
            this._productImagePathLabel.Text = "商品圖片路徑(*)";
            // 
            // _productImagePathField
            // 
            this._productImagePathField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productImagePathField.Location = new System.Drawing.Point(105, 3);
            this._productImagePathField.Name = "_productImagePathField";
            this._productImagePathField.Size = new System.Drawing.Size(302, 20);
            this._productImagePathField.TabIndex = 1;
            // 
            // _productImageBrowseButton
            // 
            this._productImageBrowseButton.Dock = System.Windows.Forms.DockStyle.Top;
            this._productImageBrowseButton.Location = new System.Drawing.Point(413, 3);
            this._productImageBrowseButton.Name = "_productImageBrowseButton";
            this._productImageBrowseButton.Size = new System.Drawing.Size(98, 23);
            this._productImageBrowseButton.TabIndex = 2;
            this._productImageBrowseButton.Text = "瀏覽...";
            this._productImageBrowseButton.UseVisualStyleBackColor = true;
            // 
            // _productsManagementTabPageLeftSectionLayout
            // 
            this._productsManagementTabPageLeftSectionLayout.ColumnCount = 1;
            this._productsManagementTabPageLeftSectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._productsManagementTabPageLeftSectionLayout.Controls.Add(this._addProductButton, 0, 1);
            this._productsManagementTabPageLeftSectionLayout.Controls.Add(this._productsListBox, 0, 0);
            this._productsManagementTabPageLeftSectionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productsManagementTabPageLeftSectionLayout.Location = new System.Drawing.Point(3, 3);
            this._productsManagementTabPageLeftSectionLayout.Name = "_productsManagementTabPageLeftSectionLayout";
            this._productsManagementTabPageLeftSectionLayout.RowCount = 2;
            this._productsManagementTabPageLeftSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this._productsManagementTabPageLeftSectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._productsManagementTabPageLeftSectionLayout.Size = new System.Drawing.Size(279, 454);
            this._productsManagementTabPageLeftSectionLayout.TabIndex = 2;
            // 
            // _addProductButton
            // 
            this._addProductButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addProductButton.Location = new System.Drawing.Point(3, 388);
            this._addProductButton.Name = "_addProductButton";
            this._addProductButton.Size = new System.Drawing.Size(273, 63);
            this._addProductButton.TabIndex = 0;
            this._addProductButton.Text = "新增商品";
            this._addProductButton.UseVisualStyleBackColor = true;
            // 
            // _productsListBox
            // 
            this._productsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productsListBox.FormattingEnabled = true;
            this._productsListBox.Location = new System.Drawing.Point(3, 3);
            this._productsListBox.Name = "_productsListBox";
            this._productsListBox.Size = new System.Drawing.Size(273, 379);
            this._productsListBox.TabIndex = 1;
            // 
            // _productTypesManagementTabPage
            // 
            this._productTypesManagementTabPage.Location = new System.Drawing.Point(4, 22);
            this._productTypesManagementTabPage.Name = "_productTypesManagementTabPage";
            this._productTypesManagementTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._productTypesManagementTabPage.Size = new System.Drawing.Size(823, 466);
            this._productTypesManagementTabPage.TabIndex = 1;
            this._productTypesManagementTabPage.Text = "類別管理";
            this._productTypesManagementTabPage.UseVisualStyleBackColor = true;
            // 
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // ProductManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 570);
            this.Controls.Add(this._productManagementFormLayout);
            this.Name = "ProductManagementForm";
            this.Text = "ProductManagement";
            this._productManagementFormLayout.ResumeLayout(false);
            this._productManagementFormLayout.PerformLayout();
            this._tabControl.ResumeLayout(false);
            this._productsManagementTabPage.ResumeLayout(false);
            this._productsManagementTabPageLayout.ResumeLayout(false);
            this._productInfoGroupBox.ResumeLayout(false);
            this._productInfoGroupBoxLayout.ResumeLayout(false);
            this._productNameLayout.ResumeLayout(false);
            this._productNameLayout.PerformLayout();
            this._productPriceAndTypeLayout.ResumeLayout(false);
            this._productTypeLayout.ResumeLayout(false);
            this._productTypeLayout.PerformLayout();
            this._productPriceLayout.ResumeLayout(false);
            this._productPriceLayout.PerformLayout();
            this._productDescriptionLayout.ResumeLayout(false);
            this._productDescriptionLayout.PerformLayout();
            this._productInfoGroupBoxLastRowLayout.ResumeLayout(false);
            this._productImagePathLayout.ResumeLayout(false);
            this._productImagePathLayout.PerformLayout();
            this._productsManagementTabPageLeftSectionLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _productManagementFormLayout;
        private System.Windows.Forms.Label _windowTitle;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _productsManagementTabPage;
        private System.Windows.Forms.TableLayoutPanel _productsManagementTabPageLayout;
        private System.Windows.Forms.TabPage _productTypesManagementTabPage;
        private System.Windows.Forms.GroupBox _productInfoGroupBox;
        private System.Windows.Forms.TableLayoutPanel _productsManagementTabPageLeftSectionLayout;
        private System.Windows.Forms.Button _addProductButton;
        private System.Windows.Forms.ListBox _productsListBox;
        private System.Windows.Forms.TableLayoutPanel _productInfoGroupBoxLayout;
        private System.Windows.Forms.TableLayoutPanel _productNameLayout;
        private System.Windows.Forms.Label _productNameLabel;
        private InputInspectingElements.InputInspectingControls.InputInspectingTextBox _productNameField;
        private System.Windows.Forms.TableLayoutPanel _productPriceAndTypeLayout;
        private System.Windows.Forms.TableLayoutPanel _productTypeLayout;
        private System.Windows.Forms.Label _productTypeLabel;
        private System.Windows.Forms.ComboBox _productTypeField;
        private System.Windows.Forms.TableLayoutPanel _productPriceLayout;
        private System.Windows.Forms.Label _unitLabel;
        private System.Windows.Forms.Label _productPriceLabel;
        private System.Windows.Forms.TextBox _productPriceField;
        private System.Windows.Forms.TableLayoutPanel _productDescriptionLayout;
        private System.Windows.Forms.Label _productDescriptionLabel;
        private System.Windows.Forms.RichTextBox _productDescriptionField;
        private System.Windows.Forms.TableLayoutPanel _productInfoGroupBoxLastRowLayout;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.TableLayoutPanel _productImagePathLayout;
        private System.Windows.Forms.Label _productImagePathLabel;
        private System.Windows.Forms.TextBox _productImagePathField;
        private System.Windows.Forms.Button _productImageBrowseButton;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}