using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foreman
{
    public partial class EditLabel : UserControl
    {
        private readonly ProductionGraphViewer myGraphViewer;
        private readonly LabelNodeController nodeController;
        private readonly ReadOnlyLabelNode nodeData;

        public EditLabel(ReadOnlyLabelNode node, ProductionGraphViewer graphViewer)
        {
            nodeData = node;
            nodeController = (LabelNodeController)graphViewer.Graph.RequestNodeController(node);
            myGraphViewer = graphViewer;

            InitializeComponent();

            txtLabelText.Text = nodeData.MyNode.LabelText;
            FontSize.Value = nodeData.MyNode.LabelSize;
            cbIsAutoSize.Checked = nodeData.MyNode.IsAutoSize;
            txtHeight.Text = nodeData.MyNode.LabelHeight.ToString();
            txtWidth.Text = nodeData.MyNode.LabelWidth.ToString();
        }

        private void txtLabelText_TextChanged(object sender, EventArgs e)
        {
            nodeController.SetLabelText(txtLabelText.Text);
        }

        private void FontSize_ValueChanged(object sender, EventArgs e)
        {
            nodeController.SetLabelSize((int)FontSize.Value);
        }

        private void cbIsAutoSize_CheckedChanged(object sender, EventArgs e)
        {
            nodeController.SetAutoSize(cbIsAutoSize.Checked);
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(txtHeight.Text);
                nodeController.SetHeight(i);
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }

        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(txtWidth.Text);
                nodeController.SetWidth(i);
            }
            catch(Exception ex)
            {
                Console.WriteLine (ex.Message);
            }
        }
    }
}
