using HataRabo.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HataRabo.UIGadget.Forms
{
    public partial class FormBase : Form
    {
        private readonly int CaptionSize;

        private bool controlBox = true;
        private int frameSize = 8;
        private Color frameColor = Color.Gray;
        private Font titleFont = new Font("Meiryo UI", 11.25f);
        private string text = string.Empty;

        public new bool ControlBox
        {
            get
            {
                return this.controlBox;
            }
            set
            {
                if (this.controlBox == value )
                {
                    return;
                }

                this.closeButton.Visible = value;

                this.controlBox = value;
                this.ChangePadding();
                this.Invalidate();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new FormBorderStyle FormBorderStyle
        {
            get
            {
                return base.FormBorderStyle;
            }
            set
            {
                base.FormBorderStyle = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }

        public override bool AutoScroll
        {
            get
            {
                return this.clientAreaPanel.AutoScroll;
            }
            set
            {
                this.clientAreaPanel.AutoScroll = value;
            }
        }

        /// <summary>
        /// フレームサイズ
        /// </summary>
        [Category("Custom")]
        [DefaultValue(8)]
        public int FrameSize
        {
            get
            {
                return this.frameSize;
            }
            set
            {
                this.frameSize = value;
                this.ChangePadding();
                this.Invalidate();
            }
        }

        /// <summary>
        /// フレームの色
        /// </summary>
        [Category("Custom")]
        [DefaultValue(typeof(Color), "Gray")]
        public Color FrameColor
        {
            get
            {
                return this.frameColor;
            }
            set
            {
                this.frameColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// タイトルのフォント
        /// </summary>
        [Category("Custom")]
        [DefaultValue(typeof(Font), "Meiryo UI, 11.25pt")]
        public Font TitleFont
        {
            get
            {
                return this.titleFont;
            }
            set
            {
                this.titleFont = value;
                this.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "White")]
        public override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        public override string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                this.Invalidate();
            }
        }

        #region private Property

        private int LeftFrameSize
        {
            get
            {
                var result = this.Padding.Left;

                if (FormWindowState.Maximized == this.WindowState)
                {
                    result = 0;
                }

                return result;
            }
        }

        private int TopFrameSize
        {
            get
            {
                var result = this.ControlBox ? FrameSize : this.Padding.Top;

                if (FormWindowState.Maximized == this.WindowState)
                {
                    result = 0;
                }

                return result;
            }
        }

        private int RightFrameSize
        {
            get
            {
                var result = this.Padding.Right;

                if (FormWindowState.Maximized == this.WindowState)
                {
                    result = 0;
                }

                return result;
            }
        }

        private int BottomFrameSize
        {
            get
            {
                var result = this.Padding.Bottom;

                if (FormWindowState.Maximized == this.WindowState)
                {
                    result = 0;
                }

                return result;
            }
        }

        private Point LeftTopLocation
        {
            get
            {
                return this.ClientRectangle.Location;
            }
        }

        private Point LeftBottomLocation
        {
            get
            {
                var clientRect = this.ClientRectangle;
                return new Point(clientRect.Left, clientRect.Bottom - this.BottomFrameSize);
            }
        }

        private Point RightBottomLocation
        {
            get
            {
                return new Point(this.RightTopLocation.X, this.LeftBottomLocation.Y);
            }
        }

        private Point RightTopLocation
        {
            get
            {
                var clientRect = this.ClientRectangle;
                return new Point(clientRect.Right - this.RightFrameSize, clientRect.Top);
            }
        }

        private Rectangle LeftTopFrameRectangle
        {
            get
            {
                var size = new Size(this.LeftFrameSize, this.TopFrameSize);
                return new Rectangle(this.LeftTopLocation, size);
            }
        }

        private Rectangle LeftBottomFrameRectangle
        {
            get
            {
                var size = new Size(this.LeftFrameSize, this.BottomFrameSize);
                return new Rectangle(this.LeftBottomLocation, size);
            }
        }

        private Rectangle RightBottomFrameRectangle
        {
            get
            {
                var size = new Size(this.RightFrameSize, this.BottomFrameSize);
                return new Rectangle(this.RightBottomLocation, size);
            }
        }

        private Rectangle RightTopFrameRectangle
        {
            get
            {
                var size = new Size(this.RightFrameSize, this.TopFrameSize);
                return new Rectangle(this.RightTopLocation, size);
            }
        }

        private Rectangle LeftFrameRectangle
        {
            get
            {
                var clientRect = this.ClientRectangle;
                var width = this.LeftFrameSize;
                var height = clientRect.Height;

                return new Rectangle(clientRect.Left, clientRect.Top, width, height);
            }
        }

        private Rectangle TopFrameRectangle
        {
            get
            {
                var clientRect = this.ClientRectangle;
                var width = clientRect.Width;
                var height = this.TopFrameSize;

                return new Rectangle(clientRect.Left, clientRect.Top, width, height);
            }
        }

        private Rectangle RightFrameRectangle
        {
            get
            {
                var clientRect = this.ClientRectangle;
                var width = this.RightFrameSize;
                var height = clientRect.Height;

                return new Rectangle(clientRect.Right - this.RightFrameSize, clientRect.Top, width, height);
            }
        }

        private Rectangle BottomFrameRectangle
        {
            get
            {
                var clientRect = this.ClientRectangle;
                var width = clientRect.Width;
                var height = this.BottomFrameSize;

                return new Rectangle(clientRect.Left, clientRect.Bottom - this.BottomFrameSize, width, height);
            }
        }

        private Rectangle IconRectangle
        {
            get
            {
                var width = this.Icon.Width;
                var height = this.Icon.Height;

                if (!this.ControlBox)
                {
                    height = 0;
                }

                return new Rectangle(this.FrameSize, this.FrameSize, width, height);
            }
        }
        private Rectangle CaptionRectangle
        {
            get
            {
                var clientRect = this.ClientRectangle;
                var width = clientRect.Width;
                var height = this.CaptionSize;

                if (!this.ControlBox)
                {
                    height = 0;
                }

                return new Rectangle(this.FrameSize, this.FrameSize, width, height);
            }
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormBase()
        {
            InitializeComponent();
            //base.ControlBox = false;
            base.Padding = new Padding(FrameSize);
            base.BackColor = Color.White;
            this.CaptionSize = this.Icon.Height;
            this.ChangePadding();
        }

        /// <summary>
        /// Paddingの更新
        /// </summary>
        private void ChangePadding()
        {
            var left = this.FrameSize;
            var top = this.FrameSize;
            var right = this.FrameSize;
            var bottom = this.FrameSize;

            if (this.ControlBox is true)
            {
                top += this.CaptionSize;
            }

            this.Padding = new Padding(left, top, right, bottom);
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;

            using (var brush = new SolidBrush(this.FrameColor))
            {
                g.FillRectangle(brush, this.LeftFrameRectangle);
                g.FillRectangle(brush, this.TopFrameRectangle);
                g.FillRectangle(brush, this.RightFrameRectangle);
                g.FillRectangle(brush, this.BottomFrameRectangle);
                g.FillRectangle(brush, this.CaptionRectangle);
            }

            if (this.ControlBox)
            {
                g.DrawIcon(this.Icon, this.IconRectangle);

                var measureSize = TextRenderer.MeasureText(this.Text, this.TitleFont);
                var titleLeft = this.IconRectangle.Right + 5;
                var titleTop = (this.Padding.Top - measureSize.Height) / 2;

                TextRenderer.DrawText(g, this.Text, this.TitleFont, new Point(titleLeft, titleTop), this.ForeColor);
            }
        }

        protected override void SetClientSizeCore(int x, int y)
        {
            // memo
            // SetClientSizeCore()をオーバーライドしないと
            // 派生クラスをデザイナで表示する毎に、Sizeが非クライアント領域のサイズ分大きくなる
            base.OnClientSizeChanged(EventArgs.Empty);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            // memo
            // 閉じるボタンの位置を動的に調整している
            // （閉じるボタンについては、時間の都合で手抜きです、すいません）
            var left = this.Width - this.Padding.Right - this.closeButton.Width;
            var top = this.Padding.Top - this.closeButton.Height;
            this.closeButton.Location = new Point(left, top);
        }

        protected override void WndProc(ref Message m)
        {
            // memo
            // 非クライアント領域のサイズ変更は無視
            const int WM_NCCALCSIZE = 0x0083;

            if (m.Msg == WM_NCCALCSIZE)
            {
                m.Result = new IntPtr(0);
                return;
            }

            const int WM_ACTIVATE = 0x0006;
            const int WM_NCACTIVATE = 0x0086;
            const int WM_NCPAINT = 0x0085;

            base.WndProc(ref m);

            if (m.Msg == WM_ACTIVATE
                || m.Msg == WM_NCACTIVATE
                || m.Msg == WM_NCPAINT)
            {
                this.Invalidate();
            }

            const int WM_NCHITTEST = 0x0084;

            if (m.Msg != WM_NCHITTEST)
            {
                return;
            }

            var x = NativeMethod.LoWord(m.LParam.ToInt32());
            var y = NativeMethod.HiWord(m.LParam.ToInt32());

            var hitPoint = new Point(x, y);
            var clientPoint = this.PointToClient(hitPoint);
            var clientRect = this.ClientRectangle;

            if (!clientRect.Contains(clientPoint))
            {
                return;
            }

            var map = new System.Collections.Specialized.OrderedDictionary()
            {
                { this.LeftTopFrameRectangle, NativeMethod.NcHitTest.TopLeft },
                { this.LeftBottomFrameRectangle, NativeMethod.NcHitTest.BottomLeft },
                { this.RightBottomFrameRectangle, NativeMethod.NcHitTest.BottomRight },
                { this.RightTopFrameRectangle, NativeMethod.NcHitTest.TopRight },
                { this.LeftFrameRectangle, NativeMethod.NcHitTest.Left },
                { this.RightFrameRectangle, NativeMethod.NcHitTest.Right },
                { this.TopFrameRectangle, NativeMethod.NcHitTest.Top },
                { this.BottomFrameRectangle, NativeMethod.NcHitTest.Bottom },
                { this.IconRectangle, NativeMethod.NcHitTest.SysMenu },
                { this.CaptionRectangle, NativeMethod.NcHitTest.Caption },
                { this.ClientRectangle, NativeMethod.NcHitTest.Client }
            };

            foreach (DictionaryEntry item in map)
            {
                var rect = (Rectangle)item.Key;
                var hitType = (NativeMethod.NcHitTest)item.Value;

                if (rect.Contains(clientPoint))
                {
                    m.Result = (IntPtr)hitType;
                    break;
                }
            }
        }

        /// <summary>
        /// 閉じるボタン＿クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
