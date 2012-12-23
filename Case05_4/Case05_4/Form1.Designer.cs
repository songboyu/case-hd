namespace Case05_4
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
	/// download by http://www.codefans.net
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_删除病历 = new System.Windows.Forms.Button();
            this.dateTimePicker_起始 = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_姓名 = new System.Windows.Forms.TextBox();
            this.comboBox_检查医师 = new System.Windows.Forms.ComboBox();
            this.comboBox_申请科室 = new System.Windows.Forms.ComboBox();
            this.button_清空 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_病历号 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.button_还原 = new System.Windows.Forms.Button();
            this.dateTimePicker_终止 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button_新建病历 = new System.Windows.Forms.Button();
            this.button_返回 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.infoTableAdapter = new Case05_4.病历信息DataSetTableAdapters.infoTableAdapter();
            this.tableAdapterManager = new Case05_4.病历信息DataSetTableAdapters.TableAdapterManager();
            this.DataSet = new Case05_4.病历信息DataSet();
            this.infoDataGridView = new System.Windows.Forms.DataGridView();
            this.病历号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性别DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.年龄DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.检查医师DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.申请科室DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.就诊时间DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button_删除病历
            // 
            this.button_删除病历.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_删除病历.BackColor = System.Drawing.Color.Transparent;
            this.button_删除病历.Image = ((System.Drawing.Image)(resources.GetObject("button_删除病历.Image")));
            this.button_删除病历.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_删除病历.Location = new System.Drawing.Point(782, 459);
            this.button_删除病历.Name = "button_删除病历";
            this.button_删除病历.Size = new System.Drawing.Size(192, 26);
            this.button_删除病历.TabIndex = 6;
            this.button_删除病历.Text = "删除病历(&E)";
            this.button_删除病历.UseVisualStyleBackColor = false;
            this.button_删除病历.Click += new System.EventHandler(this.button_删除病历_Click);
            // 
            // dateTimePicker_起始
            // 
            this.dateTimePicker_起始.Checked = false;
            this.dateTimePicker_起始.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_起始.Location = new System.Drawing.Point(20, 33);
            this.dateTimePicker_起始.Name = "dateTimePicker_起始";
            this.dateTimePicker_起始.Size = new System.Drawing.Size(152, 21);
            this.dateTimePicker_起始.TabIndex = 3;
            this.dateTimePicker_起始.CloseUp += new System.EventHandler(this.dateTimePicker_起始_CloseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(775, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(199, 221);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox_姓名);
            this.tabPage1.Controls.Add(this.comboBox_检查医师);
            this.tabPage1.Controls.Add(this.comboBox_申请科室);
            this.tabPage1.Controls.Add(this.button_清空);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(191, 196);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "详细信息";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "检查医师";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "申请科室";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "姓名";
            // 
            // textBox_姓名
            // 
            this.textBox_姓名.Location = new System.Drawing.Point(22, 25);
            this.textBox_姓名.Name = "textBox_姓名";
            this.textBox_姓名.Size = new System.Drawing.Size(150, 21);
            this.textBox_姓名.TabIndex = 0;
            this.textBox_姓名.TextChanged += new System.EventHandler(this.textBox_姓名_TextChanged);
            // 
            // comboBox_检查医师
            // 
            this.comboBox_检查医师.FormattingEnabled = true;
            this.comboBox_检查医师.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g"});
            this.comboBox_检查医师.Location = new System.Drawing.Point(22, 102);
            this.comboBox_检查医师.Name = "comboBox_检查医师";
            this.comboBox_检查医师.Size = new System.Drawing.Size(150, 20);
            this.comboBox_检查医师.TabIndex = 3;
            this.comboBox_检查医师.TextChanged += new System.EventHandler(this.comboBox_检查医师_TextChanged);
            // 
            // comboBox_申请科室
            // 
            this.comboBox_申请科室.FormattingEnabled = true;
            this.comboBox_申请科室.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g"});
            this.comboBox_申请科室.Location = new System.Drawing.Point(22, 64);
            this.comboBox_申请科室.Name = "comboBox_申请科室";
            this.comboBox_申请科室.Size = new System.Drawing.Size(150, 20);
            this.comboBox_申请科室.TabIndex = 2;
            this.comboBox_申请科室.TextChanged += new System.EventHandler(this.comboBox_申请科室_TextChanged);
            // 
            // button_清空
            // 
            this.button_清空.BackColor = System.Drawing.Color.Transparent;
            this.button_清空.Location = new System.Drawing.Point(22, 141);
            this.button_清空.Name = "button_清空";
            this.button_清空.Size = new System.Drawing.Size(150, 23);
            this.button_清空.TabIndex = 4;
            this.button_清空.Text = "清空(&R)";
            this.button_清空.UseVisualStyleBackColor = false;
            this.button_清空.Click += new System.EventHandler(this.button_清空_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.textBox_病历号);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(191, 196);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "病历号";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(22, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "清空(&M)";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "病历号";
            // 
            // textBox_病历号
            // 
            this.textBox_病历号.Location = new System.Drawing.Point(21, 50);
            this.textBox_病历号.Name = "textBox_病历号";
            this.textBox_病历号.Size = new System.Drawing.Size(150, 21);
            this.textBox_病历号.TabIndex = 7;
            this.textBox_病历号.TextChanged += new System.EventHandler(this.textBox_病历号_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.dateTimePicker_起始);
            this.tabPage3.Controls.Add(this.button_还原);
            this.tabPage3.Controls.Add(this.dateTimePicker_终止);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(191, 196);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "诊断时间";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "终止时间";
            // 
            // button_还原
            // 
            this.button_还原.BackColor = System.Drawing.Color.Transparent;
            this.button_还原.Location = new System.Drawing.Point(22, 141);
            this.button_还原.Name = "button_还原";
            this.button_还原.Size = new System.Drawing.Size(150, 23);
            this.button_还原.TabIndex = 18;
            this.button_还原.Text = "还原(&U)";
            this.button_还原.UseVisualStyleBackColor = false;
            this.button_还原.Click += new System.EventHandler(this.button_还原_Click);
            // 
            // dateTimePicker_终止
            // 
            this.dateTimePicker_终止.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_终止.Location = new System.Drawing.Point(22, 82);
            this.dateTimePicker_终止.Name = "dateTimePicker_终止";
            this.dateTimePicker_终止.Size = new System.Drawing.Size(152, 21);
            this.dateTimePicker_终止.TabIndex = 5;
            this.dateTimePicker_终止.Value = new System.DateTime(2012, 12, 25, 23, 59, 59, 0);
            this.dateTimePicker_终止.CloseUp += new System.EventHandler(this.dateTimePicker_终止_CloseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "起始时间";
            // 
            // button_新建病历
            // 
            this.button_新建病历.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_新建病历.BackColor = System.Drawing.Color.Transparent;
            this.button_新建病历.Image = ((System.Drawing.Image)(resources.GetObject("button_新建病历.Image")));
            this.button_新建病历.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_新建病历.Location = new System.Drawing.Point(782, 427);
            this.button_新建病历.Name = "button_新建病历";
            this.button_新建病历.Size = new System.Drawing.Size(192, 26);
            this.button_新建病历.TabIndex = 5;
            this.button_新建病历.Text = "新建病历(&W)";
            this.button_新建病历.UseVisualStyleBackColor = false;
            this.button_新建病历.Click += new System.EventHandler(this.button_新建病历_Click);
            // 
            // button_返回
            // 
            this.button_返回.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_返回.BackColor = System.Drawing.Color.Transparent;
            this.button_返回.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_返回.Image = ((System.Drawing.Image)(resources.GetObject("button_返回.Image")));
            this.button_返回.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_返回.Location = new System.Drawing.Point(782, 523);
            this.button_返回.Name = "button_返回";
            this.button_返回.Size = new System.Drawing.Size(192, 26);
            this.button_返回.TabIndex = 7;
            this.button_返回.Text = "返回(&Q)";
            this.button_返回.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(782, 491);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 26);
            this.button1.TabIndex = 18;
            this.button1.Text = "刷新(&D)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // infoTableAdapter
            // 
            this.infoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.infoTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Case05_4.病历信息DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // DataSet
            // 
            this.DataSet.DataSetName = "DataSet";
            this.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // infoDataGridView
            // 
            this.infoDataGridView.AllowUserToAddRows = false;
            this.infoDataGridView.AllowUserToResizeColumns = false;
            this.infoDataGridView.AllowUserToResizeRows = false;
            this.infoDataGridView.AutoGenerateColumns = false;
            this.infoDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.infoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.infoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.病历号,
            this.姓名DataGridViewTextBoxColumn,
            this.性别DataGridViewTextBoxColumn,
            this.年龄DataGridViewTextBoxColumn,
            this.检查医师DataGridViewTextBoxColumn,
            this.申请科室DataGridViewTextBoxColumn,
            this.就诊时间DataGridViewTextBoxColumn});
            this.infoDataGridView.DataSource = this.infoBindingSource;
            this.infoDataGridView.Location = new System.Drawing.Point(25, 36);
            this.infoDataGridView.MultiSelect = false;
            this.infoDataGridView.Name = "infoDataGridView";
            this.infoDataGridView.ReadOnly = true;
            this.infoDataGridView.RowHeadersWidth = 28;
            this.infoDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.infoDataGridView.RowTemplate.Height = 23;
            this.infoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.infoDataGridView.Size = new System.Drawing.Size(730, 513);
            this.infoDataGridView.TabIndex = 17;
            this.infoDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.infoDataGridView_CellDoubleClick);
            // 
            // 病历号
            // 
            this.病历号.DataPropertyName = "病历号";
            this.病历号.HeaderText = "病历号";
            this.病历号.Name = "病历号";
            this.病历号.ReadOnly = true;
            // 
            // 姓名DataGridViewTextBoxColumn
            // 
            this.姓名DataGridViewTextBoxColumn.DataPropertyName = "姓名";
            this.姓名DataGridViewTextBoxColumn.HeaderText = "姓名";
            this.姓名DataGridViewTextBoxColumn.Name = "姓名DataGridViewTextBoxColumn";
            this.姓名DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 性别DataGridViewTextBoxColumn
            // 
            this.性别DataGridViewTextBoxColumn.DataPropertyName = "性别";
            this.性别DataGridViewTextBoxColumn.HeaderText = "性别";
            this.性别DataGridViewTextBoxColumn.Name = "性别DataGridViewTextBoxColumn";
            this.性别DataGridViewTextBoxColumn.ReadOnly = true;
            this.性别DataGridViewTextBoxColumn.Width = 70;
            // 
            // 年龄DataGridViewTextBoxColumn
            // 
            this.年龄DataGridViewTextBoxColumn.DataPropertyName = "年龄";
            this.年龄DataGridViewTextBoxColumn.HeaderText = "年龄";
            this.年龄DataGridViewTextBoxColumn.Name = "年龄DataGridViewTextBoxColumn";
            this.年龄DataGridViewTextBoxColumn.ReadOnly = true;
            this.年龄DataGridViewTextBoxColumn.Width = 70;
            // 
            // 检查医师DataGridViewTextBoxColumn
            // 
            this.检查医师DataGridViewTextBoxColumn.DataPropertyName = "检查医师";
            this.检查医师DataGridViewTextBoxColumn.HeaderText = "检查医师";
            this.检查医师DataGridViewTextBoxColumn.Name = "检查医师DataGridViewTextBoxColumn";
            this.检查医师DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 申请科室DataGridViewTextBoxColumn
            // 
            this.申请科室DataGridViewTextBoxColumn.DataPropertyName = "申请科室";
            this.申请科室DataGridViewTextBoxColumn.HeaderText = "申请科室";
            this.申请科室DataGridViewTextBoxColumn.Name = "申请科室DataGridViewTextBoxColumn";
            this.申请科室DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 就诊时间DataGridViewTextBoxColumn
            // 
            this.就诊时间DataGridViewTextBoxColumn.DataPropertyName = "就诊时间";
            this.就诊时间DataGridViewTextBoxColumn.HeaderText = "就诊时间";
            this.就诊时间DataGridViewTextBoxColumn.Name = "就诊时间DataGridViewTextBoxColumn";
            this.就诊时间DataGridViewTextBoxColumn.ReadOnly = true;
            this.就诊时间DataGridViewTextBoxColumn.Width = 160;
            // 
            // infoBindingSource
            // 
            this.infoBindingSource.DataMember = "info";
            this.infoBindingSource.DataSource = this.DataSet;
            this.infoBindingSource.Filter = "Deleted=0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.button_返回;
            this.ClientSize = new System.Drawing.Size(986, 569);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.infoDataGridView);
            this.Controls.Add(this.button_返回);
            this.Controls.Add(this.button_新建病历);
            this.Controls.Add(this.button_删除病历);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病历库";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_删除病历;
        private System.Windows.Forms.DateTimePicker dateTimePicker_起始;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker_终止;
        private System.Windows.Forms.Button button_新建病历;
        private System.Windows.Forms.Button button_返回;
        private 病历信息DataSetTableAdapters.infoTableAdapter infoTableAdapter;
        private 病历信息DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button button_还原;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_姓名;
        private System.Windows.Forms.ComboBox comboBox_检查医师;
        private System.Windows.Forms.ComboBox comboBox_申请科室;
        private System.Windows.Forms.Button button_清空;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_病历号;
        private System.Windows.Forms.Button button2;
        private 病历信息DataSet DataSet;
        private System.Windows.Forms.DataGridView infoDataGridView;
        private System.Windows.Forms.BindingSource infoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn 病历号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 性别DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 年龄DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 检查医师DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 申请科室DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 就诊时间DataGridViewTextBoxColumn;
    }
}

