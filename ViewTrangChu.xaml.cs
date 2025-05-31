using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TINHTOANVANKHUONDAM.Class;
using TINHTOANVANKHUONDAM.ViewModels;

namespace TINHTOANVANKHUONDAM.View
{
    /// <summary>
    /// Interaction logic for ViewTrangChu.xaml
    /// </summary>
    public partial class ViewTrangChu : Window
    {
        public bool dialogResult = false;
        public Document Doc;

        public ViewTrangChu(Document document,UIDocument uiDoc)
        {
            InitializeComponent();
            Doc = document;
            dialogResult = true;
            this.DataContext = new BeamVM(document,uiDoc);
            dtgBeam.ItemsSource = clsBienToanCuc.Beams;
        }
    }

}
