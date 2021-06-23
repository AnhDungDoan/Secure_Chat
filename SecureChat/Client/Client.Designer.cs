
namespace Client
{
    partial class Client
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.YourName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.prKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TextBox_P = new System.Windows.Forms.TextBox();
            this.TextBox_G = new System.Windows.Forms.TextBox();
            this.Lock_Button = new System.Windows.Forms.Button();
            this.Random_Button = new System.Windows.Forms.Button();
            this.Lock_Private_Key = new System.Windows.Forms.Button();
            this.Key_Label = new System.Windows.Forms.Label();
            this.Key_Box = new System.Windows.Forms.TextBox();
            this.listCipher = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 563);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(863, 29);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(881, 562);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "SEND";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 98);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(960, 459);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Your name:";
            // 
            // YourName
            // 
            this.YourName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YourName.Location = new System.Drawing.Point(109, 6);
            this.YourName.Name = "YourName";
            this.YourName.Size = new System.Drawing.Size(251, 26);
            this.YourName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(443, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cipher:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(444, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pr Key:";
            // 
            // prKey
            // 
            this.prKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prKey.Location = new System.Drawing.Point(508, 39);
            this.prKey.Name = "prKey";
            this.prKey.Size = new System.Drawing.Size(238, 26);
            this.prKey.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(183, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "G:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "P:";
            // 
            // TextBox_P
            // 
            this.TextBox_P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_P.Location = new System.Drawing.Point(36, 39);
            this.TextBox_P.Name = "TextBox_P";
            this.TextBox_P.Size = new System.Drawing.Size(141, 26);
            this.TextBox_P.TabIndex = 5;
            // 
            // TextBox_G
            // 
            this.TextBox_G.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_G.Location = new System.Drawing.Point(212, 39);
            this.TextBox_G.Name = "TextBox_G";
            this.TextBox_G.Size = new System.Drawing.Size(55, 26);
            this.TextBox_G.TabIndex = 5;
            // 
            // Lock_Button
            // 
            this.Lock_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lock_Button.Location = new System.Drawing.Point(294, 66);
            this.Lock_Button.Name = "Lock_Button";
            this.Lock_Button.Size = new System.Drawing.Size(100, 26);
            this.Lock_Button.TabIndex = 8;
            this.Lock_Button.Text = "LOCK";
            this.Lock_Button.UseVisualStyleBackColor = true;
            this.Lock_Button.Click += new System.EventHandler(this.LockButton_Click);
            // 
            // Random_Button
            // 
            this.Random_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Random_Button.Location = new System.Drawing.Point(294, 39);
            this.Random_Button.Name = "Random_Button";
            this.Random_Button.Size = new System.Drawing.Size(100, 26);
            this.Random_Button.TabIndex = 9;
            this.Random_Button.Text = "RANDOM";
            this.Random_Button.UseVisualStyleBackColor = true;
            this.Random_Button.Click += new System.EventHandler(this.Random_Button_Click);
            // 
            // Lock_Private_Key
            // 
            this.Lock_Private_Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lock_Private_Key.Location = new System.Drawing.Point(752, 39);
            this.Lock_Private_Key.Name = "Lock_Private_Key";
            this.Lock_Private_Key.Size = new System.Drawing.Size(91, 26);
            this.Lock_Private_Key.TabIndex = 10;
            this.Lock_Private_Key.Text = "LOCK PR";
            this.Lock_Private_Key.UseVisualStyleBackColor = true;
            this.Lock_Private_Key.Click += new System.EventHandler(this.Lock_Private_Key_Click);
            // 
            // Key_Label
            // 
            this.Key_Label.AutoSize = true;
            this.Key_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Key_Label.Location = new System.Drawing.Point(444, 69);
            this.Key_Label.Name = "Key_Label";
            this.Key_Label.Size = new System.Drawing.Size(39, 20);
            this.Key_Label.TabIndex = 4;
            this.Key_Label.Text = "Key:";
            // 
            // Key_Box
            // 
            this.Key_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Key_Box.Location = new System.Drawing.Point(508, 66);
            this.Key_Box.Name = "Key_Box";
            this.Key_Box.Size = new System.Drawing.Size(238, 26);
            this.Key_Box.TabIndex = 5;
            // 
            // listCipher
            // 
            this.listCipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCipher.FormattingEnabled = true;
            this.listCipher.Items.AddRange(new object[] {
            "",
            "3DES",
            "Caesar",
            "AES"});
            this.listCipher.Location = new System.Drawing.Point(508, 6);
            this.listCipher.Name = "listCipher";
            this.listCipher.Size = new System.Drawing.Size(121, 28);
            this.listCipher.TabIndex = 11;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 600);
            this.Controls.Add(this.listCipher);
            this.Controls.Add(this.Lock_Private_Key);
            this.Controls.Add(this.Random_Button);
            this.Controls.Add(this.Lock_Button);
            this.Controls.Add(this.TextBox_G);
            this.Controls.Add(this.TextBox_P);
            this.Controls.Add(this.Key_Box);
            this.Controls.Add(this.prKey);
            this.Controls.Add(this.YourName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Key_Label);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Client";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox YourName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox prKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TextBox_P;
        private System.Windows.Forms.TextBox TextBox_G;
        private System.Windows.Forms.Button Lock_Button;
        private System.Windows.Forms.Button Random_Button;
        private System.Windows.Forms.Button Lock_Private_Key;
        private System.Windows.Forms.Label Key_Label;
        private System.Windows.Forms.TextBox Key_Box;
        private System.Windows.Forms.ComboBox listCipher;
    }
}

