namespace ProZad
{
    partial class Form1
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
            this.tGravity = new System.Windows.Forms.Timer(this.components);
            this.tMove = new System.Windows.Forms.Timer(this.components);
            this.tAnimator = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pbGround = new System.Windows.Forms.PictureBox();
            this.pbGround2 = new System.Windows.Forms.PictureBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGround2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // tGravity
            // 
            this.tGravity.Enabled = true;
            this.tGravity.Interval = 2;
            this.tGravity.Tick += new System.EventHandler(this.tGravity_Tick);
            // 
            // tMove
            // 
            this.tMove.Enabled = true;
            this.tMove.Interval = 10;
            this.tMove.Tick += new System.EventHandler(this.tMove_Tick);
            // 
            // tAnimator
            // 
            this.tAnimator.Enabled = true;
            this.tAnimator.Interval = 40;
            this.tAnimator.Tick += new System.EventHandler(this.tAnimator_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // pbGround
            // 
            this.pbGround.BackgroundImage = global::ProZad.Properties.Resources.Grass5;
            this.pbGround.Location = new System.Drawing.Point(12, 527);
            this.pbGround.Name = "pbGround";
            this.pbGround.Size = new System.Drawing.Size(578, 66);
            this.pbGround.TabIndex = 0;
            this.pbGround.TabStop = false;
            this.pbGround.Tag = "ground";
            // 
            // pbGround2
            // 
            this.pbGround2.BackgroundImage = global::ProZad.Properties.Resources.Grass5;
            this.pbGround2.Location = new System.Drawing.Point(682, 475);
            this.pbGround2.Name = "pbGround2";
            this.pbGround2.Size = new System.Drawing.Size(578, 65);
            this.pbGround2.TabIndex = 2;
            this.pbGround2.TabStop = false;
            this.pbGround2.Tag = "ground";
            // 
            // pbPlayer
            // 
            this.pbPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayer.Image = global::ProZad.Properties.Resources.characterIdle1R;
            this.pbPlayer.Location = new System.Drawing.Point(178, 315);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(108, 81);
            this.pbPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlayer.TabIndex = 1;
            this.pbPlayer.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1384, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbGround);
            this.Controls.Add(this.pbGround2);
            this.Controls.Add(this.pbPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGround2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGround;
        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.Timer tGravity;
        private System.Windows.Forms.PictureBox pbGround2;
        private System.Windows.Forms.Timer tMove;
        private System.Windows.Forms.Timer tAnimator;
        private System.Windows.Forms.Label label1;
    }
}

