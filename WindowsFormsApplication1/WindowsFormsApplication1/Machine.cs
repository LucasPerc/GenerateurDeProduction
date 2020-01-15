﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    class Machine : Element
    {
        public static long NbMachine;
        private int _X1;
        private int _Y1;
        private int _xGrid;
        private int _yGrid;
        public string _nom;
        private Element _ElemPrec;
        private Element _ElemSuiv;
        private bool _isSelected;

        int Element.X1
        {
            get { return _X1; }
            set { _X1 = value; }
        }
        int Element.Y1
        {
            get { return _Y1; }
            set { _Y1 = value; }
        }

        public int xGrid
        {
            get { return _xGrid; }
            set { _xGrid = value; }
        }
        public int yGrid
        {
            get { return _yGrid; }
            set { _yGrid = value; }
        }

        public Element ElemPrec
        {
            get { return _ElemPrec; }
            set { _ElemPrec = value; }
        }
        public Element ElemSuiv
        {
            get { return _ElemSuiv; }
            set { _ElemSuiv = value; }
        }
        bool Element.isSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }

        public Machine(int x1, int y1)
        {
            _X1 = x1;
            _Y1 = y1;
       
            NbMachine += 1;
            _nom = "Machine" + NbMachine;
            _isSelected = false;
        }

        ~Machine()
        {
            NbMachine -= 1;
        }

        public override string ToString()
        {
            return _nom + " X:" + _xGrid + " Y:" + _yGrid;
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
