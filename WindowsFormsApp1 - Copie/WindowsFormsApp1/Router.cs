﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Dynamic;

namespace WindowsFormsApp1
{
    class Router : Element
    {
        private List<int> _sequence; // voir pour la séquence......

        public List<int> Sequence
        {
            get { return _sequence; }
        }

        public Router() : base(1, 2, @"Images\router.png")
        {
            _sequence = new List<int>();

            try
            {
                Button button = this.Controls.Find("button1", true).FirstOrDefault() as Button;
                button.MouseDown += setParameter;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private void setParameter(object sender, MouseEventArgs e)
        {
            string userString = null;
            Form1 form1 = (Form1)Form.ActiveForm;
            if (!form1.IsLinking)
            {
                try
                {
                    if (e.Clicks == 2)
                    {
                        Form2 form2 = new Form2("Router", "Entrer ici la séquence");
                        if (form2.ShowDialog(this) == DialogResult.OK)
                        {
                            userString = form2.TextBox.Text;//voir pour le parsage.... 
                        }
                        form2.Dispose();
                    }
                }
                catch { }
            }
            
        }

        public override dynamic GenerateJson()
        {
            dynamic myObject = new ExpandoObject();
            myObject.name = this.GetType().Name;
            myObject.id = this.ID;
            myObject.X = this.Position.X;
            myObject.Y = this.Position.Y;
            myObject.sequence = this.Sequence;
            return myObject;
        }
    }
}
