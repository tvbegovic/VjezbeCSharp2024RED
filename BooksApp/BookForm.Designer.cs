namespace BooksApp
{
  partial class BookForm
  {
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblAuthor;
    private System.Windows.Forms.Label lblGenre;
    private System.Windows.Forms.Label lblPublishedDate;
    private System.Windows.Forms.Label lblPrice;
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.TextBox txtAuthor;
    private System.Windows.Forms.ComboBox cbGenre;
    private System.Windows.Forms.TextBox txtPrice;

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
      this.btnSave = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.lblTitle = new System.Windows.Forms.Label();
      this.lblAuthor = new System.Windows.Forms.Label();
      this.lblGenre = new System.Windows.Forms.Label();
      this.lblPublishedDate = new System.Windows.Forms.Label();
      this.lblPrice = new System.Windows.Forms.Label();
      this.txtTitle = new System.Windows.Forms.TextBox();
      this.txtAuthor = new System.Windows.Forms.TextBox();
      this.cbGenre = new System.Windows.Forms.ComboBox();
      this.txtPrice = new System.Windows.Forms.TextBox();
      this.txtPublishedDate = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(12, 12);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 30);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(100, 12);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 30);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // lblTitle
      // 
      this.lblTitle.AutoSize = true;
      this.lblTitle.Location = new System.Drawing.Point(12, 60);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(30, 13);
      this.lblTitle.TabIndex = 2;
      this.lblTitle.Text = "Title:";
      // 
      // lblAuthor
      // 
      this.lblAuthor.AutoSize = true;
      this.lblAuthor.Location = new System.Drawing.Point(12, 100);
      this.lblAuthor.Name = "lblAuthor";
      this.lblAuthor.Size = new System.Drawing.Size(41, 13);
      this.lblAuthor.TabIndex = 4;
      this.lblAuthor.Text = "Author:";
      // 
      // lblGenre
      // 
      this.lblGenre.AutoSize = true;
      this.lblGenre.Location = new System.Drawing.Point(12, 140);
      this.lblGenre.Name = "lblGenre";
      this.lblGenre.Size = new System.Drawing.Size(39, 13);
      this.lblGenre.TabIndex = 6;
      this.lblGenre.Text = "Genre:";
      // 
      // lblPublishedDate
      // 
      this.lblPublishedDate.AutoSize = true;
      this.lblPublishedDate.Location = new System.Drawing.Point(12, 180);
      this.lblPublishedDate.Name = "lblPublishedDate";
      this.lblPublishedDate.Size = new System.Drawing.Size(82, 13);
      this.lblPublishedDate.TabIndex = 8;
      this.lblPublishedDate.Text = "Published Date:";
      // 
      // lblPrice
      // 
      this.lblPrice.AutoSize = true;
      this.lblPrice.Location = new System.Drawing.Point(12, 220);
      this.lblPrice.Name = "lblPrice";
      this.lblPrice.Size = new System.Drawing.Size(34, 13);
      this.lblPrice.TabIndex = 10;
      this.lblPrice.Text = "Price:";
      // 
      // txtTitle
      // 
      this.txtTitle.Location = new System.Drawing.Point(100, 57);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.Size = new System.Drawing.Size(250, 20);
      this.txtTitle.TabIndex = 3;
      // 
      // txtAuthor
      // 
      this.txtAuthor.Location = new System.Drawing.Point(100, 97);
      this.txtAuthor.Name = "txtAuthor";
      this.txtAuthor.Size = new System.Drawing.Size(250, 20);
      this.txtAuthor.TabIndex = 5;
      // 
      // cbGenre
      // 
      this.cbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbGenre.Location = new System.Drawing.Point(100, 137);
      this.cbGenre.Name = "cbGenre";
      this.cbGenre.Size = new System.Drawing.Size(250, 21);
      this.cbGenre.TabIndex = 7;
      // 
      // txtPrice
      // 
      this.txtPrice.Location = new System.Drawing.Point(100, 217);
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.Size = new System.Drawing.Size(250, 20);
      this.txtPrice.TabIndex = 11;
      // 
      // txtPublishedDate
      // 
      this.txtPublishedDate.Location = new System.Drawing.Point(101, 180);
      this.txtPublishedDate.Name = "txtPublishedDate";
      this.txtPublishedDate.Size = new System.Drawing.Size(249, 20);
      this.txtPublishedDate.TabIndex = 12;
      // 
      // BookForm
      // 
      this.ClientSize = new System.Drawing.Size(400, 300);
      this.Controls.Add(this.txtPublishedDate);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.lblTitle);
      this.Controls.Add(this.txtTitle);
      this.Controls.Add(this.lblAuthor);
      this.Controls.Add(this.txtAuthor);
      this.Controls.Add(this.lblGenre);
      this.Controls.Add(this.cbGenre);
      this.Controls.Add(this.lblPublishedDate);
      this.Controls.Add(this.lblPrice);
      this.Controls.Add(this.txtPrice);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "BookForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    private System.Windows.Forms.TextBox txtPublishedDate;
  }
}