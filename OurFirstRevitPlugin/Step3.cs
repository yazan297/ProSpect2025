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
    public partial class Step3 : System.Windows.Forms.Form
    {
        Autodesk.Revit.DB.Document Doc;

        public static Step3 instance;

        public ComboBox cb1;
        public ComboBox cb2;
        public ComboBox cb3;
        public ComboBox cb4;
        public ComboBox cb5;
        public ComboBox cb6;
        public ComboBox cb7;
        public ListBox lb1;
        public ListBox lb2;
        public TextBox tb1;
        public TextBox tb2;
        public TextBox tb3;

        Thread th;
        public Step3(Autodesk.Revit.DB.Document doc)
        {
            InitializeComponent();
            Doc = doc;
            instance = this;
            cb1 = comboBox1;
            cb2 = comboBox2;
            cb3 = comboBox3;
            cb4 = comboBox4;
            cb5 = comboBox5;
            cb6 = comboBox6;
            cb7 = comboBox7;
            lb1 = listBox1;
            lb2 = listBox2;
            tb1 = textBox1;
            tb2 = textBox2;
            tb3 = textBox3;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (lb1.Items.Contains("ELEMENT " + tb2.Text.ToString() + " Domain " + cb2.SelectedItem.ToString() + " " + cb3.SelectedItem.ToString() + " " + cb4.SelectedItem.ToString()))
            {

            }
            else
            {
                lb1.Items.Add("ELEMENT " + tb2.Text.ToString() + " Domain " + cb2.SelectedItem.ToString() + " " + cb3.SelectedItem.ToString() + " " + cb4.SelectedItem.ToString());
            }

            if (lb2.Items.Contains(tb2.Text.ToString() + " is a " + cb2.SelectedItem.ToString() + " of " + cb3.SelectedItem.ToString() + " with respect to " + cb4.SelectedItem.ToString()))
            {

            }
            else
            {
                lb2.Items.Add(tb2.Text.ToString() + " is a " + cb2.SelectedItem.ToString() + " of " + cb3.SelectedItem.ToString() + " with respect to " + cb4.SelectedItem.ToString());
            }


            if (cb6.Items.Contains(tb2.Text.ToString()))
            {

            }
            else
            {
                cb6.Items.Add(tb2.Text.ToString());
            }

            if (cb7.Items.Contains(tb2.Text.ToString()))
            {

            }
            else
            {
                cb7.Items.Add(tb2.Text.ToString());
            }

            if (cb3.Items.Contains(tb2.Text.ToString()))
            {

            }
            else
            {
                cb3.Items.Add(tb2.Text.ToString());
            }

            if (cb4.Items.Contains(tb2.Text.ToString()))
            {

            }
            else
            {
                cb4.Items.Add(tb2.Text.ToString());
            }

            SAElement sae = new SAElement();
            sae.level = "Domain";
            sae.reference = tb2.Text.ToString();
            sae.typ = cb2.SelectedItem.ToString();
            sae.arguments.Add(cb3.SelectedItem.ToString());
            sae.arguments.Add(cb4.SelectedItem.ToString());

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (lb1.Items.Contains("ELEMENT " + tb1.Text.ToString() + " Domain " + "Occupant " + cb1.SelectedItem.ToString()))
            {

            }
            else
            {
                lb1.Items.Add("ELEMENT " + tb1.Text.ToString() + " Domain " + "Occupant " + cb1.SelectedItem.ToString());
            }

            if (lb2.Items.Contains(tb1.Text.ToString() + " is an Occupant with profile " + "'" + cb1.SelectedItem.ToString() + "'"))
            {

            }
            else
            {
                lb2.Items.Add(tb1.Text.ToString() + " is an Occupant with profile " + "'" + cb1.SelectedItem.ToString() + "'");
            }

            if (cb4.Items.Contains(tb1.Text.ToString()))
            {

            }
            else 
            {
                cb4.Items.Add(tb1.Text.ToString());
            }

            SAElement sae = new SAElement();
            sae.level = "Domain";
            sae.reference = tb1.Text.ToString();
            sae.typ = "Occupant";
            sae.arguments.Append(cb1.SelectedItem.ToString());

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Step4 step4 = new Step4(Doc);
            foreach (string el in lb2.Items)
            { 
                if (Step4.instance.cb1.Items.Contains(el))
                {

                }
                 else 
                { 
                    Step4.instance.cb1.Items.Add(el); 
                }
                        
            }

            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void opennewform()
        {
            System.Windows.Forms.Application.Run(Step4.instance);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (lb1.Items.Contains("ELEMENT " + tb3.Text.ToString() + " Domain " + cb5.SelectedItem.ToString() + " " + cb6.SelectedItem.ToString() + " " + cb7.SelectedItem.ToString()))
            {

            }
            else
            {
                lb1.Items.Add("ELEMENT " + tb3.Text.ToString() + " Domain " + cb5.SelectedItem.ToString() + " " + cb6.SelectedItem.ToString() + " " + cb7.SelectedItem.ToString());
            }

            if (lb2.Items.Contains(tb3.Text.ToString() + " is the " + cb5.SelectedItem.ToString() + " of " + cb6.SelectedItem.ToString() + " and " + cb7.SelectedItem.ToString()))
            {

            }
            else
            {
                lb2.Items.Add(tb3.Text.ToString() + " is the " + cb5.SelectedItem.ToString() + " of " + cb6.SelectedItem.ToString() + " and " + cb7.SelectedItem.ToString());
            }

            SAElement sae = new SAElement();
            sae.level = "Domain";
            sae.reference = tb3.Text.ToString();
            sae.typ = cb5.SelectedItem.ToString();
            sae.arguments.Add(cb6.SelectedItem.ToString());
            sae.arguments.Add(cb7.SelectedItem.ToString());
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int idx = lb1.SelectedIndex;
            lb1.Items.RemoveAt(idx);
        }

        private void Step3_Load(object sender, EventArgs e)
        {

        }
    }
}
