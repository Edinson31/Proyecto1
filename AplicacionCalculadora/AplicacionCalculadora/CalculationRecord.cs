﻿using System;

namespace AplicacionCalculadora
{
    public class CalculationRecord
    {
        public int Id { get; set; }
        public string Expression { get; set; }
        public string Result { get; set; }
        public DateTime DatePerformed { get; set; }
    }
}

