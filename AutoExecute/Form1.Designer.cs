namespace AutoExecute
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonStartRecord = new System.Windows.Forms.Button();
            this.buttonEventCallback = new System.Windows.Forms.Button();
            this.labelPosTip = new System.Windows.Forms.Label();
            this.buttonStopRecord = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.buttonMessage = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示主窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonWindowCallback = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartRecord
            // 
            this.buttonStartRecord.Location = new System.Drawing.Point(10, 11);
            this.buttonStartRecord.Name = "buttonStartRecord";
            this.buttonStartRecord.Size = new System.Drawing.Size(75, 23);
            this.buttonStartRecord.TabIndex = 0;
            this.buttonStartRecord.Text = "开始记录";
            this.buttonStartRecord.UseVisualStyleBackColor = true;
            this.buttonStartRecord.Click += new System.EventHandler(this.buttonStartRecord_Click);
            // 
            // buttonEventCallback
            // 
            this.buttonEventCallback.Location = new System.Drawing.Point(92, 11);
            this.buttonEventCallback.Name = "buttonEventCallback";
            this.buttonEventCallback.Size = new System.Drawing.Size(75, 23);
            this.buttonEventCallback.TabIndex = 1;
            this.buttonEventCallback.Text = "事件回放";
            this.buttonEventCallback.UseVisualStyleBackColor = true;
            this.buttonEventCallback.Click += new System.EventHandler(this.buttonEventCallback_Click);
            // 
            // labelPosTip
            // 
            this.labelPosTip.AutoSize = true;
            this.labelPosTip.Location = new System.Drawing.Point(10, 67);
            this.labelPosTip.Name = "labelPosTip";
            this.labelPosTip.Size = new System.Drawing.Size(53, 12);
            this.labelPosTip.TabIndex = 2;
            this.labelPosTip.Text = "鼠标位置";
            // 
            // buttonStopRecord
            // 
            this.buttonStopRecord.Location = new System.Drawing.Point(10, 41);
            this.buttonStopRecord.Name = "buttonStopRecord";
            this.buttonStopRecord.Size = new System.Drawing.Size(75, 23);
            this.buttonStopRecord.TabIndex = 3;
            this.buttonStopRecord.Text = "停止记录";
            this.buttonStopRecord.UseVisualStyleBackColor = true;
            this.buttonStopRecord.Click += new System.EventHandler(this.buttonStopRecord_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(10, 83);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(157, 159);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(174, 83);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(169, 159);
            this.listView2.TabIndex = 5;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            // 
            // buttonMessage
            // 
            this.buttonMessage.Location = new System.Drawing.Point(173, 12);
            this.buttonMessage.Name = "buttonMessage";
            this.buttonMessage.Size = new System.Drawing.Size(75, 23);
            this.buttonMessage.TabIndex = 6;
            this.buttonMessage.Text = "消息调用";
            this.buttonMessage.UseVisualStyleBackColor = true;
            this.buttonMessage.Click += new System.EventHandler(this.buttonMessage_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示主窗体ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            // 
            // 显示主窗体ToolStripMenuItem
            // 
            this.显示主窗体ToolStripMenuItem.Name = "显示主窗体ToolStripMenuItem";
            this.显示主窗体ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.显示主窗体ToolStripMenuItem.Text = "显示主窗体";
            this.显示主窗体ToolStripMenuItem.Click += new System.EventHandler(this.显示主窗体ToolStripMenuItem_Click);
            // 
            // buttonWindowCallback
            // 
            this.buttonWindowCallback.Location = new System.Drawing.Point(92, 40);
            this.buttonWindowCallback.Name = "buttonWindowCallback";
            this.buttonWindowCallback.Size = new System.Drawing.Size(75, 23);
            this.buttonWindowCallback.TabIndex = 8;
            this.buttonWindowCallback.Text = "窗口回放";
            this.buttonWindowCallback.UseVisualStyleBackColor = true;
            this.buttonWindowCallback.Click += new System.EventHandler(this.buttonWindowCallback_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 249);
            this.Controls.Add(this.buttonWindowCallback);
            this.Controls.Add(this.buttonMessage);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonStopRecord);
            this.Controls.Add(this.labelPosTip);
            this.Controls.Add(this.buttonEventCallback);
            this.Controls.Add(this.buttonStartRecord);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "AutoExcute";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartRecord;
        private System.Windows.Forms.Button buttonEventCallback;
        private System.Windows.Forms.Label labelPosTip;
        private System.Windows.Forms.Button buttonStopRecord;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button buttonMessage;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示主窗体ToolStripMenuItem;
        private System.Windows.Forms.Button buttonWindowCallback;
    }
}

