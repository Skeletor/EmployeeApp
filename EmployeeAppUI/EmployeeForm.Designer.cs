
namespace EmployeeAppUI
{
    partial class EmployeeForm
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
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.middleNameTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.extraTextBox = new System.Windows.Forms.TextBox();
            this.dynamicLabel = new System.Windows.Forms.Label();
            this.employeeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.genderTypeComboBox = new System.Windows.Forms.ComboBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(12, 29);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(278, 22);
            this.firstNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Имя";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(12, 85);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(278, 22);
            this.lastNameTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Отчество";
            // 
            // middleNameTextBox
            // 
            this.middleNameTextBox.Location = new System.Drawing.Point(12, 143);
            this.middleNameTextBox.Name = "middleNameTextBox";
            this.middleNameTextBox.Size = new System.Drawing.Size(278, 22);
            this.middleNameTextBox.TabIndex = 4;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(96, 419);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(114, 22);
            this.dateTimePicker.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "День рождения";
            // 
            // extraTextBox
            // 
            this.extraTextBox.Location = new System.Drawing.Point(12, 209);
            this.extraTextBox.Name = "extraTextBox";
            this.extraTextBox.Size = new System.Drawing.Size(278, 22);
            this.extraTextBox.TabIndex = 8;
            // 
            // dynamicLabel
            // 
            this.dynamicLabel.AutoSize = true;
            this.dynamicLabel.Location = new System.Drawing.Point(12, 189);
            this.dynamicLabel.Name = "dynamicLabel";
            this.dynamicLabel.Size = new System.Drawing.Size(46, 17);
            this.dynamicLabel.TabIndex = 9;
            this.dynamicLabel.Text = "label5";
            // 
            // employeeTypeComboBox
            // 
            this.employeeTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeeTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.employeeTypeComboBox.FormattingEnabled = true;
            this.employeeTypeComboBox.Location = new System.Drawing.Point(12, 275);
            this.employeeTypeComboBox.Name = "employeeTypeComboBox";
            this.employeeTypeComboBox.Size = new System.Drawing.Size(278, 24);
            this.employeeTypeComboBox.TabIndex = 10;
            this.employeeTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.employeeTypeComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Тип работника";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Пол";
            // 
            // genderTypeComboBox
            // 
            this.genderTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genderTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.genderTypeComboBox.FormattingEnabled = true;
            this.genderTypeComboBox.Location = new System.Drawing.Point(12, 339);
            this.genderTypeComboBox.Name = "genderTypeComboBox";
            this.genderTypeComboBox.Size = new System.Drawing.Size(278, 24);
            this.genderTypeComboBox.TabIndex = 12;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(7, 475);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(138, 36);
            this.OKButton.TabIndex = 14;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(152, 475);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 36);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 521);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.genderTypeComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.employeeTypeComboBox);
            this.Controls.Add(this.dynamicLabel);
            this.Controls.Add(this.extraTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.middleNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.firstNameTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeForm";
            this.Text = "Сотрудник";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox middleNameTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox extraTextBox;
        private System.Windows.Forms.Label dynamicLabel;
        private System.Windows.Forms.ComboBox employeeTypeComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox genderTypeComboBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
    }
}