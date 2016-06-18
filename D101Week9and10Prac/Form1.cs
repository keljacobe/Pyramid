using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace D101Week9and10Prac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawPyramid(Pyramid newPyramid)
        {
            pbxTop.Height = newPyramid.TopHeight;
            pbxTop.Width = newPyramid.TopWidth;
            pbxTop.BackColor = newPyramid.TopColour;

            pbxMiddle.Height = newPyramid.MidHeight;
            pbxMiddle.Width = newPyramid.MidWidth;
            pbxMiddle.BackColor = newPyramid.MidColour;

            pbxBottom.Height = newPyramid.BtmHeight;
            pbxBottom.Width = newPyramid.BtmWidth;
            pbxBottom.BackColor = newPyramid.BtmColour;

            int horizontalPanel = pnlPyramid.Width / 2;
            int horizontalTopBox = pbxTop.Width / 2;
            int xLocTop = horizontalPanel - horizontalTopBox;
            pbxTop.Left = xLocTop;

            int horizontalMidBox = pbxMiddle.Width / 2;
            int xLocMid = horizontalPanel - horizontalMidBox;
            pbxMiddle.Left = xLocMid;

            int horizontalBtmBox = pbxBottom.Width / 2;
            int xLocBtm = horizontalPanel - horizontalBtmBox;
            pbxBottom.Left = xLocBtm;

            int pyramidHeight = pbxTop.Height + pbxMiddle.Height + pbxBottom.Height;
            int panelHeight = pnlPyramid.Height - pyramidHeight;
            int halfPanel = panelHeight / 2;

            pbxTop.Top = halfPanel;
            pbxMiddle.Top = halfPanel + pbxTop.Height;
            pbxBottom.Top = halfPanel + pbxTop.Height + pbxMiddle.Height;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Pyramid myPyramid = new Pyramid();
            myPyramid.TopHeight = int.Parse(tbxTopHeight.Text);
            myPyramid.TopWidth = int.Parse(tbxTopWidth.Text);
            myPyramid.TopColour = Color.FromName(cbxTopColour.Text);

            myPyramid.MidHeight = int.Parse(tbxMidHeight.Text);
            myPyramid.MidWidth = int.Parse(tbxMidWidth.Text);
            myPyramid.MidColour = Color.FromName(cbxMidColour.Text);

            myPyramid.BtmHeight = int.Parse(tbxBtmHeight.Text);
            myPyramid.BtmWidth = int.Parse(tbxBtmWidth.Text);
            myPyramid.BtmColour = Color.FromName(cbxBtmColour.Text);

            DrawPyramid(myPyramid);
        }

        private void SavePyramid(Pyramid newPyramid)
        {
            StreamWriter sw = new StreamWriter("Presets.txt", true);
            sw.WriteLine(newPyramid.MyName + "," + newPyramid.TopHeight + "," + newPyramid.TopWidth + "," + newPyramid.TopColour.ToKnownColor() + "," +
                        newPyramid.MidHeight + "," + newPyramid.MidWidth + "," + newPyramid.MidColour.ToKnownColor() + "," +
                        newPyramid.BtmHeight + "," + newPyramid.BtmWidth + "," + newPyramid.BtmColour.ToKnownColor());
            sw.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Pyramid myPyramid = new Pyramid();
            myPyramid.MyName = tbxName.Text;
            myPyramid.TopHeight = int.Parse(tbxTopHeight.Text);
            myPyramid.TopWidth = int.Parse(tbxTopWidth.Text);
            myPyramid.TopColour = Color.FromName(cbxTopColour.Text);

            myPyramid.MidHeight = int.Parse(tbxMidHeight.Text);
            myPyramid.MidWidth = int.Parse(tbxMidWidth.Text);
            myPyramid.MidColour = Color.FromName(cbxMidColour.Text);

            myPyramid.BtmHeight = int.Parse(tbxBtmHeight.Text);
            myPyramid.BtmWidth = int.Parse(tbxBtmWidth.Text);
            myPyramid.BtmColour = Color.FromName(cbxBtmColour.Text);

            SavePyramid(myPyramid);
        }

        private void LoadPyramidPresets()
        {
            StreamReader sr = new StreamReader("Presets.txt");

            while (!sr.EndOfStream)
            {
                Pyramid myPyramid = new Pyramid();
                string pyramidPreset = sr.ReadLine();
                string[] parameters = pyramidPreset.Split(',');

                myPyramid.MyName = parameters[0];
                myPyramid.TopHeight = int.Parse(parameters[1]);
                myPyramid.TopWidth = int.Parse(parameters[2]);
                myPyramid.TopColour = Color.FromName(parameters[3]);

                myPyramid.MidHeight = int.Parse(parameters[4]);
                myPyramid.MidWidth = int.Parse(parameters[5]);
                myPyramid.MidColour = Color.FromName(parameters[6]);

                myPyramid.BtmHeight = int.Parse(parameters[7]);
                myPyramid.BtmWidth = int.Parse(parameters[8]);
                myPyramid.BtmColour = Color.FromName(parameters[9]);

                lbxPreset.Items.Add(myPyramid);
            }
            sr.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lbxPreset.Items.Clear();
            LoadPyramidPresets();
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            Pyramid myPyramid = (Pyramid)lbxPreset.SelectedItem;

            DrawPyramid(myPyramid);

            tbxName.Text = myPyramid.MyName;

            tbxTopHeight.Text = myPyramid.TopHeight.ToString();
            tbxTopWidth.Text = myPyramid.TopWidth.ToString();
            cbxTopColour.Text = myPyramid.TopColour.ToString();
          
            tbxMidHeight.Text = myPyramid.MidHeight.ToString();
            tbxMidWidth.Text = myPyramid.MidWidth.ToString();
            cbxMidColour.Text = myPyramid.MidColour.ToString();

            tbxBtmHeight.Text = myPyramid.BtmHeight.ToString();
            tbxBtmWidth.Text = myPyramid.BtmWidth.ToString();
            cbxBtmColour.Text = myPyramid.BtmColour.ToString();
        }
    }
}
