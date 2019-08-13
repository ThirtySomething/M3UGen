using System.Windows.Forms;

namespace net
{
    namespace derpaul
    {
        namespace utility
        {
                namespace m3ugen
                {
                    partial class objMainForm
                    {
                        /// <summary>
                        /// Designer variable used to keep track of non-visual components.
                        /// </summary>
                        private System.ComponentModel.IContainer components = null;

                        /// <summary>
                        /// Disposes resources used by the form.
                        /// </summary>
                        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
                        protected override void Dispose(bool disposing)
                        {
                            if (disposing)
                            {
                                if (components != null)
                                {
                                    components.Dispose();
                                }
                            }
                            base.Dispose(disposing);
                        }

                        /// <summary>
                        /// This method is required for Windows Forms designer support.
                        /// Do not change the method contents inside the source code editor. The Forms designer might
                        /// not be able to load this method if it was changed manually.
                        /// </summary>
                        private void InitializeComponent()
                        {
                            this.objTextBoxDirname = new System.Windows.Forms.TextBox();
                            this.objBtnDir = new System.Windows.Forms.Button();
                            this.objBtnStart = new System.Windows.Forms.Button();
                            this.objBtnExit = new System.Windows.Forms.Button();
                            this.objLblStatus = new System.Windows.Forms.Label();
                            this.SuspendLayout();
                            //
                            // objTextBoxDirname
                            //
                            this.objTextBoxDirname.Location = new System.Drawing.Point(12, 12);
                            this.objTextBoxDirname.Name = "objTextBoxDirname";
                            this.objTextBoxDirname.Size = new System.Drawing.Size(286, 20);
                            this.objTextBoxDirname.TabIndex = 0;
                            //
                            // objBtnDir
                            //
                            this.objBtnDir.Location = new System.Drawing.Point(303, 9);
                            this.objBtnDir.Name = "objBtnDir";
                            this.objBtnDir.Size = new System.Drawing.Size(75, 23);
                            this.objBtnDir.TabIndex = 1;
                            this.objBtnDir.Text = "Dir";
                            this.objBtnDir.UseVisualStyleBackColor = true;
                            this.objBtnDir.Click += new System.EventHandler(this.ObjBtnDirClick);
                            //
                            // objBtnStart
                            //
                            this.objBtnStart.Location = new System.Drawing.Point(12, 38);
                            this.objBtnStart.Name = "objBtnStart";
                            this.objBtnStart.Size = new System.Drawing.Size(176, 24);
                            this.objBtnStart.TabIndex = 2;
                            this.objBtnStart.Text = "Start";
                            this.objBtnStart.UseVisualStyleBackColor = true;
                            this.objBtnStart.Click += new System.EventHandler(this.ObjBtnStartClick);
                            //
                            // objBtnExit
                            //
                            this.objBtnExit.Location = new System.Drawing.Point(203, 38);
                            this.objBtnExit.Name = "objBtnExit";
                            this.objBtnExit.Size = new System.Drawing.Size(176, 24);
                            this.objBtnExit.TabIndex = 3;
                            this.objBtnExit.Text = "Exit";
                            this.objBtnExit.UseVisualStyleBackColor = true;
                            this.objBtnExit.Click += new System.EventHandler(this.ObjBtnExitClick);
                            //
                            // objLblStatus
                            //
                            this.objLblStatus.Location = new System.Drawing.Point(12, 71);
                            this.objLblStatus.Name = "objLblStatus";
                            this.objLblStatus.Size = new System.Drawing.Size(367, 22);
                            this.objLblStatus.TabIndex = 4;
                            this.objLblStatus.Text = "M3UGen (C) 2014 Jochen Paul";
                            this.objLblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            //
                            // objMainForm
                            //
                            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                            this.ClientSize = new System.Drawing.Size(390, 102);
                            this.Controls.Add(this.objLblStatus);
                            this.Controls.Add(this.objBtnExit);
                            this.Controls.Add(this.objBtnStart);
                            this.Controls.Add(this.objBtnDir);
                            this.Controls.Add(this.objTextBoxDirname);
                            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
                            this.Name = "objMainForm";
                            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
                            this.Text = "M3UGen";
                            this.ResumeLayout(false);
                            this.PerformLayout();
                        }

                        /// <summary>
                        /// Label at bottom with (C) info/status
                        /// </summary>
                        private System.Windows.Forms.Label objLblStatus;

                        /// <summary>
                        /// Exit button
                        /// </summary>
                        private System.Windows.Forms.Button objBtnExit;

                        /// <summary>
                        /// Button to start playlist generation
                        /// </summary>
                        private System.Windows.Forms.Button objBtnStart;

                        /// <summary>
                        /// Button to select base directory
                        /// </summary>
                        private System.Windows.Forms.Button objBtnDir;
                        private System.Windows.Forms.TextBox objTextBoxDirname;

                        /// <summary>
                        /// Onclick event of exit button - close application
                        /// </summary>
                        /// <param name="sender">object</param>
                        /// <param name="e">EventArgs</param>
                        void ObjBtnExitClick(object sender, System.EventArgs e)
                        {
                            Application.Exit();
                        }

                        /// <summary>
                        /// Onclick event of directory select button - open directory selection box
                        /// </summary>
                        /// <param name="sender">object</param>
                        /// <param name="e">EventArgs</param>
                        void ObjBtnDirClick(object sender, System.EventArgs e)
                        {
                            FolderBrowserDialog objDialog = new FolderBrowserDialog();
                            objDialog.Description = "Select MP3 directory";
                            objDialog.SelectedPath = @"C:\";
                            if (DialogResult.OK == objDialog.ShowDialog(this))
                            {
                                this.objTextBoxDirname.Text = objDialog.SelectedPath;
                            }
                        }

                        /// <summary>
                        /// Onclick event of start button - generate playlists
                        /// </summary>
                        /// <param name="sender">object</param>
                        /// <param name="e">EventArgs</param>
                        void ObjBtnStartClick(object sender, System.EventArgs e)
                        {
                            this.objLblStatus.Text = this.objM3UGen.generatePlaylists(this.objTextBoxDirname.Text, this.objMP3List);
                        }
                    }
                }
            }
        }
    }