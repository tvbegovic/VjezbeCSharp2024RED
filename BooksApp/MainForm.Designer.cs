namespace BooksApp
{
  partial class MainForm
  {
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage booksTab;
    private System.Windows.Forms.TabPage genresTab;
    private System.Windows.Forms.TabPage usersTab;
    private System.Windows.Forms.DataGridView booksGridView;
    private System.Windows.Forms.DataGridView genresGridView;
    private System.Windows.Forms.DataGridView usersGridView;
    private System.Windows.Forms.DataGridView ordersGridView;
    private System.Windows.Forms.GroupBox searchPanel;
    private System.Windows.Forms.Label lblSearchTitle;
    private System.Windows.Forms.Label lblSearchAuthor;
    private System.Windows.Forms.TextBox txtSearchTitle;
    private System.Windows.Forms.TextBox txtSearchAuthor;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.Button btnAddBook;
    private System.Windows.Forms.Button btnEditBook;
    private System.Windows.Forms.Button btnDeleteBook;
    private System.Windows.Forms.Button btnAddOrder;
    private System.Windows.Forms.Button btnEditOrder;
    private System.Windows.Forms.Button btnDeleteOrder;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tabControl = new System.Windows.Forms.TabControl();
      this.booksTab = new System.Windows.Forms.TabPage();
      this.searchPanel = new System.Windows.Forms.GroupBox();
      this.lblSearchTitle = new System.Windows.Forms.Label();
      this.lblSearchAuthor = new System.Windows.Forms.Label();
      this.txtSearchTitle = new System.Windows.Forms.TextBox();
      this.txtSearchAuthor = new System.Windows.Forms.TextBox();
      this.btnSearch = new System.Windows.Forms.Button();
      this.booksGridView = new System.Windows.Forms.DataGridView();
      this.btnAddBook = new System.Windows.Forms.Button();
      this.btnEditBook = new System.Windows.Forms.Button();
      this.btnDeleteBook = new System.Windows.Forms.Button();
      this.genresTab = new System.Windows.Forms.TabPage();
      this.genresGridView = new System.Windows.Forms.DataGridView();
      this.usersTab = new System.Windows.Forms.TabPage();
      this.usersGridView = new System.Windows.Forms.DataGridView();
      this.ordersGridView = new System.Windows.Forms.DataGridView();
      this.btnAddOrder = new System.Windows.Forms.Button();
      this.btnEditOrder = new System.Windows.Forms.Button();
      this.btnDeleteOrder = new System.Windows.Forms.Button();
      this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colPublishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnReset = new System.Windows.Forms.Button();
      this.tabControl.SuspendLayout();
      this.booksTab.SuspendLayout();
      this.searchPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.booksGridView)).BeginInit();
      this.genresTab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.genresGridView)).BeginInit();
      this.usersTab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.booksTab);
      this.tabControl.Controls.Add(this.genresTab);
      this.tabControl.Controls.Add(this.usersTab);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.Location = new System.Drawing.Point(0, 0);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(867, 512);
      this.tabControl.TabIndex = 0;
      // 
      // booksTab
      // 
      this.booksTab.Controls.Add(this.panel1);
      this.booksTab.Controls.Add(this.searchPanel);
      this.booksTab.Controls.Add(this.booksGridView);
      this.booksTab.Location = new System.Drawing.Point(4, 22);
      this.booksTab.Name = "booksTab";
      this.booksTab.Padding = new System.Windows.Forms.Padding(3);
      this.booksTab.Size = new System.Drawing.Size(859, 486);
      this.booksTab.TabIndex = 0;
      this.booksTab.Text = "Books";
      // 
      // searchPanel
      // 
      this.searchPanel.Controls.Add(this.lblSearchTitle);
      this.searchPanel.Controls.Add(this.lblSearchAuthor);
      this.searchPanel.Controls.Add(this.txtSearchTitle);
      this.searchPanel.Controls.Add(this.txtSearchAuthor);
      this.searchPanel.Controls.Add(this.btnReset);
      this.searchPanel.Controls.Add(this.btnSearch);
      this.searchPanel.Location = new System.Drawing.Point(10, 10);
      this.searchPanel.Name = "searchPanel";
      this.searchPanel.Size = new System.Drawing.Size(770, 62);
      this.searchPanel.TabIndex = 0;
      this.searchPanel.TabStop = false;
      this.searchPanel.Text = "Search Books";
      // 
      // lblSearchTitle
      // 
      this.lblSearchTitle.Location = new System.Drawing.Point(10, 25);
      this.lblSearchTitle.Name = "lblSearchTitle";
      this.lblSearchTitle.Size = new System.Drawing.Size(47, 23);
      this.lblSearchTitle.TabIndex = 0;
      this.lblSearchTitle.Text = "Title:";
      // 
      // lblSearchAuthor
      // 
      this.lblSearchAuthor.Location = new System.Drawing.Point(205, 25);
      this.lblSearchAuthor.Name = "lblSearchAuthor";
      this.lblSearchAuthor.Size = new System.Drawing.Size(52, 23);
      this.lblSearchAuthor.TabIndex = 1;
      this.lblSearchAuthor.Text = "Author:";
      // 
      // txtSearchTitle
      // 
      this.txtSearchTitle.Location = new System.Drawing.Point(63, 22);
      this.txtSearchTitle.Name = "txtSearchTitle";
      this.txtSearchTitle.Size = new System.Drawing.Size(136, 20);
      this.txtSearchTitle.TabIndex = 2;
      // 
      // txtSearchAuthor
      // 
      this.txtSearchAuthor.Location = new System.Drawing.Point(263, 22);
      this.txtSearchAuthor.Name = "txtSearchAuthor";
      this.txtSearchAuthor.Size = new System.Drawing.Size(139, 20);
      this.txtSearchAuthor.TabIndex = 3;
      // 
      // btnSearch
      // 
      this.btnSearch.Location = new System.Drawing.Point(420, 20);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(75, 23);
      this.btnSearch.TabIndex = 4;
      this.btnSearch.Text = "Search";
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // booksGridView
      // 
      this.booksGridView.AllowUserToAddRows = false;
      this.booksGridView.AllowUserToDeleteRows = false;
      this.booksGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.booksGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colAuthor,
            this.colGenre,
            this.colPrice,
            this.colPublishDate});
      this.booksGridView.Location = new System.Drawing.Point(10, 78);
      this.booksGridView.Name = "booksGridView";
      this.booksGridView.ReadOnly = true;
      this.booksGridView.Size = new System.Drawing.Size(742, 400);
      this.booksGridView.TabIndex = 1;
      // 
      // btnAddBook
      // 
      this.btnAddBook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAddBook.Location = new System.Drawing.Point(7, 13);
      this.btnAddBook.Name = "btnAddBook";
      this.btnAddBook.Size = new System.Drawing.Size(74, 23);
      this.btnAddBook.TabIndex = 2;
      this.btnAddBook.Text = "Add Book";
      this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
      // 
      // btnEditBook
      // 
      this.btnEditBook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnEditBook.Location = new System.Drawing.Point(7, 52);
      this.btnEditBook.Name = "btnEditBook";
      this.btnEditBook.Size = new System.Drawing.Size(74, 23);
      this.btnEditBook.TabIndex = 3;
      this.btnEditBook.Text = "Edit Book";
      this.btnEditBook.Click += new System.EventHandler(this.btnEditBook_Click);
      // 
      // btnDeleteBook
      // 
      this.btnDeleteBook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDeleteBook.Location = new System.Drawing.Point(7, 91);
      this.btnDeleteBook.Name = "btnDeleteBook";
      this.btnDeleteBook.Size = new System.Drawing.Size(74, 23);
      this.btnDeleteBook.TabIndex = 4;
      this.btnDeleteBook.Text = "Delete Book";
      this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
      // 
      // genresTab
      // 
      this.genresTab.Controls.Add(this.genresGridView);
      this.genresTab.Location = new System.Drawing.Point(4, 22);
      this.genresTab.Name = "genresTab";
      this.genresTab.Padding = new System.Windows.Forms.Padding(3);
      this.genresTab.Size = new System.Drawing.Size(859, 486);
      this.genresTab.TabIndex = 1;
      this.genresTab.Text = "Genres";
      // 
      // genresGridView
      // 
      this.genresGridView.AllowUserToAddRows = false;
      this.genresGridView.AllowUserToDeleteRows = false;
      this.genresGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.genresGridView.Location = new System.Drawing.Point(10, 10);
      this.genresGridView.Name = "genresGridView";
      this.genresGridView.ReadOnly = true;
      this.genresGridView.Size = new System.Drawing.Size(761, 468);
      this.genresGridView.TabIndex = 0;
      // 
      // usersTab
      // 
      this.usersTab.Controls.Add(this.usersGridView);
      this.usersTab.Location = new System.Drawing.Point(4, 22);
      this.usersTab.Name = "usersTab";
      this.usersTab.Padding = new System.Windows.Forms.Padding(3);
      this.usersTab.Size = new System.Drawing.Size(859, 486);
      this.usersTab.TabIndex = 2;
      this.usersTab.Text = "Users";
      // 
      // usersGridView
      // 
      this.usersGridView.AllowUserToAddRows = false;
      this.usersGridView.AllowUserToDeleteRows = false;
      this.usersGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.usersGridView.Location = new System.Drawing.Point(10, 10);
      this.usersGridView.Name = "usersGridView";
      this.usersGridView.ReadOnly = true;
      this.usersGridView.Size = new System.Drawing.Size(711, 468);
      this.usersGridView.TabIndex = 0;
      // 
      // ordersGridView
      // 
      this.ordersGridView.Location = new System.Drawing.Point(0, 0);
      this.ordersGridView.Name = "ordersGridView";
      this.ordersGridView.Size = new System.Drawing.Size(240, 150);
      this.ordersGridView.TabIndex = 0;
      // 
      // btnAddOrder
      // 
      this.btnAddOrder.Location = new System.Drawing.Point(0, 0);
      this.btnAddOrder.Name = "btnAddOrder";
      this.btnAddOrder.Size = new System.Drawing.Size(75, 23);
      this.btnAddOrder.TabIndex = 0;
      // 
      // btnEditOrder
      // 
      this.btnEditOrder.Location = new System.Drawing.Point(0, 0);
      this.btnEditOrder.Name = "btnEditOrder";
      this.btnEditOrder.Size = new System.Drawing.Size(75, 23);
      this.btnEditOrder.TabIndex = 0;
      // 
      // btnDeleteOrder
      // 
      this.btnDeleteOrder.Location = new System.Drawing.Point(0, 0);
      this.btnDeleteOrder.Name = "btnDeleteOrder";
      this.btnDeleteOrder.Size = new System.Drawing.Size(75, 23);
      this.btnDeleteOrder.TabIndex = 0;
      // 
      // colId
      // 
      this.colId.DataPropertyName = "Id";
      this.colId.HeaderText = "Id";
      this.colId.Name = "colId";
      // 
      // colName
      // 
      this.colName.DataPropertyName = "Title";
      this.colName.HeaderText = "Title";
      this.colName.Name = "colName";
      // 
      // colAuthor
      // 
      this.colAuthor.DataPropertyName = "Author";
      this.colAuthor.HeaderText = "Author";
      this.colAuthor.Name = "colAuthor";
      // 
      // colGenre
      // 
      this.colGenre.DataPropertyName = "Genre";
      this.colGenre.HeaderText = "Genre";
      this.colGenre.Name = "colGenre";
      // 
      // colPrice
      // 
      this.colPrice.DataPropertyName = "Price";
      this.colPrice.HeaderText = "Price";
      this.colPrice.Name = "colPrice";
      // 
      // colPublishDate
      // 
      this.colPublishDate.DataPropertyName = "PublishedDate";
      this.colPublishDate.HeaderText = "Published Date";
      this.colPublishDate.Name = "colPublishDate";
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Controls.Add(this.btnAddBook);
      this.panel1.Controls.Add(this.btnDeleteBook);
      this.panel1.Controls.Add(this.btnEditBook);
      this.panel1.Location = new System.Drawing.Point(767, 78);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(84, 190);
      this.panel1.TabIndex = 5;
      // 
      // btnReset
      // 
      this.btnReset.Location = new System.Drawing.Point(501, 20);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new System.Drawing.Size(75, 23);
      this.btnReset.TabIndex = 4;
      this.btnReset.Text = "Reset";
      this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
      // 
      // MainForm
      // 
      this.ClientSize = new System.Drawing.Size(867, 512);
      this.Controls.Add(this.tabControl);
      this.Name = "MainForm";
      this.Text = "Books app";
      this.tabControl.ResumeLayout(false);
      this.booksTab.ResumeLayout(false);
      this.searchPanel.ResumeLayout(false);
      this.searchPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.booksGridView)).EndInit();
      this.genresTab.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.genresGridView)).EndInit();
      this.usersTab.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).EndInit();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    private System.Windows.Forms.DataGridViewTextBoxColumn colId;
    private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colAuthor;
    private System.Windows.Forms.DataGridViewTextBoxColumn colGenre;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPublishDate;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnReset;
  }
}

