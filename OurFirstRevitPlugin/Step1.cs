using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace OurFirstRevitPlugin
{
    public partial class Step1 : System.Windows.Forms.Form
    {
        Autodesk.Revit.DB.Document Doc;

        public static Step1 instance;
        public ComboBox cb1;
        public TextBox tb1;
        public TextBox tb2;
        public ListBox lb1;
        public ListBox lb2;

        Thread th;
        public Step1(Autodesk.Revit.DB.Document doc)
        {
            InitializeComponent();
            Doc = doc;
            instance = this;
            cb1 = comboBox1;
            tb1 = textBox1;
            tb2 = textBox2;
            lb1 = listBox1;
            lb2 = listBox2;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (lb1.Items.Contains("ELEMENT " + tb2.Text.ToString() + " Product BuildingElement " + tb1.Text.ToString() + " " + cb1.SelectedItem.ToString().Substring(cb1.SelectedItem.ToString().IndexOf("GUID") + 6)))
            {

            }
            else
            {
                lb1.Items.Add("ELEMENT " + tb2.Text.ToString() + " Product BuildingElement " + tb1.Text.ToString() + " " + cb1.SelectedItem.ToString().Substring(cb1.SelectedItem.ToString().IndexOf("GUID") + 6));
            }


            if (lb2.Items.Contains(tb2.Text.ToString() + " is a " + tb1.Text.ToString()))
            {

            }
            else
            {
                lb2.Items.Add(tb2.Text.ToString() + " is a " + tb1.Text.ToString());
            }

            SAElement sae = new SAElement();
            sae.level = "Product";
            sae.reference = tb2.Text.ToString();
            sae.typ = "BuildingElement";
            sae.arguments.Add(tb1.Text.ToString());
            sae.arguments.Add(cb1.SelectedItem.ToString().Substring(cb1.SelectedItem.ToString().IndexOf("GUID") + 6));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Step2 step2 = new Step2(Doc);
            Step3 step3 = new Step3(Doc);
           
            foreach (string item in lb1.Items)
            {
                if (Step2.instance.cb2.Items.Contains(item.Substring(8,item.Substring(8).IndexOf(" "))))
                {

                }
                else
                {
                    Step2.instance.cb2.Items.Add(item.Substring(8, item.Substring(8).IndexOf(" ")));
                }
            }

            foreach (string item in lb1.Items)
            {
                if (Step2.instance.cb3.Items.Contains(item.Substring(8, item.Substring(8).IndexOf(" "))))
                {

                }
                else
                {
                    Step2.instance.cb3.Items.Add(item.Substring(8, item.Substring(8).IndexOf(" ")));
                }
            }

            foreach (string el in lb1.Items)
            {
                if (Step3.instance.cb3.Items.Contains(el.Substring(8, el.Substring(8).IndexOf(" "))))
                {

                }
                else
                {
                    Step3.instance.cb3.Items.Add(el.Substring(8, el.Substring(8).IndexOf(" ")));
                }

                if (Step3.instance.cb4.Items.Contains(el.Substring(8, el.Substring(8).IndexOf(" "))))
                {

                }
                else
                {
                    Step3.instance.cb4.Items.Add(el.Substring(8, el.Substring(8).IndexOf(" ")));
                }
            }

            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void opennewform()
        {
            System.Windows.Forms.Application.Run(Step2.instance);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(idx);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Step1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
