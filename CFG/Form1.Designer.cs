namespace CFG
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.load_data = new System.Windows.Forms.Button();
            this.save_data = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.transform = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // load_data
            // 
            this.load_data.Location = new System.Drawing.Point(13, 13);
            this.load_data.Name = "load_data";
            this.load_data.Size = new System.Drawing.Size(138, 47);
            this.load_data.TabIndex = 0;
            this.load_data.Text = "Загрузить грамматику";
            this.load_data.UseVisualStyleBackColor = true;
            this.load_data.Click += new System.EventHandler(this.load_data_Click);
            // 
            // save_data
            // 
            this.save_data.Location = new System.Drawing.Point(301, 12);
            this.save_data.Name = "save_data";
            this.save_data.Size = new System.Drawing.Size(138, 47);
            this.save_data.TabIndex = 1;
            this.save_data.Text = "Выгрузить грмматику";
            this.save_data.UseVisualStyleBackColor = true;
            this.save_data.Click += new System.EventHandler(this.save_data_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 2;
            // 
            // transform
            // 
            this.transform.Location = new System.Drawing.Point(157, 13);
            this.transform.Name = "transform";
            this.transform.Size = new System.Drawing.Size(138, 47);
            this.transform.TabIndex = 3;
            this.transform.Text = "Преобразовать";
            this.transform.UseVisualStyleBackColor = true;
            this.transform.Click += new System.EventHandler(this.transform_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 114);
            this.Controls.Add(this.transform);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save_data);
            this.Controls.Add(this.load_data);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button load_data;
        private System.Windows.Forms.Button save_data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button transform;
    }
}

