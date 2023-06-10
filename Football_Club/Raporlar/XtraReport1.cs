using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DocumentView;

namespace Football_Club.Raporlar
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public string ad;
        sqlbaglantisi bgl = new sqlbaglantisi();
        public XtraReport1()
        {
            InitializeComponent();
        }


        //internal void ShowPreview()
        //{
        //    throw new NotImplementedException();
        //}

        //internal void ExportOptions()
        //{
        //    throw new NotImplementedException();
        //}

        internal void ShowPreview(string p)
        {
            throw new NotImplementedException();
        }

        internal void ShowPreview(DevExpress.XtraGrid.Columns.GridColumn Adi)
        {
            throw new NotImplementedException();
        }
    }
}
