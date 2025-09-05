using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurFirstRevitPlugin
{
    public partial class Step2 : System.Windows.Forms.Form
    {
        Autodesk.Revit.DB.Document Doc;

        public static Step2 instance;
        public ComboBox cb1;
        public ComboBox cb2;
        public ComboBox cb3;
        public ListBox lb1;
        public ListBox lb2;


        Thread th;
        public Step2(Autodesk.Revit.DB.Document doc)
        {
            InitializeComponent();
            Doc = doc;
            instance = this;
            cb1 = comboBox1;
            cb2 = comboBox2;
            cb3 = comboBox3;
            lb1 = listBox1;
            lb2 = listBox2;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (lb1.Items.Contains("RELATION " + cb1.SelectedItem.ToString() + " " + cb2.SelectedItem.ToString() + " " + cb3.SelectedItem.ToString()))
            {

            }
            else
            {
                lb1.Items.Add("RELATION " + cb1.SelectedItem.ToString() + " " + cb2.SelectedItem.ToString() + " " + cb3.SelectedItem.ToString());
            }

            if (lb2.Items.Contains(cb2.SelectedItem.ToString() + " is " + cb1.SelectedItem.ToString() + " " + cb3.SelectedItem.ToString()))
            {

            }
            else
            {
                lb2.Items.Add(cb2.SelectedItem.ToString() + " is " + cb1.SelectedItem.ToString() + " " + cb3.SelectedItem.ToString());
            }


            SARelation sar = new SARelation();
            sar.level = "Product";
            sar.reference = cb1.SelectedItem.ToString();
            sar.arguments.Add(cb2.SelectedItem.ToString());
            sar.arguments.Add(cb3.SelectedItem.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start(); 
        }
        private void opennewform()
        {
            System.Windows.Forms.Application.Run(Step3.instance);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int idx = lb1.SelectedIndex;
            lb1.Items.RemoveAt(idx);
        }

    }
}
