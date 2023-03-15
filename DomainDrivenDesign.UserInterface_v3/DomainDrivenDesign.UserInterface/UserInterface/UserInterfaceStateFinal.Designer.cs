
namespace DomainDrivenDesign.UserInterface
{
    partial class UserInterfaceStateFinal
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelGoodbye = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelGoodbye
            // 
            this.labelGoodbye.AutoSize = true;
            this.labelGoodbye.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelGoodbye.ForeColor = System.Drawing.Color.White;
            this.labelGoodbye.Location = new System.Drawing.Point(345, 331);
            this.labelGoodbye.Name = "labelGoodbye";
            this.labelGoodbye.Size = new System.Drawing.Size(111, 27);
            this.labelGoodbye.TabIndex = 0;
            this.labelGoodbye.Text = "Goodbye";
            // 
            // UserInterfaceStateFinish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.labelGoodbye);
            this.Name = "UserInterfaceStateFinish";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGoodbye;
    }
}
