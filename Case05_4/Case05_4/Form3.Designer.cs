namespace Case05_4
{
    partial class Form3
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
            System.Windows.Forms.Label 姓名Label;
            System.Windows.Forms.Label 性别Label;
            System.Windows.Forms.Label 年龄Label;
            System.Windows.Forms.Label 工作单位Label;
            System.Windows.Forms.Label 联系电话Label;
            System.Windows.Forms.Label 联系地址Label;
            System.Windows.Forms.Label 病历号Label;
            System.Windows.Forms.Label 门诊号Label;
            System.Windows.Forms.Label 住院号Label;
            System.Windows.Forms.Label 病区号Label;
            System.Windows.Forms.Label 床位号Label;
            System.Windows.Forms.Label 申请医师Label;
            System.Windows.Forms.Label 检查医师Label;
            System.Windows.Forms.Label 申请科室Label;
            System.Windows.Forms.Label 设备型号Label;
            System.Windows.Forms.Label 临床诊断Label;
            System.Windows.Forms.Label 病理诊断Label;
            System.Windows.Forms.Label 术后诊断Label;
            System.Windows.Forms.Label 诊断意见Label;
            System.Windows.Forms.Label 就诊时间Label;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.病历信息DataSet = new Case05_4.病历信息DataSet();
            this.infoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.infoTableAdapter = new Case05_4.病历信息DataSetTableAdapters.infoTableAdapter();
            this.姓名TextBox = new System.Windows.Forms.TextBox();
            this.性别ComboBox = new System.Windows.Forms.ComboBox();
            this.年龄TextBox = new System.Windows.Forms.TextBox();
            this.工作单位TextBox = new System.Windows.Forms.TextBox();
            this.联系电话TextBox = new System.Windows.Forms.TextBox();
            this.联系地址TextBox = new System.Windows.Forms.TextBox();
            this.病历号TextBox = new System.Windows.Forms.TextBox();
            this.门诊号TextBox = new System.Windows.Forms.TextBox();
            this.住院号TextBox = new System.Windows.Forms.TextBox();
            this.病区号TextBox = new System.Windows.Forms.TextBox();
            this.床位号TextBox = new System.Windows.Forms.TextBox();
            this.申请医师ComboBox = new System.Windows.Forms.ComboBox();
            this.检查医师ComboBox = new System.Windows.Forms.ComboBox();
            this.申请科室ComboBox = new System.Windows.Forms.ComboBox();
            this.设备型号ComboBox = new System.Windows.Forms.ComboBox();
            this.临床诊断ComboBox = new System.Windows.Forms.ComboBox();
            this.病理诊断ComboBox = new System.Windows.Forms.ComboBox();
            this.术后诊断ComboBox = new System.Windows.Forms.ComboBox();
            this.诊断意见ComboBox = new System.Windows.Forms.ComboBox();
            this.就诊时间TextBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tableAdapterManager = new Case05_4.病历信息DataSetTableAdapters.TableAdapterManager();
            this.病历信息DataSet1 = new Case05_4.病历信息DataSet1();
            this.doctorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.doctorTableAdapter = new Case05_4.病历信息DataSet1TableAdapters.doctorTableAdapter();
            姓名Label = new System.Windows.Forms.Label();
            性别Label = new System.Windows.Forms.Label();
            年龄Label = new System.Windows.Forms.Label();
            工作单位Label = new System.Windows.Forms.Label();
            联系电话Label = new System.Windows.Forms.Label();
            联系地址Label = new System.Windows.Forms.Label();
            病历号Label = new System.Windows.Forms.Label();
            门诊号Label = new System.Windows.Forms.Label();
            住院号Label = new System.Windows.Forms.Label();
            病区号Label = new System.Windows.Forms.Label();
            床位号Label = new System.Windows.Forms.Label();
            申请医师Label = new System.Windows.Forms.Label();
            检查医师Label = new System.Windows.Forms.Label();
            申请科室Label = new System.Windows.Forms.Label();
            设备型号Label = new System.Windows.Forms.Label();
            临床诊断Label = new System.Windows.Forms.Label();
            病理诊断Label = new System.Windows.Forms.Label();
            术后诊断Label = new System.Windows.Forms.Label();
            诊断意见Label = new System.Windows.Forms.Label();
            就诊时间Label = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.病历信息DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.病历信息DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doctorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // 姓名Label
            // 
            姓名Label.AutoSize = true;
            姓名Label.Location = new System.Drawing.Point(21, 24);
            姓名Label.Name = "姓名Label";
            姓名Label.Size = new System.Drawing.Size(35, 12);
            姓名Label.TabIndex = 1;
            姓名Label.Text = "姓名:";
            // 
            // 性别Label
            // 
            性别Label.AutoSize = true;
            性别Label.Location = new System.Drawing.Point(21, 51);
            性别Label.Name = "性别Label";
            性别Label.Size = new System.Drawing.Size(35, 12);
            性别Label.TabIndex = 3;
            性别Label.Text = "性别:";
            // 
            // 年龄Label
            // 
            年龄Label.AutoSize = true;
            年龄Label.Location = new System.Drawing.Point(21, 77);
            年龄Label.Name = "年龄Label";
            年龄Label.Size = new System.Drawing.Size(35, 12);
            年龄Label.TabIndex = 5;
            年龄Label.Text = "年龄:";
            // 
            // 工作单位Label
            // 
            工作单位Label.AutoSize = true;
            工作单位Label.Location = new System.Drawing.Point(21, 104);
            工作单位Label.Name = "工作单位Label";
            工作单位Label.Size = new System.Drawing.Size(59, 12);
            工作单位Label.TabIndex = 7;
            工作单位Label.Text = "工作单位:";
            // 
            // 联系电话Label
            // 
            联系电话Label.AutoSize = true;
            联系电话Label.Location = new System.Drawing.Point(21, 131);
            联系电话Label.Name = "联系电话Label";
            联系电话Label.Size = new System.Drawing.Size(59, 12);
            联系电话Label.TabIndex = 9;
            联系电话Label.Text = "联系电话:";
            // 
            // 联系地址Label
            // 
            联系地址Label.AutoSize = true;
            联系地址Label.Location = new System.Drawing.Point(21, 158);
            联系地址Label.Name = "联系地址Label";
            联系地址Label.Size = new System.Drawing.Size(59, 12);
            联系地址Label.TabIndex = 11;
            联系地址Label.Text = "联系地址:";
            // 
            // 病历号Label
            // 
            病历号Label.AutoSize = true;
            病历号Label.Location = new System.Drawing.Point(11, 40);
            病历号Label.Name = "病历号Label";
            病历号Label.Size = new System.Drawing.Size(47, 12);
            病历号Label.TabIndex = 15;
            病历号Label.Text = "病历号:";
            // 
            // 门诊号Label
            // 
            门诊号Label.AutoSize = true;
            门诊号Label.Location = new System.Drawing.Point(11, 67);
            门诊号Label.Name = "门诊号Label";
            门诊号Label.Size = new System.Drawing.Size(47, 12);
            门诊号Label.TabIndex = 17;
            门诊号Label.Text = "门诊号:";
            // 
            // 住院号Label
            // 
            住院号Label.AutoSize = true;
            住院号Label.Location = new System.Drawing.Point(11, 94);
            住院号Label.Name = "住院号Label";
            住院号Label.Size = new System.Drawing.Size(47, 12);
            住院号Label.TabIndex = 19;
            住院号Label.Text = "住院号:";
            // 
            // 病区号Label
            // 
            病区号Label.AutoSize = true;
            病区号Label.Location = new System.Drawing.Point(11, 121);
            病区号Label.Name = "病区号Label";
            病区号Label.Size = new System.Drawing.Size(47, 12);
            病区号Label.TabIndex = 21;
            病区号Label.Text = "病区号:";
            // 
            // 床位号Label
            // 
            床位号Label.AutoSize = true;
            床位号Label.Location = new System.Drawing.Point(11, 148);
            床位号Label.Name = "床位号Label";
            床位号Label.Size = new System.Drawing.Size(47, 12);
            床位号Label.TabIndex = 23;
            床位号Label.Text = "床位号:";
            // 
            // 申请医师Label
            // 
            申请医师Label.AutoSize = true;
            申请医师Label.Location = new System.Drawing.Point(21, 23);
            申请医师Label.Name = "申请医师Label";
            申请医师Label.Size = new System.Drawing.Size(59, 12);
            申请医师Label.TabIndex = 25;
            申请医师Label.Text = "申请医师:";
            // 
            // 检查医师Label
            // 
            检查医师Label.AutoSize = true;
            检查医师Label.Location = new System.Drawing.Point(21, 49);
            检查医师Label.Name = "检查医师Label";
            检查医师Label.Size = new System.Drawing.Size(59, 12);
            检查医师Label.TabIndex = 27;
            检查医师Label.Text = "检查医师:";
            // 
            // 申请科室Label
            // 
            申请科室Label.AutoSize = true;
            申请科室Label.Location = new System.Drawing.Point(21, 75);
            申请科室Label.Name = "申请科室Label";
            申请科室Label.Size = new System.Drawing.Size(59, 12);
            申请科室Label.TabIndex = 29;
            申请科室Label.Text = "申请科室:";
            // 
            // 设备型号Label
            // 
            设备型号Label.AutoSize = true;
            设备型号Label.Location = new System.Drawing.Point(21, 101);
            设备型号Label.Name = "设备型号Label";
            设备型号Label.Size = new System.Drawing.Size(59, 12);
            设备型号Label.TabIndex = 31;
            设备型号Label.Text = "设备型号:";
            // 
            // 临床诊断Label
            // 
            临床诊断Label.AutoSize = true;
            临床诊断Label.Location = new System.Drawing.Point(345, 23);
            临床诊断Label.Name = "临床诊断Label";
            临床诊断Label.Size = new System.Drawing.Size(59, 12);
            临床诊断Label.TabIndex = 33;
            临床诊断Label.Text = "临床诊断:";
            // 
            // 病理诊断Label
            // 
            病理诊断Label.AutoSize = true;
            病理诊断Label.Location = new System.Drawing.Point(345, 49);
            病理诊断Label.Name = "病理诊断Label";
            病理诊断Label.Size = new System.Drawing.Size(59, 12);
            病理诊断Label.TabIndex = 35;
            病理诊断Label.Text = "病理诊断:";
            // 
            // 术后诊断Label
            // 
            术后诊断Label.AutoSize = true;
            术后诊断Label.Location = new System.Drawing.Point(345, 75);
            术后诊断Label.Name = "术后诊断Label";
            术后诊断Label.Size = new System.Drawing.Size(59, 12);
            术后诊断Label.TabIndex = 37;
            术后诊断Label.Text = "术后诊断:";
            // 
            // 诊断意见Label
            // 
            诊断意见Label.AutoSize = true;
            诊断意见Label.Location = new System.Drawing.Point(345, 101);
            诊断意见Label.Name = "诊断意见Label";
            诊断意见Label.Size = new System.Drawing.Size(59, 12);
            诊断意见Label.TabIndex = 39;
            诊断意见Label.Text = "诊断意见:";
            // 
            // 就诊时间Label
            // 
            就诊时间Label.AutoSize = true;
            就诊时间Label.Location = new System.Drawing.Point(345, 129);
            就诊时间Label.Name = "就诊时间Label";
            就诊时间Label.Size = new System.Drawing.Size(59, 12);
            就诊时间Label.TabIndex = 41;
            就诊时间Label.Text = "就诊时间:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 129);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 12);
            label1.TabIndex = 41;
            label1.Text = "HP && HIV";
            // 
            // 病历信息DataSet
            // 
            this.病历信息DataSet.DataSetName = "病历信息DataSet";
            this.病历信息DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // infoBindingSource
            // 
            this.infoBindingSource.DataMember = "info";
            this.infoBindingSource.DataSource = this.病历信息DataSet;
            // 
            // infoTableAdapter
            // 
            this.infoTableAdapter.ClearBeforeFill = true;
            // 
            // 姓名TextBox
            // 
            this.姓名TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "姓名", true));
            this.姓名TextBox.Location = new System.Drawing.Point(86, 21);
            this.姓名TextBox.Name = "姓名TextBox";
            this.姓名TextBox.Size = new System.Drawing.Size(190, 21);
            this.姓名TextBox.TabIndex = 2;
            // 
            // 性别ComboBox
            // 
            this.性别ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "性别", true));
            this.性别ComboBox.FormattingEnabled = true;
            this.性别ComboBox.Items.AddRange(new object[] {
            "男",
            "女"});
            this.性别ComboBox.Location = new System.Drawing.Point(86, 48);
            this.性别ComboBox.Name = "性别ComboBox";
            this.性别ComboBox.Size = new System.Drawing.Size(190, 20);
            this.性别ComboBox.TabIndex = 4;
            // 
            // 年龄TextBox
            // 
            this.年龄TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "年龄", true));
            this.年龄TextBox.Location = new System.Drawing.Point(86, 74);
            this.年龄TextBox.Name = "年龄TextBox";
            this.年龄TextBox.Size = new System.Drawing.Size(190, 21);
            this.年龄TextBox.TabIndex = 6;
            this.年龄TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.年龄TextBox_KeyPress);
            // 
            // 工作单位TextBox
            // 
            this.工作单位TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "工作单位", true));
            this.工作单位TextBox.Location = new System.Drawing.Point(86, 101);
            this.工作单位TextBox.Name = "工作单位TextBox";
            this.工作单位TextBox.Size = new System.Drawing.Size(190, 21);
            this.工作单位TextBox.TabIndex = 8;
            // 
            // 联系电话TextBox
            // 
            this.联系电话TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "联系电话", true));
            this.联系电话TextBox.Location = new System.Drawing.Point(86, 128);
            this.联系电话TextBox.Name = "联系电话TextBox";
            this.联系电话TextBox.Size = new System.Drawing.Size(190, 21);
            this.联系电话TextBox.TabIndex = 10;
            // 
            // 联系地址TextBox
            // 
            this.联系地址TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "联系地址", true));
            this.联系地址TextBox.Location = new System.Drawing.Point(86, 155);
            this.联系地址TextBox.Name = "联系地址TextBox";
            this.联系地址TextBox.Size = new System.Drawing.Size(190, 21);
            this.联系地址TextBox.TabIndex = 12;
            // 
            // 病历号TextBox
            // 
            this.病历号TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "病历号", true));
            this.病历号TextBox.Enabled = false;
            this.病历号TextBox.Location = new System.Drawing.Point(76, 37);
            this.病历号TextBox.Name = "病历号TextBox";
            this.病历号TextBox.Size = new System.Drawing.Size(134, 21);
            this.病历号TextBox.TabIndex = 16;
            // 
            // 门诊号TextBox
            // 
            this.门诊号TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "门诊号", true));
            this.门诊号TextBox.Location = new System.Drawing.Point(76, 64);
            this.门诊号TextBox.Name = "门诊号TextBox";
            this.门诊号TextBox.Size = new System.Drawing.Size(134, 21);
            this.门诊号TextBox.TabIndex = 18;
            // 
            // 住院号TextBox
            // 
            this.住院号TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "住院号", true));
            this.住院号TextBox.Location = new System.Drawing.Point(76, 91);
            this.住院号TextBox.Name = "住院号TextBox";
            this.住院号TextBox.Size = new System.Drawing.Size(134, 21);
            this.住院号TextBox.TabIndex = 20;
            // 
            // 病区号TextBox
            // 
            this.病区号TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "病区号", true));
            this.病区号TextBox.Location = new System.Drawing.Point(76, 118);
            this.病区号TextBox.Name = "病区号TextBox";
            this.病区号TextBox.Size = new System.Drawing.Size(134, 21);
            this.病区号TextBox.TabIndex = 22;
            // 
            // 床位号TextBox
            // 
            this.床位号TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "床位号", true));
            this.床位号TextBox.Location = new System.Drawing.Point(76, 145);
            this.床位号TextBox.Name = "床位号TextBox";
            this.床位号TextBox.Size = new System.Drawing.Size(134, 21);
            this.床位号TextBox.TabIndex = 24;
            // 
            // 申请医师ComboBox
            // 
            this.申请医师ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "申请医师", true));
            this.申请医师ComboBox.DataSource = this.doctorBindingSource;
            this.申请医师ComboBox.DisplayMember = "name";
            this.申请医师ComboBox.FormattingEnabled = true;
            this.申请医师ComboBox.Location = new System.Drawing.Point(86, 20);
            this.申请医师ComboBox.Name = "申请医师ComboBox";
            this.申请医师ComboBox.Size = new System.Drawing.Size(190, 20);
            this.申请医师ComboBox.TabIndex = 26;
            // 
            // 检查医师ComboBox
            // 
            this.检查医师ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "检查医师", true));
            this.检查医师ComboBox.DataSource = this.doctorBindingSource;
            this.检查医师ComboBox.DisplayMember = "name";
            this.检查医师ComboBox.FormattingEnabled = true;
            this.检查医师ComboBox.Location = new System.Drawing.Point(86, 46);
            this.检查医师ComboBox.Name = "检查医师ComboBox";
            this.检查医师ComboBox.Size = new System.Drawing.Size(190, 20);
            this.检查医师ComboBox.TabIndex = 28;
            // 
            // 申请科室ComboBox
            // 
            this.申请科室ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "申请科室", true));
            this.申请科室ComboBox.FormattingEnabled = true;
            this.申请科室ComboBox.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f"});
            this.申请科室ComboBox.Location = new System.Drawing.Point(86, 72);
            this.申请科室ComboBox.Name = "申请科室ComboBox";
            this.申请科室ComboBox.Size = new System.Drawing.Size(190, 20);
            this.申请科室ComboBox.TabIndex = 30;
            // 
            // 设备型号ComboBox
            // 
            this.设备型号ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "设备型号", true));
            this.设备型号ComboBox.FormattingEnabled = true;
            this.设备型号ComboBox.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f"});
            this.设备型号ComboBox.Location = new System.Drawing.Point(86, 98);
            this.设备型号ComboBox.Name = "设备型号ComboBox";
            this.设备型号ComboBox.Size = new System.Drawing.Size(190, 20);
            this.设备型号ComboBox.TabIndex = 32;
            // 
            // 临床诊断ComboBox
            // 
            this.临床诊断ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "临床诊断", true));
            this.临床诊断ComboBox.FormattingEnabled = true;
            this.临床诊断ComboBox.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f"});
            this.临床诊断ComboBox.Location = new System.Drawing.Point(410, 20);
            this.临床诊断ComboBox.Name = "临床诊断ComboBox";
            this.临床诊断ComboBox.Size = new System.Drawing.Size(280, 20);
            this.临床诊断ComboBox.TabIndex = 34;
            // 
            // 病理诊断ComboBox
            // 
            this.病理诊断ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "病理诊断", true));
            this.病理诊断ComboBox.FormattingEnabled = true;
            this.病理诊断ComboBox.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f"});
            this.病理诊断ComboBox.Location = new System.Drawing.Point(410, 46);
            this.病理诊断ComboBox.Name = "病理诊断ComboBox";
            this.病理诊断ComboBox.Size = new System.Drawing.Size(280, 20);
            this.病理诊断ComboBox.TabIndex = 36;
            // 
            // 术后诊断ComboBox
            // 
            this.术后诊断ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "术后诊断", true));
            this.术后诊断ComboBox.FormattingEnabled = true;
            this.术后诊断ComboBox.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f"});
            this.术后诊断ComboBox.Location = new System.Drawing.Point(410, 72);
            this.术后诊断ComboBox.Name = "术后诊断ComboBox";
            this.术后诊断ComboBox.Size = new System.Drawing.Size(280, 20);
            this.术后诊断ComboBox.TabIndex = 38;
            // 
            // 诊断意见ComboBox
            // 
            this.诊断意见ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "诊断意见", true));
            this.诊断意见ComboBox.FormattingEnabled = true;
            this.诊断意见ComboBox.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f"});
            this.诊断意见ComboBox.Location = new System.Drawing.Point(410, 98);
            this.诊断意见ComboBox.Name = "诊断意见ComboBox";
            this.诊断意见ComboBox.Size = new System.Drawing.Size(280, 20);
            this.诊断意见ComboBox.TabIndex = 40;
            // 
            // 就诊时间TextBox
            // 
            this.就诊时间TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "就诊时间", true));
            this.就诊时间TextBox.Location = new System.Drawing.Point(410, 126);
            this.就诊时间TextBox.Name = "就诊时间TextBox";
            this.就诊时间TextBox.Size = new System.Drawing.Size(280, 21);
            this.就诊时间TextBox.TabIndex = 42;
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(617, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 23);
            this.button4.TabIndex = 46;
            this.button4.Text = "采集图像";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(617, 157);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 23);
            this.button3.TabIndex = 45;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(617, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(617, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(姓名Label);
            this.groupBox1.Controls.Add(this.姓名TextBox);
            this.groupBox1.Controls.Add(性别Label);
            this.groupBox1.Controls.Add(this.性别ComboBox);
            this.groupBox1.Controls.Add(年龄Label);
            this.groupBox1.Controls.Add(this.年龄TextBox);
            this.groupBox1.Controls.Add(工作单位Label);
            this.groupBox1.Controls.Add(this.工作单位TextBox);
            this.groupBox1.Controls.Add(联系电话Label);
            this.groupBox1.Controls.Add(this.联系电话TextBox);
            this.groupBox1.Controls.Add(联系地址Label);
            this.groupBox1.Controls.Add(this.联系地址TextBox);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 192);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病人信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(病历号Label);
            this.groupBox2.Controls.Add(this.病历号TextBox);
            this.groupBox2.Controls.Add(门诊号Label);
            this.groupBox2.Controls.Add(this.门诊号TextBox);
            this.groupBox2.Controls.Add(住院号Label);
            this.groupBox2.Controls.Add(this.住院号TextBox);
            this.groupBox2.Controls.Add(病区号Label);
            this.groupBox2.Controls.Add(this.病区号TextBox);
            this.groupBox2.Controls.Add(床位号Label);
            this.groupBox2.Controls.Add(this.床位号TextBox);
            this.groupBox2.Location = new System.Drawing.Point(357, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 191);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "病人编号";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(label1);
            this.groupBox3.Controls.Add(申请医师Label);
            this.groupBox3.Controls.Add(this.申请医师ComboBox);
            this.groupBox3.Controls.Add(检查医师Label);
            this.groupBox3.Controls.Add(this.检查医师ComboBox);
            this.groupBox3.Controls.Add(申请科室Label);
            this.groupBox3.Controls.Add(this.申请科室ComboBox);
            this.groupBox3.Controls.Add(就诊时间Label);
            this.groupBox3.Controls.Add(设备型号Label);
            this.groupBox3.Controls.Add(this.就诊时间TextBox);
            this.groupBox3.Controls.Add(this.设备型号ComboBox);
            this.groupBox3.Controls.Add(临床诊断Label);
            this.groupBox3.Controls.Add(this.临床诊断ComboBox);
            this.groupBox3.Controls.Add(病理诊断Label);
            this.groupBox3.Controls.Add(this.病理诊断ComboBox);
            this.groupBox3.Controls.Add(术后诊断Label);
            this.groupBox3.Controls.Add(this.术后诊断ComboBox);
            this.groupBox3.Controls.Add(诊断意见Label);
            this.groupBox3.Controls.Add(this.诊断意见ComboBox);
            this.groupBox3.Location = new System.Drawing.Point(23, 214);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(716, 167);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "就诊信息";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "HIV", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "无",
            "HP",
            "HIV",
            "HP & HIV"});
            this.comboBox1.Location = new System.Drawing.Point(86, 126);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(190, 20);
            this.comboBox1.TabIndex = 42;
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(617, 70);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(122, 23);
            this.button5.TabIndex = 50;
            this.button5.Text = "生成报表";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(617, 99);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(122, 23);
            this.button6.TabIndex = 51;
            this.button6.Text = "历史报表";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.infoTableAdapter = this.infoTableAdapter;
            this.tableAdapterManager.UpdateOrder = Case05_4.病历信息DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // 病历信息DataSet1
            // 
            this.病历信息DataSet1.DataSetName = "病历信息DataSet1";
            this.病历信息DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // doctorBindingSource
            // 
            this.doctorBindingSource.DataMember = "doctor";
            this.doctorBindingSource.DataSource = this.病历信息DataSet1;
            // 
            // doctorTableAdapter
            // 
            this.doctorTableAdapter.ClearBeforeFill = true;
            // 
            // Form3
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.button3;
            this.ClientSize = new System.Drawing.Size(760, 410);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Shown += new System.EventHandler(this.Form3_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.病历信息DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.病历信息DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doctorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private 病历信息DataSet 病历信息DataSet;
        private System.Windows.Forms.BindingSource infoBindingSource;
        private 病历信息DataSetTableAdapters.infoTableAdapter infoTableAdapter;
        private System.Windows.Forms.TextBox 姓名TextBox;
        private System.Windows.Forms.ComboBox 性别ComboBox;
        private System.Windows.Forms.TextBox 年龄TextBox;
        private System.Windows.Forms.TextBox 工作单位TextBox;
        private System.Windows.Forms.TextBox 联系电话TextBox;
        private System.Windows.Forms.TextBox 联系地址TextBox;
        private System.Windows.Forms.TextBox 病历号TextBox;
        private System.Windows.Forms.TextBox 门诊号TextBox;
        private System.Windows.Forms.TextBox 住院号TextBox;
        private System.Windows.Forms.TextBox 病区号TextBox;
        private System.Windows.Forms.TextBox 床位号TextBox;
        private System.Windows.Forms.ComboBox 申请医师ComboBox;
        private System.Windows.Forms.ComboBox 检查医师ComboBox;
        private System.Windows.Forms.ComboBox 申请科室ComboBox;
        private System.Windows.Forms.ComboBox 设备型号ComboBox;
        private System.Windows.Forms.ComboBox 临床诊断ComboBox;
        private System.Windows.Forms.ComboBox 病理诊断ComboBox;
        private System.Windows.Forms.ComboBox 术后诊断ComboBox;
        private System.Windows.Forms.ComboBox 诊断意见ComboBox;
        private System.Windows.Forms.TextBox 就诊时间TextBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private 病历信息DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private 病历信息DataSet1 病历信息DataSet1;
        private System.Windows.Forms.BindingSource doctorBindingSource;
        private 病历信息DataSet1TableAdapters.doctorTableAdapter doctorTableAdapter;

    }
}