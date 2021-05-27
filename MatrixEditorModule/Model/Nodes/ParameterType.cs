using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMatrixEditor.Model.Nodes
{
    public enum ParameterType
    {
        [Display(Name = "Вход")]
        Input,
        [Display(Name = "Выход")]
        Output,
        [Display(Name = "Вход/Выход")]
        InputOutput
    }
}
