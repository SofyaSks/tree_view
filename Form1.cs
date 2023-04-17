using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tree_view
{
    public partial class Form1 : Form
    {
        TreeView tree;
        ImageList galary; // сохраняет память, но работает только для независимых окон
        ListBox lb;
        public Form1()
        {
            InitializeComponent();
            this.SetBounds(300, 300, 600, 500);
            tree = new TreeView();
            Controls.Add(tree);
            tree.SetBounds(300, 30, 300, 400);
            TreeNode n1 = new TreeNode("Root node 1");
            TreeNode n2 = new TreeNode("Image 2", 0, 1);
            tree.Nodes.Add(n1);
            try
            {
                galary = new ImageList();
                tree.ImageList = galary;
                galary.ImageSize = new Size(65, 65);
                galary.ColorDepth = ColorDepth.Depth24Bit;
                Bitmap bmp = new Bitmap("../../1.jpg");
                galary.Images.Add(bmp);
                bmp = new Bitmap("../../2.jpg");
                galary.Images.Add(bmp);
                bmp = new Bitmap("../../3.jpg");
                galary.Images.Add(bmp);
                bmp = new Bitmap("../../4.jpg");
                galary.Images.Add(bmp);
                n1 = new TreeNode("Image 1", 1, 2); // первый индекс - картинка которую видишь, второй - на какую поменяется
                tree.Nodes.Add(n1);
                n1.Nodes.Add(new TreeNode("Image 2", 3, 2));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            tree.DoubleClick += new EventHandler(tree_DoubleClick);
            lb = new ListBox();
            lb.SetBounds(20, 200, 250, 300);
            Controls.Add(lb);
            all_list(tree.Nodes,"");


            //TreeNode n2 = new TreeNode("Root node 2");
           // tree.Nodes.Add(n2);
        }

        private void tree_DoubleClick(object sender, EventArgs e)
        {
            TreeView tr = (TreeView)sender;
            tree.Nodes.Remove(tree.SelectedNode);
        }

        private void all_list(TreeNodeCollection nodes, string v)
        {
            foreach(TreeNode item in nodes)
            {
                lb.Items.Add(v + item.Text);
                if (item.Nodes.Count > 0)
                    all_list(item.Nodes, v + item.Text + " : ");
            }
        }
    }
}
