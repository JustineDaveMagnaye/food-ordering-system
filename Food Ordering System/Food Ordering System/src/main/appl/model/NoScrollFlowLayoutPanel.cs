using System.Windows.Forms;

public class NoScrollFlowLayoutPanel : FlowLayoutPanel
{
    protected override void OnScroll(ScrollEventArgs se)
    {
        // Suppress the scrollbars but keep scrolling functionality
        this.HorizontalScroll.Visible = false;
        this.VerticalScroll.Visible = false;
        base.OnScroll(se);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Ensure scrollbars remain hidden during painting
        this.HorizontalScroll.Visible = false;
        this.VerticalScroll.Visible = false;
        base.OnPaint(e);
    }
}
