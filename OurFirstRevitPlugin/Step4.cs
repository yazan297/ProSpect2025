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
    public partial class Step4 : System.Windows.Forms.Form
    {
        Autodesk.Revit.DB.Document Doc;

        public static Step4 instance;



        public ComboBox cb1;
        public ComboBox cb2;
        public ListBox lb1;
        public ListBox lb2;

        public TextBox tb1;
        public TextBox tb2;
        public TextBox tb3;


        Thread th;
        public Step4(Autodesk.Revit.DB.Document doc)
        {
            InitializeComponent();
            Doc = doc;
            instance = this;
            cb1 = comboBox1;
            cb2 = comboBox2;
            lb1 = listBox1;
            lb2 = listBox2;
            tb1 = textBox1;
            tb2 = textBox2;
            tb3 = textBox3;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (lb1.Items.Contains("Element " + tb1.Text.ToString() + " Goal SocialIntention " + cb2.SelectedItem.ToString() + cb1.SelectedItem.ToString().Substring(0, cb1.SelectedItem.ToString().IndexOf(' '))))
            {

            }
            else
            {
                lb1.Items.Add("Element " + tb1.Text.ToString() + " Goal SocialIntention " + cb2.SelectedItem.ToString() + cb1.SelectedItem.ToString().Substring(0, cb1.SelectedItem.ToString().IndexOf(' ')));
            }


            if (lb2.Items.Contains(tb1.Text.ToString() + " is a Social Intention " +  cb2.SelectedItem.ToString()))
            {

            }
            else
            {
                lb2.Items.Add(tb1.Text.ToString() + " is a Social Intention " + cb2.SelectedItem.ToString());
            }

            SAElement sae = new SAElement();
            sae.level = "Goal";
            sae.reference = tb1.Text.ToString();
            sae.typ = "SocialIntention";
            sae.arguments.Add(cb2.SelectedItem.ToString());
            sae.arguments.Add(cb1.SelectedItem.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int idx = lb1.SelectedIndex;
            lb1.Items.RemoveAt(idx);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //SocialArgument sa = new SocialArgument();
            //sa.addElement();
            //string text = Interaction.InputBox("Enter argument reference");
            //string text2 = Interaction.InputBox("Enter argument description");

            MessageBox.Show("The social design intention has been created successfully");

         

            Step1.instance.Close();
            Step2.instance.Close();
            Step3.instance.Close();
            Step4.instance.Hide();
        }

        private void Step4_Load(object sender, EventArgs e)
        {

        }
    }
}
