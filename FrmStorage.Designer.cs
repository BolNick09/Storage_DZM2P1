namespace InsUpdDel_DZM2P1
{
    partial class FrmStorage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rtbResult = new RichTextBox();
            cbbActions = new ComboBox();
            btnExecSql = new Button();
            btnConnect = new Button();
            btnDisconnect = new Button();
            lbl1 = new Label();
            tbParam = new TextBox();
            SuspendLayout();
            // 
            // rtbResult
            // 
            rtbResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbResult.Location = new Point(12, 85);
            rtbResult.Name = "rtbResult";
            rtbResult.Size = new Size(528, 353);
            rtbResult.TabIndex = 0;
            rtbResult.Text = "";
            // 
            // cbbActions
            // 
            cbbActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbbActions.FormattingEnabled = true;
            cbbActions.Items.AddRange(new object[] { "Отображение всей информации о товаре", "Отображение всех типов товаров", "Отображение всех поставщиков", "Показать товар с максимальным количеством", "Показать товар с минимальным количеством", "Показать товар с минимальной себестоимостью", "Показать товар с максимальной себестоимостью", "Показать товары, заданной категории", "Показать товары, заданного поставщика", "Показать самый старый товар на складе", "Показать среднее количество товаров по каждому типу товара" });
            cbbActions.Location = new Point(12, 12);
            cbbActions.Name = "cbbActions";
            cbbActions.Size = new Size(528, 28);
            cbbActions.TabIndex = 1;
            // 
            // btnExecSql
            // 
            btnExecSql.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExecSql.Location = new Point(556, 11);
            btnExecSql.Name = "btnExecSql";
            btnExecSql.Size = new Size(125, 29);
            btnExecSql.TabIndex = 2;
            btnExecSql.Text = "Выполнить";
            btnExecSql.UseVisualStyleBackColor = true;
            btnExecSql.Click += btnExecSql_Click;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConnect.Location = new Point(556, 46);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(125, 29);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Подключить";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDisconnect.Location = new Point(556, 81);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(125, 29);
            btnDisconnect.TabIndex = 4;
            btnDisconnect.Text = "Отключить";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(12, 50);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(99, 20);
            lbl1.TabIndex = 5;
            lbl1.Text = "Параметр Id:";
            // 
            // tbParam
            // 
            tbParam.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbParam.Location = new Point(117, 47);
            tbParam.Name = "tbParam";
            tbParam.Size = new Size(423, 27);
            tbParam.TabIndex = 6;
            // 
            // FrmStorage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 450);
            Controls.Add(tbParam);
            Controls.Add(lbl1);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(btnExecSql);
            Controls.Add(cbbActions);
            Controls.Add(rtbResult);
            Name = "FrmStorage";
            Text = "Склад";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbResult;
        private ComboBox cbbActions;
        private Button btnExecSql;
        private Button btnConnect;
        private Button btnDisconnect;
        private Label lbl1;
        private TextBox tbParam;
    }
}
