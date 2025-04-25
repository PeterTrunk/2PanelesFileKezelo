namespace TrunksCommander
{
    partial class MainForm
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
            if (disposing && (components != null))
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.LeftSideList = new System.Windows.Forms.ListView();
            this.Icon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileKiterjesztes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileMeret = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Datum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IkonLista = new System.Windows.Forms.ImageList(this.components);
            this.RightSideList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LeftPathBox = new System.Windows.Forms.TextBox();
            this.RightPathBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.frissítésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.újMappaF7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editF4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.törlésF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyF5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveF6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewF3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beállításokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.CopyButton = new System.Windows.Forms.Button();
            this.MozgatButton = new System.Windows.Forms.Button();
            this.NewFolderButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.LeftDrives = new System.Windows.Forms.ComboBox();
            this.RightDrives = new System.Windows.Forms.ComboBox();
            this.LeftLabel = new System.Windows.Forms.Label();
            this.RightLabel = new System.Windows.Forms.Label();
            this.LeftOsszegLabel = new System.Windows.Forms.Label();
            this.RightOsszegLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftSideList
            // 
            this.LeftSideList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LeftSideList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Icon,
            this.FileName,
            this.FileKiterjesztes,
            this.FileMeret,
            this.Datum});
            this.LeftSideList.HideSelection = false;
            this.LeftSideList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.LeftSideList.Location = new System.Drawing.Point(23, 118);
            this.LeftSideList.Name = "LeftSideList";
            this.LeftSideList.Size = new System.Drawing.Size(432, 244);
            this.LeftSideList.TabIndex = 0;
            this.LeftSideList.UseCompatibleStateImageBehavior = false;
            this.LeftSideList.SelectedIndexChanged += new System.EventHandler(this.LeftSideList_SelectedIndexChanged);
            this.LeftSideList.DoubleClick += new System.EventHandler(this.LeftSideList_DoubleClick);
            this.LeftSideList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LeftSideList_KeyDown);
            // 
            // Icon
            // 
            this.Icon.Text = "";
            this.Icon.Width = 20;
            // 
            // FileName
            // 
            this.FileName.Text = "Name";
            this.FileName.Width = 120;
            // 
            // FileKiterjesztes
            // 
            this.FileKiterjesztes.Text = "KIterjesztés";
            // 
            // FileMeret
            // 
            this.FileMeret.Text = "Méret";
            // 
            // Datum
            // 
            this.Datum.Text = "Dátum";
            this.Datum.Width = 120;
            // 
            // IkonLista
            // 
            this.IkonLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IkonLista.ImageStream")));
            this.IkonLista.TransparentColor = System.Drawing.Color.Transparent;
            this.IkonLista.Images.SetKeyName(0, "folder.ico");
            this.IkonLista.Images.SetKeyName(1, "back.ico");
            this.IkonLista.Images.SetKeyName(2, "exe.ico");
            this.IkonLista.Images.SetKeyName(3, "file.ico");
            this.IkonLista.Images.SetKeyName(4, "floppy.ico");
            this.IkonLista.Images.SetKeyName(5, "kep.ico");
            this.IkonLista.Images.SetKeyName(6, "lomtar.ico");
            this.IkonLista.Images.SetKeyName(7, "text.ico");
            this.IkonLista.Images.SetKeyName(8, "video.ico");
            this.IkonLista.Images.SetKeyName(9, "zene.ico");
            this.IkonLista.Images.SetKeyName(10, "frissit.ico");
            // 
            // RightSideList
            // 
            this.RightSideList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RightSideList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.RightSideList.HideSelection = false;
            this.RightSideList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.RightSideList.Location = new System.Drawing.Point(461, 118);
            this.RightSideList.Name = "RightSideList";
            this.RightSideList.Size = new System.Drawing.Size(429, 244);
            this.RightSideList.TabIndex = 1;
            this.RightSideList.UseCompatibleStateImageBehavior = false;
            this.RightSideList.SelectedIndexChanged += new System.EventHandler(this.RightSideList_SelectedIndexChanged);
            this.RightSideList.DoubleClick += new System.EventHandler(this.RightSideList_DoubleClick);
            this.RightSideList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RightSideList_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 20;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "KIterjesztés";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Méret";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Dátum";
            this.columnHeader5.Width = 120;
            // 
            // LeftPathBox
            // 
            this.LeftPathBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LeftPathBox.Location = new System.Drawing.Point(23, 86);
            this.LeftPathBox.Name = "LeftPathBox";
            this.LeftPathBox.Size = new System.Drawing.Size(372, 26);
            this.LeftPathBox.TabIndex = 2;
            // 
            // RightPathBox
            // 
            this.RightPathBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RightPathBox.Location = new System.Drawing.Point(461, 86);
            this.RightPathBox.Name = "RightPathBox";
            this.RightPathBox.Size = new System.Drawing.Size(372, 26);
            this.RightPathBox.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frissítésToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 29);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 29);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // frissítésToolStripMenuItem
            // 
            this.frissítésToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("frissítésToolStripMenuItem.Image")));
            this.frissítésToolStripMenuItem.Name = "frissítésToolStripMenuItem";
            this.frissítésToolStripMenuItem.Size = new System.Drawing.Size(94, 25);
            this.frissítésToolStripMenuItem.Text = "Frissítés";
            this.frissítésToolStripMenuItem.Click += new System.EventHandler(this.frissítésToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.beállításokToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(902, 29);
            this.menuStrip2.TabIndex = 5;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.újMappaF7ToolStripMenuItem,
            this.editF4ToolStripMenuItem,
            this.törlésF8ToolStripMenuItem,
            this.copyF5ToolStripMenuItem,
            this.moveF6ToolStripMenuItem,
            this.viewF3ToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(62, 25);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // újMappaF7ToolStripMenuItem
            // 
            this.újMappaF7ToolStripMenuItem.Name = "újMappaF7ToolStripMenuItem";
            this.újMappaF7ToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.újMappaF7ToolStripMenuItem.Text = "Új Mappa (F7)";
            this.újMappaF7ToolStripMenuItem.Click += new System.EventHandler(this.újMappaF7ToolStripMenuItem_Click);
            // 
            // editF4ToolStripMenuItem
            // 
            this.editF4ToolStripMenuItem.Name = "editF4ToolStripMenuItem";
            this.editF4ToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.editF4ToolStripMenuItem.Text = "Edit (F4)";
            this.editF4ToolStripMenuItem.Click += new System.EventHandler(this.editF4ToolStripMenuItem_Click);
            // 
            // törlésF8ToolStripMenuItem
            // 
            this.törlésF8ToolStripMenuItem.Name = "törlésF8ToolStripMenuItem";
            this.törlésF8ToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.törlésF8ToolStripMenuItem.Text = "Törlés (F8)";
            this.törlésF8ToolStripMenuItem.Click += new System.EventHandler(this.törlésF8ToolStripMenuItem_Click);
            // 
            // copyF5ToolStripMenuItem
            // 
            this.copyF5ToolStripMenuItem.Name = "copyF5ToolStripMenuItem";
            this.copyF5ToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.copyF5ToolStripMenuItem.Text = "Copy (F5)";
            this.copyF5ToolStripMenuItem.Click += new System.EventHandler(this.copyF5ToolStripMenuItem_Click);
            // 
            // moveF6ToolStripMenuItem
            // 
            this.moveF6ToolStripMenuItem.Name = "moveF6ToolStripMenuItem";
            this.moveF6ToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.moveF6ToolStripMenuItem.Text = "Move (F6)";
            this.moveF6ToolStripMenuItem.Click += new System.EventHandler(this.moveF6ToolStripMenuItem_Click);
            // 
            // viewF3ToolStripMenuItem
            // 
            this.viewF3ToolStripMenuItem.Name = "viewF3ToolStripMenuItem";
            this.viewF3ToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.viewF3ToolStripMenuItem.Text = "View (F3)";
            this.viewF3ToolStripMenuItem.Click += new System.EventHandler(this.viewF3ToolStripMenuItem_Click);
            // 
            // beállításokToolStripMenuItem
            // 
            this.beállításokToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.beállításokToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("beállításokToolStripMenuItem.Image")));
            this.beállításokToolStripMenuItem.Name = "beállításokToolStripMenuItem";
            this.beállításokToolStripMenuItem.Size = new System.Drawing.Size(112, 25);
            this.beállításokToolStripMenuItem.Text = "Beállítások";
            this.beállításokToolStripMenuItem.Click += new System.EventHandler(this.beállításokToolStripMenuItem_Click);
            // 
            // ViewButton
            // 
            this.ViewButton.Location = new System.Drawing.Point(23, 410);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(75, 23);
            this.ViewButton.TabIndex = 6;
            this.ViewButton.Text = "F3 View";
            this.ViewButton.UseVisualStyleBackColor = true;
            this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(104, 410);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 7;
            this.EditButton.Text = "F4 Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(185, 410);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(75, 23);
            this.CopyButton.TabIndex = 8;
            this.CopyButton.Text = "F5 Copy";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // MozgatButton
            // 
            this.MozgatButton.Location = new System.Drawing.Point(266, 410);
            this.MozgatButton.Name = "MozgatButton";
            this.MozgatButton.Size = new System.Drawing.Size(75, 23);
            this.MozgatButton.TabIndex = 9;
            this.MozgatButton.Text = "F6 Move";
            this.MozgatButton.UseVisualStyleBackColor = true;
            this.MozgatButton.Click += new System.EventHandler(this.MozgatButton_Click);
            // 
            // NewFolderButton
            // 
            this.NewFolderButton.Location = new System.Drawing.Point(347, 410);
            this.NewFolderButton.Name = "NewFolderButton";
            this.NewFolderButton.Size = new System.Drawing.Size(108, 23);
            this.NewFolderButton.TabIndex = 10;
            this.NewFolderButton.Text = "F7 New Folder";
            this.NewFolderButton.UseVisualStyleBackColor = true;
            this.NewFolderButton.Click += new System.EventHandler(this.NewFolderButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(461, 410);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 11;
            this.DeleteButton.Text = "F8 Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(542, 410);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 12;
            this.ExitButton.Text = "Alt + F4 Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LeftDrives
            // 
            this.LeftDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LeftDrives.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LeftDrives.FormattingEnabled = true;
            this.LeftDrives.Location = new System.Drawing.Point(401, 86);
            this.LeftDrives.Name = "LeftDrives";
            this.LeftDrives.Size = new System.Drawing.Size(54, 24);
            this.LeftDrives.TabIndex = 13;
            this.LeftDrives.SelectedIndexChanged += new System.EventHandler(this.LeftDrives_SelectedIndexChanged);
            // 
            // RightDrives
            // 
            this.RightDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RightDrives.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RightDrives.FormattingEnabled = true;
            this.RightDrives.Location = new System.Drawing.Point(839, 88);
            this.RightDrives.Name = "RightDrives";
            this.RightDrives.Size = new System.Drawing.Size(54, 24);
            this.RightDrives.TabIndex = 14;
            this.RightDrives.SelectedIndexChanged += new System.EventHandler(this.RightDrives_SelectedIndexChanged);
            // 
            // LeftLabel
            // 
            this.LeftLabel.AutoSize = true;
            this.LeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LeftLabel.Location = new System.Drawing.Point(20, 365);
            this.LeftLabel.Name = "LeftLabel";
            this.LeftLabel.Size = new System.Drawing.Size(44, 16);
            this.LeftLabel.TabIndex = 15;
            this.LeftLabel.Text = "label1";
            // 
            // RightLabel
            // 
            this.RightLabel.AutoSize = true;
            this.RightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RightLabel.Location = new System.Drawing.Point(458, 365);
            this.RightLabel.Name = "RightLabel";
            this.RightLabel.Size = new System.Drawing.Size(44, 16);
            this.RightLabel.TabIndex = 16;
            this.RightLabel.Text = "label2";
            // 
            // LeftOsszegLabel
            // 
            this.LeftOsszegLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LeftOsszegLabel.AutoSize = true;
            this.LeftOsszegLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LeftOsszegLabel.Location = new System.Drawing.Point(20, 387);
            this.LeftOsszegLabel.Name = "LeftOsszegLabel";
            this.LeftOsszegLabel.Size = new System.Drawing.Size(44, 16);
            this.LeftOsszegLabel.TabIndex = 17;
            this.LeftOsszegLabel.Text = "label1";
            this.LeftOsszegLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RightOsszegLabel
            // 
            this.RightOsszegLabel.AutoSize = true;
            this.RightOsszegLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RightOsszegLabel.Location = new System.Drawing.Point(458, 387);
            this.RightOsszegLabel.Name = "RightOsszegLabel";
            this.RightOsszegLabel.Size = new System.Drawing.Size(44, 16);
            this.RightOsszegLabel.TabIndex = 18;
            this.RightOsszegLabel.Text = "label1";
            this.RightOsszegLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 440);
            this.Controls.Add(this.RightOsszegLabel);
            this.Controls.Add(this.LeftOsszegLabel);
            this.Controls.Add(this.RightLabel);
            this.Controls.Add(this.LeftLabel);
            this.Controls.Add(this.RightDrives);
            this.Controls.Add(this.LeftDrives);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.NewFolderButton);
            this.Controls.Add(this.MozgatButton);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.ViewButton);
            this.Controls.Add(this.RightPathBox);
            this.Controls.Add(this.LeftPathBox);
            this.Controls.Add(this.RightSideList);
            this.Controls.Add(this.LeftSideList);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Commander";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LeftSideList;
        private System.Windows.Forms.ColumnHeader Icon;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FileKiterjesztes;
        private System.Windows.Forms.ColumnHeader FileMeret;
        private System.Windows.Forms.ColumnHeader Datum;
        private System.Windows.Forms.ImageList IkonLista;
        private System.Windows.Forms.ListView RightSideList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox LeftPathBox;
        private System.Windows.Forms.TextBox RightPathBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem frissítésToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beállításokToolStripMenuItem;
        private System.Windows.Forms.Button ViewButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button MozgatButton;
        private System.Windows.Forms.Button NewFolderButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ComboBox LeftDrives;
        private System.Windows.Forms.ComboBox RightDrives;
        private System.Windows.Forms.Label LeftLabel;
        private System.Windows.Forms.Label RightLabel;
        private System.Windows.Forms.ToolStripMenuItem újMappaF7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem törlésF8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyF5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveF6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editF4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewF3ToolStripMenuItem;
        private System.Windows.Forms.Label LeftOsszegLabel;
        private System.Windows.Forms.Label RightOsszegLabel;
    }
}

